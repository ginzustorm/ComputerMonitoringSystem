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

        public FeatureValuesWindow()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();

            LoadFeatures();
            LoadFeatureValues();
        }

        private void LoadFeatures()
        {
            var features = _dbContext.Features.ToList();
            cbFeatures.ItemsSource = features;
        }

        private void LoadFeatureValues()
        {
            var featureValues = _dbContext.FeatureValues.Include("Feature").ToList();
            listBoxFeatureValues.ItemsSource = featureValues;
        }

        private void btnAddFeatureValue_Click(object sender, RoutedEventArgs e)
        {
            if (cbFeatures.SelectedItem == null || string.IsNullOrWhiteSpace(tbFeatureValue.Text))
            {
                MessageBox.Show("Выберите признак и введите значение.");
                return;
            }

            var feature = (Feature)cbFeatures.SelectedItem;
            var newValue = new FeatureValue
            {
                FeatureId = feature.Id,
                Value = tbFeatureValue.Text.Trim()
            };

            _dbContext.FeatureValues.Add(newValue);
            _dbContext.SaveChanges();
            LoadFeatureValues();
            tbFeatureValue.Clear();
        }

        private void btnRemoveFeatureValue_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var featureValueToRemove = (FeatureValue)button.DataContext;

            _dbContext.FeatureValues.Remove(featureValueToRemove);
            _dbContext.SaveChanges();
            LoadFeatureValues();
        }
    }
}
