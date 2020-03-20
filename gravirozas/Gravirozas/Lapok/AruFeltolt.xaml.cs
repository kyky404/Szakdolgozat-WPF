﻿using Gravirozas.Model.Entity;
using Gravirozas.Service;
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

namespace Gravirozas.Lapok
{
    /// <summary>
    /// Interaction logic for AruFeltolt.xaml
    /// </summary>

    public partial class AruFeltolt : Page
    {
        private readonly AruService _aruService = null;
        public List<Aru> aruk;
        public AruFeltolt()
        {
            _aruService = new AruService();
            aruk = _aruService.GetAll().ResponseObject;
            InitializeComponent();
            arunevCB.SelectedIndex = 0;
            for (int i = 0; i < aruk.Count; i++)
            {
                arunevCB.Items.Add(aruk[i].Id + "." + aruk[i].Nev);
            }
        }

        private void feltoltB_Click(object sender, RoutedEventArgs e)
        {
            if (arunevCB.SelectedItem == null || mennyisegTB.Text == null)
            {
                MessageBox.Show("Minden mező kitöltése kötelező!");
            }
            int x = -1;
            x = _aruService.UpdateMennyiseg(int.Parse(arunevCB.SelectedItem.ToString().Split('.')[0]), int.Parse(mennyisegTB.Text)).ResponseObject;
            if (x < 0)
            {
                MessageBox.Show("Hiba a feltöltésben!");
            }
            else
            {
                MessageBox.Show("Sikeres feltöltés!");
            }
        }

        private void ArunevCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string kepnev = arunevCB.SelectedItem.ToString().Split('.')[1];
            string eleres = System.IO.Path.GetFullPath(kepnev);
            Kep.Source = new BitmapImage(new Uri(eleres+".jpg"));
        }
    }   
}
