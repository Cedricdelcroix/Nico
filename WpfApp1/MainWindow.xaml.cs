using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
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
            Document document = Document.Instance;
            List<Observation> observations = GetObservations();        
            this.comboObservableObservation = new ObservableCollection<Observation>();
            foreach(Observation obs in observations)
            {
                this.comboObservableObservation.Add(obs);
            }
            this.___ComboBoxObservation_.ItemsSource = this.comboObservableObservation;            
            //this.Tmp = new ObservableCollection<Observation>();
        }

        //public List<Observation> Xml { get; set; }
        public ObservableCollection<Observation> comboObservableObservation { get; set; }

        public ObservableCollection<Objectif> comboObservableObjectif { get; set; }

        public ObservableCollection<Moyen> comboObservableMoyen { get; set; }

        private void BtnOnClick(object sender, RoutedEventArgs e)
        {
          //  this.observation.ItemsSource = this.Xml;            
            Document.Instance.SaveDocument();      
        }   
        
        private List<Observation> GetObservations()
        {
            List<Observation> listObservation = new List<Observation>();
            List<Objectif> listObjectif = new List<Objectif>();
            List<Moyen> listMoyens = new List<Moyen>();
            Document doc = Document.Instance;
            XmlNodeList objList = doc.XmlTree.GetElementsByTagName("Observation");
            foreach(XmlNode nodeObservation in objList)
            {
                foreach(XmlNode nodeObjectif in nodeObservation.SelectNodes("Objectif")){
                    foreach(XmlNode nodeMoyen in nodeObjectif.SelectNodes("Moyen"))
                    {
                        listMoyens.Add(new Moyen(nodeMoyen.Attributes["text"].Value, nodeMoyen.Attributes["weight"].Value ));
                    }
                    listObjectif.Add(new Objectif(nodeObjectif.Attributes["text"].Value, nodeObjectif.Attributes["weight"].Value, listMoyens));
                    listMoyens = new List<Moyen>();
                }
                listObservation.Add(new Observation(nodeObservation.Attributes["text"].Value, listObjectif));                
                listObjectif = new List<Objectif>();
            }
            return listObservation;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }    
}