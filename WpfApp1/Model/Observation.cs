using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WpfApp1.DAO;
using WpfApp1.Data;

namespace WpfApp1.Model
{
    public class Observation
    {
        public String Text { get; set; }

        public List<Objectif> objectifs;

        public void setObservation(string observation)
        {
            Document doc = Document.Instance;
            XmlNodeList obsList = doc.XmlTree.GetElementsByTagName("Observation");
            if (!SearchInNode(observation, obsList))
            {
                XmlNode rootNode = doc.XmlTree.CreateElement(XmlHelper.ToXml(this));
                doc.XmlTree.AppendChild(rootNode);
            }
        }

        public static Boolean SearchInNode(string search, XmlNodeList nodeList)
        {
            foreach (XmlNode node in nodeList)
            {
                if (((Observation)XmlHelper.FromXml(node.ToString(), "Observation")).Text == search)
                {
                    return true;
                }
            }
            return false;
        }

        public void Save()
        {
            //Mapper.
        }
    }      
}