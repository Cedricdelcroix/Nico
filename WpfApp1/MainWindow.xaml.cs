using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.DAO;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox textBox = new TextBox() { Text = "", MaxWidth = 250 ,Width = 250};

            this.Xml = new ObservableCollection<Observation>(); // ou chargement XML

            this.Xml.Add(new Observation() {Text = "Test obs" });
            this.observation.ItemsSource = this.Xml;
            //this.Tmp = new ObservableCollection<Observation>();
        }

        //public List<Observation> Xml { get; set; }
        public ObservableCollection<Observation> Xml { get; set; }

        private void BtnOnClick(object sender, RoutedEventArgs e)
        {
            Observation obs = new Observation();
          //  this.observation.ItemsSource = this.Xml;
            this.Xml.Add(obs);
            Document.Instance.SaveDocument();      
        }

    }
}