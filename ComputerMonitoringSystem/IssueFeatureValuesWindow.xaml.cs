using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using System.Linq;
using System.Windows;

namespace ComputerMonitoringSystem
{
    public partial class IssueFeatureValuesWindow : Window
    {
        private readonly AppDbContext _context;
        private Issue _selectedIssue;

        public IssueFeatureValuesWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            cbIssues.ItemsSource = _context.Issues.ToList();
            cbIssues.SelectionChanged += CbIssues_SelectionChanged;
        }

        private void UpdateFeatureValuesList(int issueId)
        {
            var relatedFeatureValueIds = _context.IssueFeatureValues
                .Where(ifv => ifv.IssueId == issueId)
                .Select(ifv => ifv.FeatureValueId)
                .ToList();

            var featureValues = _context.FeatureValues
                .Where(fv => relatedFeatureValueIds.Contains(fv.Id))
                .ToList();

            lbAllFeatureValues.ItemsSource = featureValues;
        }

        private void CbIssues_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbIssues.SelectedItem is Issue selectedIssue)
            {
                _selectedIssue = selectedIssue;
                UpdateFeatureValuesList(_selectedIssue.Id);
                lbIssueFeatureValues.ItemsSource = _context.IssueFeatureValues.Where(ifv => ifv.IssueId == _selectedIssue.Id).Select(ifv => ifv.FeatureValue).ToList();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedIssue != null && lbAllFeatureValues.SelectedItem is FeatureValue selectedFeatureValue)
            {
                var issueFeatureValue = new IssueFeatureValue
                {
                    IssueId = _selectedIssue.Id,
                    FeatureValueId = selectedFeatureValue.Id
                };
                _context.IssueFeatureValues.Add(issueFeatureValue);
                _context.SaveChanges();
                lbIssueFeatureValues.ItemsSource = _context.IssueFeatureValues.Where(ifv => ifv.IssueId == _selectedIssue.Id).Select(ifv => ifv.FeatureValue).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbIssueFeatureValues.SelectedItem is FeatureValue selectedFeatureValue)
            {
                var issueFeatureValue = _context.IssueFeatureValues.FirstOrDefault(ifv => ifv.IssueId == _selectedIssue.Id && ifv.FeatureValueId == selectedFeatureValue.Id);

                if (issueFeatureValue != null)
                {
                    _context.IssueFeatureValues.Remove(issueFeatureValue);
                    _context.SaveChanges();
                    lbIssueFeatureValues.ItemsSource = _context.IssueFeatureValues.Where(ifv => ifv.IssueId == _selectedIssue.Id).Select(ifv => ifv.FeatureValue).ToList();
                }
            }
        }
    }
}
