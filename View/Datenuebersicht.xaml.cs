﻿using System;
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
using System.Windows.Shapes;

namespace Klimalauf
{
   /// <summary>
   /// Interaktionslogik für Datenuebersicht.xaml
   /// </summary>
   public partial class Datenuebersicht : Window
   {
      public Datenuebersicht()
      {
         InitializeComponent();
      }
      private void LogoutIcon_MouseDown(object sender, MouseButtonEventArgs e)
      {
         // Create a new instance of MainWindow
         MainWindow mainWindow = new MainWindow();
         mainWindow.Show();

         // Close the current Scanner window
         this.Close();
      }

      private void CloseWindow_Click(object sender, RoutedEventArgs e)
      {

      }

      private void btnBarcodes_Click(object sender, RoutedEventArgs e)
      {

      }

      private void btnDownload_Click(object sender, RoutedEventArgs e)
      {

      }







      private void btnStartseite_Click(object sender, RoutedEventArgs e)
      {
         btnSchule.Visibility = Visibility.Visible;
         btnSchuleDisabled.Visibility = Visibility.Collapsed;

         btnKlassen.Visibility = Visibility.Visible;
         btnKlassenDisabled.Visibility = Visibility.Collapsed;

         btnSchueler.Visibility = Visibility.Visible;
         btnSchuelerDisabled.Visibility = Visibility.Collapsed;

         btnRunden.Visibility = Visibility.Visible;
         btnRundenDisabled.Visibility = Visibility.Collapsed;

         btnStartseite.Visibility = Visibility.Collapsed;
         btnStartseiteDisabled.Visibility = Visibility.Visible;


         SchuleGrid.Visibility = Visibility.Collapsed;
         KlasseGrid.Visibility = Visibility.Collapsed;
         SchuelerGrid.Visibility = Visibility.Collapsed;
         RundenGrid.Visibility = Visibility.Collapsed;
         StartseiteGrid.Visibility = Visibility.Visible;

         btnBarcodes.Visibility = Visibility.Collapsed;

      }

      private void btnRunden_Click(object sender, RoutedEventArgs e)
      {
         btnSchule.Visibility = Visibility.Visible;
         btnSchuleDisabled.Visibility = Visibility.Collapsed;

         btnKlassen.Visibility = Visibility.Visible;
         btnKlassenDisabled.Visibility = Visibility.Collapsed;

         btnSchueler.Visibility = Visibility.Visible;
         btnSchuelerDisabled.Visibility = Visibility.Collapsed;

         btnRunden.Visibility = Visibility.Collapsed;
         btnRundenDisabled.Visibility = Visibility.Visible;

         btnStartseite.Visibility = Visibility.Visible;
         btnStartseiteDisabled.Visibility = Visibility.Collapsed;


         SchuleGrid.Visibility = Visibility.Collapsed;
         KlasseGrid.Visibility = Visibility.Collapsed;
         SchuelerGrid.Visibility = Visibility.Collapsed;
         RundenGrid.Visibility = Visibility.Visible;
         StartseiteGrid.Visibility = Visibility.Collapsed;

         btnBarcodes.Visibility = Visibility.Collapsed;
      }

      private void btnSchueler_Click(object sender, RoutedEventArgs e)
      {
         btnSchule.Visibility = Visibility.Visible;
         btnSchuleDisabled.Visibility = Visibility.Collapsed;

         btnKlassen.Visibility = Visibility.Visible;
         btnKlassenDisabled.Visibility = Visibility.Collapsed;

         btnSchueler.Visibility = Visibility.Collapsed;
         btnSchuelerDisabled.Visibility = Visibility.Visible;

         btnRunden.Visibility = Visibility.Visible;
         btnRundenDisabled.Visibility = Visibility.Collapsed;

         btnStartseite.Visibility = Visibility.Visible;
         btnStartseiteDisabled.Visibility = Visibility.Collapsed;


         SchuleGrid.Visibility = Visibility.Collapsed;
         KlasseGrid.Visibility = Visibility.Collapsed;
         SchuelerGrid.Visibility = Visibility.Visible;
         RundenGrid.Visibility = Visibility.Collapsed;
         StartseiteGrid.Visibility = Visibility.Collapsed;

         btnBarcodes.Visibility = Visibility.Visible;
      }

      private void btnKlassen_Click(object sender, RoutedEventArgs e)
      {
         btnSchule.Visibility = Visibility.Visible;
         btnSchuleDisabled.Visibility = Visibility.Collapsed;

         btnKlassen.Visibility = Visibility.Collapsed;
         btnKlassenDisabled.Visibility = Visibility.Visible;

         btnSchueler.Visibility = Visibility.Visible;
         btnSchuelerDisabled.Visibility = Visibility.Collapsed;

         btnRunden.Visibility = Visibility.Visible;
         btnRundenDisabled.Visibility = Visibility.Collapsed;

         btnStartseite.Visibility = Visibility.Visible;
         btnStartseiteDisabled.Visibility = Visibility.Collapsed;


         SchuleGrid.Visibility = Visibility.Collapsed;
         KlasseGrid.Visibility = Visibility.Visible;
         SchuelerGrid.Visibility = Visibility.Collapsed;
         RundenGrid.Visibility = Visibility.Collapsed;
         StartseiteGrid.Visibility = Visibility.Collapsed;

         btnBarcodes.Visibility = Visibility.Collapsed;
      }

      private void btnSchule_Click(object sender, RoutedEventArgs e)
      {
         btnSchule.Visibility = Visibility.Collapsed;
         btnSchuleDisabled.Visibility = Visibility.Visible;

         btnKlassen.Visibility = Visibility.Visible;
         btnKlassenDisabled.Visibility = Visibility.Collapsed;

         btnSchueler.Visibility = Visibility.Visible;
         btnSchuelerDisabled.Visibility = Visibility.Collapsed;

         btnRunden.Visibility = Visibility.Visible;
         btnRundenDisabled.Visibility = Visibility.Collapsed;

         btnStartseite.Visibility = Visibility.Visible;
         btnStartseiteDisabled.Visibility = Visibility.Collapsed;


         SchuleGrid.Visibility = Visibility.Visible;
         KlasseGrid.Visibility = Visibility.Collapsed;
         SchuelerGrid.Visibility = Visibility.Collapsed;
         RundenGrid.Visibility = Visibility.Collapsed;
         StartseiteGrid.Visibility = Visibility.Collapsed;

         btnBarcodes.Visibility = Visibility.Collapsed;
      }
   }
}
