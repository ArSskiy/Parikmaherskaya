using Parikmaherskaya.ClassPr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace Parikmaherskaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassConnect.ent = new Entities();
            ClassFrame.FrameBody = BodyMainFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BodyMainFrame.Navigate(new AddManufac());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BodyMainFrame.Navigate(new AddMaterialPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BodyMainFrame.Navigate(new AddEmployee());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            BodyMainFrame.Navigate(new VedenieUcheta());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            BodyMainFrame.Navigate(new Uchet());
        }
    }
}
