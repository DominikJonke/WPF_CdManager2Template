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
using CdManager.Model;
using CdManager.Wpf.Windows;

namespace CdManager.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cd> _cds;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository rep = Repository.GetInstance();
            _cds = rep.GetAllCds();
            lbxCds.ItemsSource = _cds;

            btnNew.Click += BtnNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddCdWindow addCdWindow = new AddCdWindow();
            addCdWindow.ShowDialog();
            //Nachdem der "Neuanlegen Dialog" geschlossen wurde
            //Liste der CDs aktualisieren:
            _cds = Repository.GetInstance().GetAllCds();
            //Bei normaler Collection muss zusätzlich ItemSource neu gesetzt werden um Aktualisierung auszulösen
            lbxCds.ItemsSource = _cds;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(lbxCds.SelectedItem is Cd selectedCd))
            {
                MessageBox.Show("Keine CD ausgewählt!");
                return;
            }

            Repository.GetInstance().DeleteCd(selectedCd);

            Repository repo = Repository.GetInstance();
            _cds = repo.GetAllCds();
            lbxCds.ItemsSource = _cds;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbxCds.SelectedItem is Cd cdToEdit)
            {
                EditCdWindow editCdWindow = new EditCdWindow(cdToEdit);
                editCdWindow.ShowDialog();                                                          

                Repository repo = Repository.GetInstance();
                _cds = repo.GetAllCds();
                lbxCds.ItemsSource = _cds;
            }
            else
            {
                MessageBox.Show("Keine CD ausgewählt!");
            }
        }
    }
}
