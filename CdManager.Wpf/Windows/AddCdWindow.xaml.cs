using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using CdManager.Model;

namespace CdManager.Wpf
{
    /// <summary>
    /// Interaction logic for AddCdWindow.xaml
    /// </summary>
    public partial class AddCdWindow : Window
    {
        public AddCdWindow()
        {
            InitializeComponent();

            Loaded += AddCdWindow_Loaded;
        }

        public void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            DataContext = new Cd() { AlbumTitle = "", Artist = "" };
        }

        public void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Repository.GetInstance().AddCd(DataContext as Cd);
            Close();
        }

/*        public void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Neue CD in Repository hinzufügen - ohne Fehlerüberprüfung
            Cd newCd = new Cd();
            newCd.AlbumTitle = tbTitle.Text;
            newCd.Artist = tbArtist.Text;
        }
*/
        public void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
