﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace RunTrack.View
{
    /// <summary>
    /// Interaktionslogik für AdminVerwalten.xaml
    /// </summary>
    public partial class AdminVerwalten : Page
    {
        private MainModel _pmodel;
        public AdminVerwalten()
        {
            InitializeComponent();

            _pmodel = FindResource("pmodel") as MainModel ?? new MainModel();

            LoadContent();
        }

        private void LoadContent()
        {
            using (var db = new LaufDBContext())
            {
                var sortedUser = db.Benutzer.OrderBy(r => r.Id).ToList();
                int rowIndex = 0;

                foreach (Benutzer benutzer in sortedUser)
                {
                    // Zeilen hinzufügen
                    GridSettings.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                    Label label = new()
                    {
                        Content = benutzer.Id,
                        FontSize = 14,
                        MinWidth = 25,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(0, 1.5, 0, 2.5)
                    };
                    Grid.SetRow(label, rowIndex);
                    Grid.SetColumn(label, 0);
                    GridSettings.Children.Add(label);

                    Label labelSpacer = new()
                    {
                        Content = "→",
                        FontSize = 14,
                        Width = 25,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(0, 1.5, 8, 2.5)
                    };
                    Grid.SetRow(labelSpacer, rowIndex);
                    Grid.SetColumn(labelSpacer, 1);
                    GridSettings.Children.Add(labelSpacer);

                    Label label2 = new()
                    {
                        Content = benutzer.Vorname,
                        FontSize = 14,
                        MinWidth = 100,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(0, 1.5, 0, 2.5)
                    };

                    Grid.SetRow(label2, rowIndex);
                    Grid.SetColumn(label2, 2);
                    GridSettings.Children.Add(label2);

                    Label labelSeconds = new()
                    {
                        Content = benutzer.Nachname,
                        FontSize = 14,
                        MinWidth = 100,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(0, 1.5, 0, 2.5)
                    };
                    Grid.SetRow(labelSeconds, rowIndex);
                    Grid.SetColumn(labelSeconds, 3);
                    GridSettings.Children.Add(labelSeconds);

                    // Löschen
                    Button deleteButton = new()
                    {
                        Content = "🗑️",
                        FontSize = 12,
                        Width = 25,
                        Height = 25,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(30, 1.5, 5, 2.5),
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4F8F4")),
                        ToolTip = "Löschen",
                    };
                    deleteButton.Click += DeleteButton_Click;

                    Grid.SetRow(deleteButton, rowIndex);
                    Grid.SetColumn(deleteButton, 4);
                    GridSettings.Children.Add(deleteButton);

                    // Einstellungen
                    Button optionsButton = new()
                    {
                        Content = "⚙️",
                        FontSize = 12,
                        Width = 25,
                        Height = 25,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(0, 1.5, 10, 2.5),
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4F8F4")),
                        ToolTip = "Einstellungen",
                    };
                    optionsButton.Click += OptionsButton_Click;

                    Grid.SetRow(optionsButton, rowIndex);
                    Grid.SetColumn(optionsButton, 5);
                    GridSettings.Children.Add(optionsButton);

                    rowIndex++;

                    // Add Rectangle only between rows, except after the last row
                    if (rowIndex < sortedUser.Count)
                    {
                        Rectangle rect = new()
                        {
                            Height = 1,
                            Fill = new SolidColorBrush(Colors.Gray),
                            Margin = new Thickness(0, 0, 5, 35.5)
                        };

                        Grid.SetRow(rect, rowIndex);
                        Grid.SetColumnSpan(rect, 6);
                        GridSettings.Children.Add(rect);
                    }
                }
            }
        }


        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void IntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
        }

        //private void AddButton_Click(object sender, RoutedEventArgs e)
        //{
        //}

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            _pmodel.Navigate(new Scanner());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
