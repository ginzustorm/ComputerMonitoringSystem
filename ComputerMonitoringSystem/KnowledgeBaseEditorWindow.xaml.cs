using System.Windows;
using System.Windows.Controls;

namespace ComputerMonitoringSystem
{
    /// <summary>
    /// Логика взаимодействия для KnowledgeBaseEditorWindow.xaml
    /// </summary>
    public partial class KnowledgeBaseEditorWindow : Window
    {
        public KnowledgeBaseEditorWindow()
        {
            InitializeComponent();
        }

        private void listBoxSections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSection = (ListBoxItem)listBoxSections.SelectedItem;
            string sectionName = selectedSection.Content.ToString();

            Window windowToOpen;

            switch (sectionName)
            {
                case "Признаки":
                    windowToOpen = new FeaturesWindow();
                    break;
                case "Возможные значения признаков":
                    windowToOpen = new FeatureValuesWindow();
                    break;
                case "Нормальные значения признаков":
                    windowToOpen = new NormalFeatureValuesWindow();
                    break;
                case "Неполадка":
                    windowToOpen = new IssuesWindow();
                    break;
                case "Значение признаков при неполадке":
                    windowToOpen = new IssueFeatureValuesWindow();
                    break;
                default:
                    return;
            }

            windowToOpen.ShowDialog();
        }
    }
}
