using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AnApp.xaml
    /// </summary>
    public partial class AnApp : UserControl
    {
        private TextBox textBox;
        String path;
        private List<string> filepaths;
        private Random random;
        private int cost;
        private int available_balance;
        private HashSet<string> purchased_apps;
        public AnApp()
        {
            InitializeComponent();
            AppInfo.Foreground = Brushes.White;
            path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + @"\Images";
            Download.Source = new BitmapImage(new Uri(path + "\\download.png", UriKind.RelativeOrAbsolute));
            filepaths = Directory.GetFiles(path, "*.png").ToList<string>();
            FileInfo defaultImage = new FileInfo(filepaths[0]);
            //ProductImage.Source = new BitmapImage(new Uri(defaultImage.FullName, UriKind.RelativeOrAbsolute));
            //ProductName.Text = "calendar";
            random = new Random();
            FileInfo myRandomFile = new FileInfo(filepaths[random.Next(filepaths.Count)]);
            ProductImage.Source = new BitmapImage(new Uri(myRandomFile.FullName, UriKind.RelativeOrAbsolute));
            ProductName.Text = myRandomFile.Name.Split(".")[0];
            int price = random.Next(1, 100);
            AppInfo.Content = "$"+price;
            cost = price;
            purchased_apps = new HashSet<string>();
            
        }

        private void Download_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            available_balance = AppsViewer.MAXIMUM_BALANCE -= cost;
            if (available_balance < 0)
            {
                //This item was not bought
                MessageBox.Show("Oops, you have insufficient balance to buy this product! 👀");
                AppsViewer.MAXIMUM_BALANCE += cost;
            }
            else if (purchased_apps.Contains(ProductName.Text))
                MessageBox.Show("You have already purchased " + ProductName.Text + "!");
            else
            {
                MessageBox.Show(ProductName.Text + " purchased worth " + AppInfo.Content + "!\nRemaining balance: " + available_balance);
                purchased_apps.Add(ProductName.Text);
            }
        }
    }
}
