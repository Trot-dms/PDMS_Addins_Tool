using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace PDMS_Addins
{
    class Addin
    {
        #region Fields and properities
        /// <summary>
        /// Properities
        /// </summary>
        public List<string> ModuleList { get; set; }
        public List<string> AddinList { get; set; }
        public string PDMSfolder { get; set; }


        /// <summary>
        /// Private lists for storing data
        /// <param name="addinList">For storing addins for selected module</param>
        /// <param name="moduleList">For storing module list from PDMS</param>
        /// </summary>
        private List<string> addinList = new List<string>();
        private List<string> moduleList = new List<string>();
        private string pdmsFolder;
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="pdmsFolder">Path to PDMS folder</param>
        public Addin(string pdmsFolder)
        {
            this.pdmsFolder = pdmsFolder;
            getModulesFromPDMS();
            ModuleList = moduleList;
        }


        /// <summary>
        /// Constructor without path gets default application path
        /// </summary>
        public Addin()
        {
            pdmsFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            getModulesFromPDMS();
            ModuleList = moduleList;
        }


        /// <summary>
        /// Clear all module list and search for xml files (modules) in PDMS folder
        /// </summary>
        private void getModulesFromPDMS()
        {
            moduleList.Clear();
            string[] tfiles = Directory.GetFiles(pdmsFolder, "*Addins.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in tfiles) moduleList.Add(Path.GetFileName(file));
        }


        /// <summary>
        /// Clear addin list and read from module xml file all addins 
        /// </summary>
        /// <param name="module">Actual module</param>
        private void getAddinsForModule(string module)
        {
            addinList.Clear();
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
        }


        /// <summary>
        /// Puts addins from module xml to addin list
        /// </summary>
        /// <param name="module">Actual module</param>
        public void getAddins(string module)
        {
            getAddinsForModule(module);
            AddinList = addinList;
        }

        /// <summary>
        /// Generate xml file with all modules and addins and their state
        /// This file is genereted only with first run of application
        /// This application is working mainly on this xml file
        /// </summary>
        /// <param name="xmlPath">Path for xml file - reccomended pdmsfolder</param>
        public void generateSourceXml(string xmlPath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(xmlPath + @"\addinsEnabled.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Modules");
                writer.WriteElementString("Path", pdmsFolder);

                foreach (string s in moduleList)
                {
                    writer.WriteStartElement(s);
                    getAddins(s);
                    foreach (string t in addinList)
                    {
                        writer.WriteStartElement(t);
                        writer.WriteElementString("Enabled", "true");
                        writer.WriteElementString("Path", pdmsFolder);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

    }

}
