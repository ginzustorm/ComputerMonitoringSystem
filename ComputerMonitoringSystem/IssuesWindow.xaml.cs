using System.Windows;
using System.Linq;
using ComputerMonitoringSystem.Models;
using ComputerMonitoringSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace ComputerMonitoringSystem
{
    public partial class IssuesWindow : Window
    {
        private readonly AppDbContext _context;

        public IssuesWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadIssues();
        }

        private async void LoadIssues()
        {
            var issues = await _context.Issues.ToListAsync();
            listBoxIssues.ItemsSource = issues;
        }

        private async void btnAddIssue_Click(object sender, RoutedEventArgs e)
        {
            var issueName = tbIssueName.Text.Trim();
            var issueDescription = tbIssueDescription.Text.Trim();

            if (string.IsNullOrEmpty(issueName) || string.IsNullOrEmpty(issueDescription))
            {
                MessageBox.Show("Введите название и описание неполадки.");
                return;
            }

            var issue = new Issue { Name = issueName, Description = issueDescription };
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            tbIssueName.Text = "";
            tbIssueDescription.Text = "";
            LoadIssues();
        }

        private async void btnRemoveIssue_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxIssues.SelectedItem == null)
            {
                MessageBox.Show("Выберите неполадку для удаления.");
                return;
            }

            var selectedIssue = (Issue)listBoxIssues.SelectedItem;
            _context.Issues.Remove(selectedIssue);
            await _context.SaveChangesAsync();

            LoadIssues();
        }
    }
}
