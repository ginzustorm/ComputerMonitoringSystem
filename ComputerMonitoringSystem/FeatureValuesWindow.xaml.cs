using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ComputerMonitoringSystem
{
    public partial class FeatureValuesWindow : Window
    {
        private readonly AppDbContext _dbContext;
        private Feature _selectedFeature;

        public FeatureValuesWindow()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();

            LoadFeatures();
            cbFeatures.SelectionChanged += CbFeatures_SelectionChanged;
        }

        private void CbFeatures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFeatures.SelectedItem is Feature selectedFeature)
            {
                _selectedFeature = selectedFeature;
                LoadFeatureValues(_selectedFeature.Id);
            }
        }

        private void LoadFeatures()
        {
            var features = _dbContext.Features.ToList();
            cbFeatures.ItemsSource = features;
        }

        private void LoadFeatureValues(int featureId)
        {
            var featureValues = _dbContext.FeatureValues.Where(fv => fv.FeatureId == featureId).Include("Feature").ToList();
            listBoxFeatureValues.ItemsSource = featureValues;
        }

        private void btnAddFeatureValue_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedFeature == null || string.IsNullOrWhiteSpace(tbFeatureValue.Text))
            {
                MessageBox.Show("Выберите признак и введите значение.");
                return;
            }

            var newValue = new FeatureValue
            {
                FeatureId = _selectedFeature.Id,
                Value = tbFeatureValue.Text.Trim()
            };

            _dbContext.FeatureValues.Add(newValue);
            _dbContext.SaveChanges();
            LoadFeatureValues(_selectedFeature.Id);
            tbFeatureValue.Clear();
        }

        private void btnRemoveFeatureValue_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var featureValueToRemove = (FeatureValue)button.DataContext;

            _dbContext.FeatureValues.Remove(featureValueToRemove);
            _dbContext.SaveChanges();
            LoadFeatureValues(_selectedFeature.Id);
        }
    }
}
