﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PDMS_Addins
{
    class AddinListManipulation
    {
        
        public List<Addin> AddinList
        {
            get { return addinList; }
            set { addinList = value; }
        }

        public List<Module> ModuleList
        {
            get { return moduleList; }
            set { moduleList = value; }
        }

        private string pdmsFolder;
        private List<Addin> addinList;
        private List<Module> moduleList;

        public AddinListManipulation()
        {
            //bez podania ścieżki do folderu PDMSa użyj ścieżki programu
            this.pdmsFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            this.moduleList = new List<Module>(GetModuleList(pdmsFolder));
            this.addinList = new List<Addin>(GetAddinList(pdmsFolder));
        }

        public AddinListManipulation(string pdmsFolder)
        {
            this.pdmsFolder = pdmsFolder;
            this.moduleList = new List<Module>(GetModuleList(pdmsFolder));
            this.addinList = new List<Addin>(GetAddinList(pdmsFolder));
        }

        private List<Module> GetModuleList(string pdmsFolder)
        {
            List<Module> tempModule = new List<Module>();
            string[] tfiles = Directory.GetFiles(pdmsFolder, "*Addins.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in tfiles)
            {
                Module module = new Module();
                module.ModuleFolder = pdmsFolder;
                module.ModuleName = Path.GetFileName(file);
                tempModule.Add(module);
            }
            return tempModule;
        }

        private List<Addin> GetAddinList(string pdmsFolder)
        {
            List<Addin> addinList = new List<Addin>();

            //tymczasowa lista modułów
            List<Module> tempModule = new List<Module>();
            List<string> tempAddins = new List<string>();

            tempModule.AddRange(GetModuleList(pdmsFolder));

            foreach(Module m in tempModule)
            {
                tempAddins.Clear();
                tempAddins.AddRange(getAddinsForModule(m.ModuleName));
                foreach (string item in tempAddins)
                {
                    Addin addin = new Addin();
                    addin.AddinFolder = pdmsFolder;
                    addin.AddinModule = m;
                    addin.AddinName = item;
                    addin.AddinState = true; //skoro wczytujemy go z plików to znaczy że jest włączony (true)
                    addinList.Add(addin);
                }
            }
            return addinList;
        }

        private List<string> getAddinsForModule(string module)
        {
            List<string> addinList = new List<string>();

            using (XmlReader reader = XmlReader.Create(pdmsFolder + @"\" + module))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "string":
                                if (reader.Read())
                                {
                                    addinList.Add(reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }
            return addinList;
        }

        public void saveAddinsToXML(List<string> addins, string module)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement rootNode = xmlDoc.CreateElement("ArrayOfString");
            rootNode.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            rootNode.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");

            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
            xmlDoc.AppendChild(rootNode);
            foreach(string item in addins)
            {
                XmlElement addinNode = xmlDoc.CreateElement("string");
                XmlText addinText = xmlDoc.CreateTextNode(item);
                rootNode.AppendChild(addinNode);
                addinNode.AppendChild(addinText);
            }
            xmlDoc.Save(pdmsFolder + @"/" + module);
                
        }
    }
}
