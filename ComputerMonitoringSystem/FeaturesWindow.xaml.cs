using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;

namespace ComputerMonitoringSystem
{
    public partial class FeaturesWindow : Window
    {
        private readonly AppDbContext _dbContext;

        public FeaturesWindow()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();
            RefreshFeaturesList();
        }

        private void addFeatureButton_Click(object sender, RoutedEventArgs e)
        {
            string featureName = featureNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(featureName))
            {
                MessageBox.Show("Введите название признака");
                return;
            }

            Feature newFeature = new Feature { Name = featureName };
            _dbContext.Features.Add(newFeature);
            _dbContext.SaveChanges();
            RefreshFeaturesList();
            featureNameTextBox.Clear();
        }

        private void deleteFeatureButton_Click(object sender, RoutedEventArgs e)
        {
            if (featuresListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите признак для удаления");
                return;
            }

            Feature selectedFeature = (Feature)featuresListBox.SelectedItem;
            _dbContext.Features.Remove(selectedFeature);
            _dbContext.SaveChanges();
            RefreshFeaturesList();
        }

        private void RefreshFeaturesList()
        {
            featuresListBox.ItemsSource = _dbContext.Features.ToList();
        }
    }
}

