using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WpfApp1.DAO;
using WpfApp1.Data;

namespace WpfApp1.Model
{
    public class Objectif
    {
        public String Text { get; set; }

        public List<Moyen> moyens;

        public int Weight { get; set; }

        public void setObjectif(string objectif, string observation)
        {
            Document doc = Document.Instance;
            XmlNodeList obsList = doc.XmlTree.GetElementsByTagName("Observation");
            if (!SearchInNode(objectif, obsList,observation))
            {
                XmlNode rootNode = doc.XmlTree.CreateElement(XmlHelper.ToXml(this));
                doc.XmlTree.AppendChild(rootNode);
            }
        }

        public static Boolean SearchInNode(string search, XmlNodeList nodeList, string observation)
        {
            foreach (XmlNode ObservationNode in nodeList)
            {
                if (((Observation)XmlHelper.FromXml(ObservationNode.ToString(), "Observation")).Text == observation)
                {
                    foreach (XmlNode node in ObservationNode.ChildNodes)
                    {
                        if (((Observation)XmlHelper.FromXml(node.ToString(), "Observation")).Text == observation)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
