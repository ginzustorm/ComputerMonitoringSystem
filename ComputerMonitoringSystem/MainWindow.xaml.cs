using ComputerMonitoringSystem.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;


namespace ComputerMonitoringSystem
{
    public partial class MainWindow : Window
    {
        private AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PcMonitoringDatabase;Integrated Security=True");
            _context = new AppDbContext(optionsBuilder.Options);
        }

        private void KnowledgeBaseEditorButton_Click(object sender, RoutedEventArgs e)
        {
            // Создайте и откройте окно редактора базы знаний
            var knowledgeBaseEditorWindow = new KnowledgeBaseEditorWindow();
            knowledgeBaseEditorWindow.Show();
        }

        private void ProblemSolverButton_Click(object sender, RoutedEventArgs e)
        {
            var troubleshooter = new ComputerTroubleshooter(_context);
            var problemSolverWindow = new ProblemSolverWindow(troubleshooter, _context);
            problemSolverWindow.Show();
        }

    }
}
