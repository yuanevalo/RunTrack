﻿using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Klimalauf
{
   public partial class Scanner : Window
   {
      private MainViewModel mvmodel;
      private StringBuilder barcodeInput = new StringBuilder();
      private string firstName;
      private string lastName;
      private bool isAdmin;
      private DispatcherTimer timer;

      public Scanner(string firstName, string lastName, bool isAdmin)
      {
         InitializeComponent();

         // Set the ScannerName label with the passed names
         ScannerName.Content = $"{lastName}, {firstName}";
         DataContext = this;
         this.firstName = firstName;
         this.lastName = lastName;
         this.isAdmin = isAdmin;

         // Initialize and configure the timer
         timer = new DispatcherTimer();
         timer.Interval = TimeSpan.FromSeconds(3); // Adjust the time as needed
         timer.Tick += Timer_Tick;
      }

      private void Timer_Tick(object sender, EventArgs e)
      {
         // Timer elapsed, hide both BoxTrue and BoxFalse
         HideStatusBoxes();
         timer.Stop();
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         this.mvmodel = FindResource("mvmodel") as MainViewModel;
         if (this.isAdmin)
         {
            this.lblAdmin.Visibility = Visibility.Visible;
            this.borderAdmin.Visibility = Visibility.Visible;

            lstlastScan.Margin = new Thickness(lstlastScan.Margin.Left, lstlastScan.Margin.Top, lstlastScan.Margin.Right, 100);

            btnUebersicht.Click += (sender, e) =>
            {
               Datenuebersicht datenPanel = new Datenuebersicht(firstName, lastName);
               datenPanel.Show();
               this.Close();
            };

            btnEinstellung.Click += (sender, e) =>
            {
               Einstellungen optionsPanel = new Einstellungen(firstName, lastName);
               optionsPanel.Show();
               this.Close();
            };

            btnDateien.Click += (sender, e) =>
            {
               Dateiverwaltung dataPanel = new Dateiverwaltung(firstName, lastName);
               dataPanel.Show();
               this.Close();
            };
         }
         else
         {
            this.lblAdmin.Visibility = Visibility.Hidden;
            this.borderAdmin.Visibility = Visibility.Hidden;
         }
      }

      private void LogoutButton_Click(object sender, RoutedEventArgs e)
      {
         MainWindow mainWindow = new MainWindow();
         mainWindow.Show();
         this.Close();
      }

      private void LogoutIcon_MouseDown(object sender, MouseButtonEventArgs e)
      {
         MainWindow mainWindow = new MainWindow();
         mainWindow.Show();
         this.Close();
      }

      private void AddScannedData(int id)
      {
         using (var db = new LaufDBContext())
         {
            Schueler schueler = db.Schueler.Find(id);
            if (schueler == null)
            {
               this.BoxTrue.Visibility = Visibility.Collapsed;
               this.BoxFalse.Visibility = Visibility.Visible;

               // Start fade-in animation for BoxFalse
               Storyboard sb = FindResource("ShowBoxFalse") as Storyboard;
               sb.Begin(BoxFalse);

               // Start timer to hide status boxes after a delay
               StartHideTimer();
            }
            else
            {
               this.BoxFalse.Visibility = Visibility.Collapsed;
               this.BoxTrue.Visibility = Visibility.Visible;

               // Start fade-in animation for BoxTrue
               Storyboard sb = FindResource("ShowBoxTrue") as Storyboard;
               sb.Begin(BoxTrue);

               Runde runde = new Runde();
               runde.Schueler = schueler;
               runde.Zeitstempel = DateTime.Now;
               runde.BenutzerName = $"{firstName} {lastName}";
               db.Runden.Add(runde);
               db.SaveChanges();
               mvmodel.LstRunden.Add(runde);
               mvmodel.LstLetzteRunde.Add(runde);

               // Start timer to hide status boxes after a delay
               StartHideTimer();
            }
         }
      }

      private void StartHideTimer()
      {
         // Restart timer
         timer.Stop();
         timer.Start();
      }

      private void HideStatusBoxes()
      {
         // Hide both BoxTrue and BoxFalse
         this.BoxTrue.Visibility = Visibility.Collapsed;
         this.BoxFalse.Visibility = Visibility.Collapsed;
      }

      private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter)
         {
            string scannedData = barcodeInput.ToString().Trim();
            if (!string.IsNullOrEmpty(scannedData))
            {
               try
               {
                  int scannedDataInt = int.Parse(scannedData);
                  AddScannedData(scannedDataInt);
               }
               catch (FormatException)
               {
                  Console.WriteLine("Ungültige Eingabe. Der String konnte nicht in eine Zahl umgewandelt werden.");
               }
               finally
               {
                  barcodeInput.Clear();
               }
            }
         }
         else
         {
            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            barcodeInput.Append(c);
         }
      }
   }
}
