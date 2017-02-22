using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Test.Models
{

    public class MojaClass
    {
        public List<Category> lista = new List<Category>();
        public List<Category> lista2 = new List<Category>();

        public void PovuciXML()
        {

            var xmlStr = File.ReadAllText("C:/Users/tihom/OneDrive/Dokumenti/GitHub/test1/Test/Test/App_Data/articles.xml");
            
            var str = XElement.Parse(xmlStr);
            
            var rez = from a in str.Descendants("article").Where(xc=>xc.Element("summary").Value.Contains("Članak1"))
                         select new
                         {
                             naslov = a.Element("title").Value,
                             url = a.Element("url").Value,
                             linkcopy = a.Element("linkcopy").Value
                         };

            XElement str2 = str.XPathSelectElement("/category[2]/article[3]");
            
            Category categ = new Category();

            categ.naslov = str2.Element("title").Value;
            categ.text = str2.Element("summary").Value;
            categ.url = str2.Element("url").Value;
            categ.linkcopy = str2.Element("linkcopy").Value;

            lista2.Add(categ);

            foreach (var v in rez)
            {

                lista.Add(new Category { naslov = v.naslov, url = v.url, linkcopy = v.linkcopy});

            }
           
        }
    }
 
    public class Category
    {
        public string naslov { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string linkcopy { get; set; }
        
    }


}