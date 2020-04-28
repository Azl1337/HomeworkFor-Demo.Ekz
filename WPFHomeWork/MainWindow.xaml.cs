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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BuySellDBEntities db;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            try
            {
                db = new BuySellDBEntities();
                db.tWorker.Load();

                dttWorker.ItemsSource = db.tWorker.Local.ToBindingList();
            }
            catch
            {
                MessageBox.Show("Ошибка");
                db.Dispose();
            }

        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка");
                db.Dispose();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dttWorker.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < dttWorker.SelectedItems.Count; i++)
                    {
                        tWorker worker = dttWorker.SelectedItems[i] as tWorker;
                        if (worker != null)
                        {
                            db.tWorker.Remove(worker);
                        }
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
                db.Dispose();
                LoadData();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dttWorker.SelectedItems.Count > 0)
            {
                tWorker worker = dttWorker.SelectedItem as tWorker;
                if (worker == null)
                    return;
                WindowInformationEditor windowInfEdit = new WindowInformationEditor(worker, db);
                windowInfEdit.ShowDialog();
                db.Dispose();
                LoadData();

            }

        }
    }
}
