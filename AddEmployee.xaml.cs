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
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(EmployeeTb.Text))
            {
                mes += "Введите сотрудника\n";
            }
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            Employee employee = new Employee()
            {
                Name = EmployeeTb.Text,
            };
            ClassConnect.ent.Employee.Add(employee);
            ClassConnect.ent.SaveChanges();
            MessageBox.Show("Сотрудник добавлен");

            EmployeeTb.Text = "";
        }
    }
}
