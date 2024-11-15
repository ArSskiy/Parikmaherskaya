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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Parikmaherskaya
{
    /// <summary>
    /// Логика взаимодействия для VedenieUcheta.xaml
    /// </summary>
    public partial class VedenieUcheta : Page
    {
        public VedenieUcheta()
        {
            InitializeComponent();
            ManufacCb.SelectedValuePath = "ID";
            ManufacCb.DisplayMemberPath = "Name";
            ManufacCb.ItemsSource = ClassConnect.ent.Manufacturer.ToList();

            EmployeeCb.SelectedValuePath = "ID";
            EmployeeCb.DisplayMemberPath = "Name";
            EmployeeCb.ItemsSource = ClassConnect.ent.Employee.ToList();

            MaterialCb.SelectedValuePath = "ID";
            MaterialCb.DisplayMemberPath = "Name";
            MaterialCb.ItemsSource = ClassConnect.ent.Material.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(ManufacCb.Text))
            {
                mes += "Введите производителя\n";
            }
            if (string.IsNullOrWhiteSpace(EmployeeCb.Text))
            {
                mes += "выберете сотрудника\n";
            }
            if (string.IsNullOrWhiteSpace(MaterialCb.Text))
            {
                mes += "выберете товар\n";
            }
            if (string.IsNullOrWhiteSpace(PriceTb.Text))
            {
                mes += "Введите цену\n";
            }
            if (string.IsNullOrWhiteSpace(QuantityTb.Text))
            {
                mes += "Введите количество\n";
            }
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Acounting accounting = new Acounting()
            {
                DateDelivery = DateP.DisplayDate,
                Employee = EmployeeCb.SelectedItem as Employee,
                Material = MaterialCb.SelectedItem as Material,
                Price=Convert.ToDecimal(PriceTb.Text),
                Quantity=int.Parse(QuantityTb.Text),
                
            };
            ClassConnect.ent.Acounting.Add(accounting);
            ClassConnect.ent.SaveChanges();
            MessageBox.Show("Запись добавлена");
        }

        private void ManufacCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectManufac = Convert.ToInt32(ManufacCb.SelectedValue);
            MaterialCb.ItemsSource = ClassConnect.ent.Material.Where(x => x.IdManufacturer == selectManufac).ToList();
        }
    }
}
