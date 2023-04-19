using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using System.Linq;
using System.Windows;

namespace ComputerMonitoringSystem
{
    public partial class NormalFeatureValuesWindow : Window
    {
        private readonly AppDbContext _context;
        private Feature _selectedFeature;

        public NormalFeatureValuesWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            cbFeatures.ItemsSource = _context.Features.ToList();
            cbFeatures.SelectionChanged += CbFeatures_SelectionChanged;
        }

        private void CbFeatures_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbFeatures.SelectedItem is Feature selectedFeature)
            {
                _selectedFeature = selectedFeature;
                UpdateFeatureValuesList(_selectedFeature.Id);
                lbNormalFeatureValues.ItemsSource = _context.NormalFeatureValues.Where(nfv => nfv.FeatureId == _selectedFeature.Id).ToList();
            }
        }

        private void UpdateFeatureValuesList(int featureId)
        {
            var featureValues = _context.FeatureValues.Where(fv => fv.FeatureId == featureId).ToList();
            lbAllFeatureValues.ItemsSource = featureValues;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedFeature != null && lbAllFeatureValues.SelectedItem is FeatureValue selectedFeatureValue)
            {
                var normalFeatureValue = new NormalFeatureValue
                {
                    FeatureId = _selectedFeature.Id,
                    Value = selectedFeatureValue.Value
                };
                _context.NormalFeatureValues.Add(normalFeatureValue);
                _context.SaveChanges();
                lbNormalFeatureValues.ItemsSource = _context.NormalFeatureValues.Where(nfv => nfv.FeatureId == _selectedFeature.Id).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbNormalFeatureValues.SelectedItem is NormalFeatureValue selectedNormalFeatureValue)
            {
                _context.NormalFeatureValues.Remove(selectedNormalFeatureValue);
                _context.SaveChanges();
                lbNormalFeatureValues.ItemsSource = _context.NormalFeatureValues.Where(nfv => nfv.FeatureId == _selectedFeature.Id).ToList();
            }
        }
    }
}
