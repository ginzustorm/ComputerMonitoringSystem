using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using System;
using System.Linq;
using System.Windows;

namespace ComputerMonitoringSystem
{
    public partial class IssueFeatureValueEditWindow : Window
    {
        private readonly AppDbContext _context;
        public IssueFeatureValue IssueFeatureValue { get; private set; }

        public IssueFeatureValueEditWindow(IssueFeatureValue issueFeatureValue = null)
        {
            InitializeComponent();

            _context = new AppDbContext();

            cbIssues.ItemsSource = _context.Issues.ToList();
            cbFeatureValues.ItemsSource = _context.FeatureValues.ToList();

            if (issueFeatureValue == null)
            {
                IssueFeatureValue = new IssueFeatureValue();
            }
            else
            {
                IssueFeatureValue = issueFeatureValue;
                cbIssues.SelectedItem = IssueFeatureValue.Issue;
                cbFeatureValues.SelectedItem = IssueFeatureValue.FeatureValue;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbIssues.SelectedItem is Issue selectedIssue && cbFeatureValues.SelectedItem is FeatureValue selectedFeatureValue)
            {
                IssueFeatureValue.Issue = selectedIssue;
                IssueFeatureValue.FeatureValue = selectedFeatureValue;

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите проблему и значение признака.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
