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
        private static Document instance = null;

        private const string FILE_PATH = "c:\\kine\\document.xml";

        public XmlDocument XmlTree;

        public Document()
        {
            if (ReadDocument() != null) {
                XmlTree = ReadDocument();
            }else{
                XmlTree = new XmlDocument();
                 XmlNode rootNode = XmlTree.CreateNode("element", "App", "");
                 XmlTree.AppendChild(rootNode);                
                SaveDocument();
            }           
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
            XmlHelper.ToXmlFile(XmlTree, FILE_PATH);
        }

        //read the document Function

        public XmlDocument ReadDocument()
        {
            try{
                XmlDocument doc = new XmlDocument();
                doc.Load(FILE_PATH);
                return doc;               
            }catch(Exception e){
                return null;        
            }
        }       
    }
}
