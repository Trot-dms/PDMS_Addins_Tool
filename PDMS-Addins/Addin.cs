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

        /// <summary>
        /// Właściwości widoczne dla tworzonego obiektu
        /// </summary>
        public List<string> ModuleList { get; set; }
        public List<string> AddinList { get; set; }
        public string PDMSfolder { get; set; }


        /// <summary>
        /// Prywatne pola do zarządzania danymi wewnątrz obiektu
        /// addinList - przechowuje listę addinów dla danego modułu
        /// moduleList - przechowuje listę modułów występujących w folderze PDMSa
        /// </summary>
        private List<string> addinList = new List<string>();
        private List<string> moduleList = new List<string>();
        private string pdmsFolder;


        /// <summary>
        /// Domyślny konstruktor z podaniem ścieżki do PDMSa
        /// </summary>
        /// <param name="pdmsFolder">Ścieżka do PDMSa</param>
        public Addin(string pdmsFolder)
        {
            this.pdmsFolder = pdmsFolder;
            getModulesFromPDMS();
            ModuleList = moduleList;
        }


        /// <summary>
        /// Konstruktor bez podania ścieżki, przyjmuje folder uruchomienia exe jako folder PDMSa
        /// </summary>
        public Addin()
        {
            pdmsFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            getModulesFromPDMS();
            ModuleList = moduleList;
        }


        /// <summary>
        /// Czyści listę modułów i wyszukuje w folderze PDMSa wszystkich modułów - plików xml
        /// </summary>
        private void getModulesFromPDMS()
        {
            moduleList.Clear();
            string[] tfiles = Directory.GetFiles(pdmsFolder, "*Addins.xml", SearchOption.TopDirectoryOnly);
            foreach (string file in tfiles) moduleList.Add(Path.GetFileName(file));
        }


        /// <summary>
        /// Czyści listę addinów i dla danego modułu (pliku xml) odczytuje z pliku xml dostępne addiny
        /// </summary>
        /// <param name="module">Aktualny moduł z którego mamy pobrać nazwy addinów</param>
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
        /// Metoda publiczna do przekazania addinów z danego modułu do właściwości i na zewnątrz
        /// </summary>
        /// <param name="module">Aktualny moduł dla którego pobrane będa addiny</param>
        public void getAddins(string module)
        {
            getAddinsForModule(module);
            AddinList = addinList;
        }

        /// <summary>
        /// Generuje plik xml ze wszystkimi modułami i addinami podczas pierwszego uruchomienia aplikacji.
        /// Program operuje cały czas na tym pliku. Po kliknięciu save zmiany z pliku xml są zapisywane w
        /// poszczególnych plikach modułów.
        /// </summary>
        /// <param name="xmlPath">Ścieżka do zapisu pliku - zalecane pdmsfolder</param>
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
