using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WpfApp1.Data;

namespace WpfApp1.DAO
{
    public sealed class Document
    {
        public static string SAVE_PATH = "d:\\Profiles\\cdelcroix\\Documents\\";
        private static Document instance = null;

        public XmlDocument XmlTree;

        public Document()
        {
            XmlTree = new XmlDocument();
            XmlNode rootNode = XmlTree.CreateElement("Observations");
            XmlTree.AppendChild(rootNode);
        }

        public static Document Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Document();
                }
                return instance;
            }
        }

        public void SaveDocument()
        {
            //Mapper


            XmlHelper.ToXmlFile(XmlTree, SAVE_PATH);
        }
    }
}
