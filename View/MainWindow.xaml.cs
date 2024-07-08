﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Klimalauf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;

            // Check if first name and last name are provided
            if (ValidateInputs())
            {
                // Check admin password
                string adminPassword = AdminPasswordBox.Password;
                bool isAdmin = adminPassword == "test" && firstName == "admin" && lastName == "admin";

                Scanner scanner = new Scanner(firstName, lastName, isAdmin);
                scanner.Show();
                this.Close();

                //if (isAdmin)
                //{
                //   // Open admin panel window
                //   AdminScanner adminPanel = new AdminScanner(firstName, lastName);
                //   adminPanel.Show();
                //   this.Close();
                //}
                //else
                //{
                //   // Open admin panel window
                //   Scanner panel = new Scanner(firstName, lastName);
                //   panel.Show();
                //   this.Close();
                //}
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || FirstNameTextBox.Text == "Max")
            {
                SetInvalidInputStyle(FirstNameTextBox);
                isValid = false;
            }
            else
            {
                SetValidInputStyle(FirstNameTextBox);
            }

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) || LastNameTextBox.Text == "Mustermann")
            {
                SetInvalidInputStyle(LastNameTextBox);
                isValid = false;
            }
            else
            {
                SetValidInputStyle(LastNameTextBox);
            }

            return isValid;
        }

        private void SetInvalidInputStyle(TextBox textBox)
        {
         textBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C1121C"));
         textBox.Foreground = new SolidColorBrush(Colors.White);
      }

        private void SetValidInputStyle(TextBox textBox)
        {
         textBox.Background = new SolidColorBrush(Colors.White);
         textBox.Foreground = new SolidColorBrush(Colors.Blue);
      }

        private void FirstNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Max")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Blue);
            }
            SetValidInputStyle(textBox);
        }

        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Max";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
            ValidateInputs();
        }

        private void LastNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Mustermann")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Blue);
            }
            SetValidInputStyle(textBox);
        }

        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Mustermann";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
            ValidateInputs();
        }

      private void TextBox_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.Enter)
         {
            TextBox textBox = (TextBox)sender;
            textBox.Background = new SolidColorBrush(Colors.White);
            textBox.Foreground = new SolidColorBrush(Colors.Blue);

            // Check if inputs are valid
            if (ValidateInputs())
            {
               // Perform login action
               LoginButton_Click(sender, e);



            }
         }
      }

      private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         TextBox textBox = (TextBox)sender;
         textBox.Background = new SolidColorBrush(Colors.White);
         textBox.Foreground = new SolidColorBrush(Colors.Blue);
      }

      private void FirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         TextBox textBox = (TextBox)sender;
         textBox.Background = new SolidColorBrush(Colors.White);
         textBox.Foreground = new SolidColorBrush(Colors.Blue);
      }
   }
}
