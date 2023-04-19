using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using System;
using System.Linq;
using System.Windows;

namespace ComputerMonitoringSystem
{
    public partial class IssueFeatureValuesWindow : Window
    {
        private readonly AppDbContext _context;

        public class IssueFeatureValueDisplay
        {
            public int Id { get; set; }
            public int IssueId { get; set; }
            public int FeatureValueId { get; set; }
            public string IssueName { get; set; }
            public string FeatureValue { get; set; }
        }

        public IssueFeatureValuesWindow()
        {
            InitializeComponent();

            _context = new AppDbContext();

            dataGridIssueFeatureValues.ItemsSource = _context.IssueFeatureValues
                .Select(ifv => new IssueFeatureValueDisplay
                {
                    Id = ifv.Id,
                    IssueName = ifv.Issue.Name,
                    FeatureValue = ifv.FeatureValue.Value
                })
                .ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new IssueFeatureValueEditWindow();
            if (editWindow.ShowDialog() == true)
            {
                var issueFeatureValue = editWindow.IssueFeatureValue;

                // Получите существующие объекты Issue и FeatureValue из базы данных
                var existingIssue = _context.Issues.Find(issueFeatureValue.Issue.Id);
                var existingFeatureValue = _context.FeatureValues.Find(issueFeatureValue.FeatureValue.Id);

                // Создайте новый объект IssueFeatureValue с использованием существующих объектов
                var newIssueFeatureValue = new IssueFeatureValue
                {
                    Issue = existingIssue,
                    FeatureValue = existingFeatureValue
                };

                _context.IssueFeatureValues.Add(newIssueFeatureValue);
                _context.SaveChanges();

                dataGridIssueFeatureValues.ItemsSource = _context.IssueFeatureValues
                    .Select(ifv => new IssueFeatureValueDisplay
                    {
                        Id = ifv.Id,
                        IssueName = ifv.Issue.Name,
                        FeatureValue = ifv.FeatureValue.Value
                    })
                    .ToList();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridIssueFeatureValues.SelectedItem is IssueFeatureValueDisplay selectedDisplayItem)
            {
                var issueFeatureValue = _context.IssueFeatureValues.Find(selectedDisplayItem.Id);
                var editWindow = new IssueFeatureValueEditWindow(issueFeatureValue);
                if (editWindow.ShowDialog() == true)
                {
                    _context.SaveChanges();

                    dataGridIssueFeatureValues.ItemsSource = _context.IssueFeatureValues
                        .Select(ifv => new IssueFeatureValueDisplay
                        {
                            Id = ifv.Id,
                            IssueName = ifv.Issue.Name,
                            FeatureValue = ifv.FeatureValue.Value
                        })
                        .ToList();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridIssueFeatureValues.SelectedItem is IssueFeatureValueDisplay selectedDisplayItem)
            {
                var issueFeatureValue = _context.IssueFeatureValues.FirstOrDefault(ifv => ifv.IssueId == selectedDisplayItem.IssueId && ifv.FeatureValueId == selectedDisplayItem.FeatureValueId);

                if (issueFeatureValue != null)
                {
                    _context.IssueFeatureValues.Remove(issueFeatureValue);
                    _context.SaveChanges();
                }

                dataGridIssueFeatureValues.ItemsSource = _context.IssueFeatureValues
                    .Select(ifv => new IssueFeatureValueDisplay
                    {
                        Id = ifv.Id,
                        IssueId = ifv.IssueId,
                        FeatureValueId = ifv.FeatureValueId,
                        IssueName = ifv.Issue.Name,
                        FeatureValue = ifv.FeatureValue.Value
                    })
                    .ToList();
            }
        }

    }
}