using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CdManager.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for EditCdWindow.xaml
    /// </summary>
    public partial class EditCdWindow : Window
    {
        Cd _editCd;
        readonly Cd _cd;

        public EditCdWindow(Cd cd)
        {
            InitializeComponent();
            _cd = cd;
            Loaded += EditCdWindow_Loaded;
        }

        private void EditCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_CLick;
            btnCancel.Click += BtnCancel_Click;

            _editCd = new Cd
            {
                AlbumTitle = _cd.AlbumTitle,
                Artist = _cd.Artist
            };

            gridEdit.DataContext = _editCd;
        }

        private void BtnSave_CLick(object sender, RoutedEventArgs e)
        {
            _cd.AlbumTitle = _editCd.AlbumTitle;
            _cd.Artist = _editCd.Artist;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
