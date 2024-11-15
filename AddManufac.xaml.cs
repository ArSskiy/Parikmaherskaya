using Parikmaherskaya.ClassPr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddManufac.xaml
    /// </summary>
    public partial class AddManufac : Page
    {
        public AddManufac()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(ManufacTb.Text))
            {
                mes += "Введите производителя\n";
            }
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Manufacturer manufacturer = new Manufacturer()
            {
                Name = ManufacTb.Text,
            };
            ClassConnect.ent.Manufacturer.Add(manufacturer);
            ClassConnect.ent.SaveChanges();
            MessageBox.Show("Производитель добавлен");

            ManufacTb.Text = "";
        }
    }
}
