using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerMonitoringSystem
{
    public partial class ProblemSolverWindow : Window
    {
        private readonly AppDbContext _context;
        private readonly ComputerTroubleshooter _troubleshooter;
        private readonly List<Feature> _features;
        private readonly List<FeatureValue> _featureValues;
        private List<int> _selectedFeatureValueIds;


        public ProblemSolverWindow(ComputerTroubleshooter troubleshooter, AppDbContext context)
        {
            InitializeComponent();
            _troubleshooter = troubleshooter;
            _context = context;
            _selectedFeatureValueIds = new List<int>();
            LoadFeaturesAndValues();
        }

        private async void LoadFeaturesAndValues()
        {
            var features = await _context.Features.Include(f => f.FeatureValues).ToListAsync();

            foreach (var feature in features)
            {
                var featureExpander = new Expander { Header = feature.Name, Margin = new Thickness(0, 0, 0, 10) };
                var featureValuesPanel = new StackPanel();

                foreach (var featureValue in feature.FeatureValues)
                {
                    var radioButton = new RadioButton
                    {
                        Content = featureValue.Value,
                        GroupName = $"Feature{feature.Id}",
                        Tag = featureValue.Id
                    };
                    radioButton.Checked += FeatureValue_Checked;
                    featureValuesPanel.Children.Add(radioButton);
                }

                featureExpander.Content = featureValuesPanel;
                FeaturesListBox.Items.Add(featureExpander);
            }
        }

        private void FeatureValue_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            int featureValueId = (int)radioButton.Tag;
            _selectedFeatureValueIds.Add(featureValueId);
        }

        private void SolveProblem_Click(object sender, RoutedEventArgs e)
        {
            var selectedFeatureValues = _context.FeatureValues
                .Where(fv => _selectedFeatureValueIds.Contains(fv.Id))
                .ToList();

            var result = _troubleshooter.Diagnose(selectedFeatureValues);

            // Отобразите результат в нужном элементе управления, например, в TextBlock
            ResultTextBox.Text = result;
        }
    }
}
