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
        public AnApp()
        {
            InitializeComponent();
            AppInfo.Foreground = Brushes.White;
            path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + @"\Images";
            filepaths = Directory.GetFiles(path, "*.png").ToList<string>();
            FileInfo defaultImage = new FileInfo(filepaths[0]);
            //ProductImage.Source = new BitmapImage(new Uri(defaultImage.FullName, UriKind.RelativeOrAbsolute));
            //ProductName.Text = "calendar";
            random = new Random();
            FileInfo myRandomFile = new FileInfo(filepaths[random.Next(filepaths.Count)]);
            ProductImage.Source = new BitmapImage(new Uri(myRandomFile.FullName, UriKind.RelativeOrAbsolute));
            ProductName.Text = myRandomFile.Name.Split(".")[0];
        }

        
    }
}
