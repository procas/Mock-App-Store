using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppsControl.UserControls
{
    /// <summary>
    /// Interaction logic for AppsViewer.xaml
    /// </summary>
    public partial class AppsViewer : UserControl
    {
        private List<AnApp> apps;
        private int widthOfAnApp;
        public static int MAXIMUM_BALANCE = 100; //dollars
        public AppsViewer()
        {
            InitializeComponent();
            apps = new();
            AppsList.ItemsSource = apps;
            for(int i = 0; i < 10; i++)
            {
                AnApp anApp = new AnApp();
                apps.Add(anApp);
            }
            widthOfAnApp = (int)apps.First().Width;
        }

        private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
        {

            //AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 4 * widthOfAnApp);
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 1*widthOfAnApp);
            //MessageBox.Show("CLICK WORKS!");
        }
        private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
        {
            //AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 4 * widthOfAnApp);
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 1*widthOfAnApp);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CLICK WORKS");
        }
    }
}
