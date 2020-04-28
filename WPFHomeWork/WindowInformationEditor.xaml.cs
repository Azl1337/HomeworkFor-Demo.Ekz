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
using WPFHomeWork.Models;
using System.Data.Entity;

namespace WPFHomeWork
{
    /// <summary>
    /// Логика взаимодействия для WindowInformationEditor.xaml
    /// </summary>
    public partial class WindowInformationEditor : Window
    {
        BuySellDBEntities db;
        tWorker sp;
        public WindowInformationEditor()
        {
            InitializeComponent();
        }

        public WindowInformationEditor(tWorker worker, BuySellDBEntities d)
        {
            InitializeComponent();
            db = d;
            sp = worker;
            tbFIO.Text = worker.sFIO;
            txAddress.Text = worker.address;
            dtpBithday.SelectedDate = worker.bithday;
            tbphone.Text = worker.phone;
            tbbase.Text = worker.base_worker;
            tbexp.Text = Convert.ToString(worker.experience);
            tbsp.Text = worker.special;
            tbprice.Text = Convert.ToString(worker.price);
            tbpas.Text = Convert.ToString(worker.passport);
        }

        private void BtnSAve_Click(object sender, RoutedEventArgs e)
        {
            sp.sFIO = tbFIO.Text;
            sp.passport = tbpas.Text;
            sp.address = txAddress.Text;
            db.SaveChanges();
        }
    }
}
