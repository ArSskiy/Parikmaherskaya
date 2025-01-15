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
    /// Логика взаимодействия для Uchet.xaml
    /// </summary>
    public partial class Uchet : Page
    {
        public Uchet()
        {
            InitializeComponent();

            EmployeCmb.SelectedValuePath = "ID";
            EmployeCmb.DisplayMemberPath = "Name";
            EmployeCmb.ItemsSource = ClassConnect.ent.Employee.ToList();
        }

        private void DatGr_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void EmployeCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int selectEmployee = Convert.ToInt32(EmployeCmb.SelectedValue);
            var a = (DateTime)StartDP.SelectedDate;
            var b = (DateTime)EndDP.SelectedDate;
            DatGr.ItemsSource = ClassConnect.ent.Acounting.
                Where(x => x.IdEmployee == selectEmployee)
                .Select(y => y.DateDelivery >= a && y.DateDelivery <= b).ToList();

            var CountRecording = ClassConnect.ent.Acounting.Where
                (x => x.IdEmployee == selectEmployee).Count();
            TC.Text = Convert.ToString(CountRecording);

            var SumSotr = ClassConnect.ent.Acounting.Where
                (x => x.IdEmployee == selectEmployee).
                Select(y => y.Amount).Sum();
            TS.Text = Convert.ToString(SumSotr);

        }
    }
}
