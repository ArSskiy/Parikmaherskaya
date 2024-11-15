using Parikmaherskaya.ClassPr;
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

namespace Parikmaherskaya
{
    /// <summary>
    /// Логика взаимодействия для AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        public AddMaterialPage()
        {
            InitializeComponent();
            ManufacCb.SelectedValuePath = "ID";
            ManufacCb.DisplayMemberPath = "Name";
            ManufacCb.ItemsSource = ClassConnect.ent.Manufacturer.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(MaterialTb.Text))
            {
                mes += "Введите товар\n";
            }
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Material material = new Material()
            {
                Name = MaterialTb.Text,
                Manufacturer = ManufacCb.SelectedItem as Manufacturer

            };
            ClassConnect.ent.Material.Add(material);
            ClassConnect.ent.SaveChanges();
            MessageBox.Show("Материал добавлен");

            MaterialTb.Text = "";
            ManufacCb.Text = "";
        }
    }
}
