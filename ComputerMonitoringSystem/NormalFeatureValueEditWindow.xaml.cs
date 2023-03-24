using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using System.Linq;
using System.Windows;

namespace ComputerMonitoringSystem
{
    public partial class NormalFeatureValueEditWindow : Window
    {
        private readonly AppDbContext _context;

        public NormalFeatureValue SelectedNormalFeatureValue { get; private set; }

        public NormalFeatureValueEditWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();

            cbNormalFeatureValues.ItemsSource = _context.NormalFeatureValues.ToList();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (cbNormalFeatureValues.SelectedItem is NormalFeatureValue selectedNormalFeatureValue)
            {
                SelectedNormalFeatureValue = selectedNormalFeatureValue;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите нормальное значение признака.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
