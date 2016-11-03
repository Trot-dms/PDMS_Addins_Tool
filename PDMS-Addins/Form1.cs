using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PDMS_Addins
{
    public partial class MainWindow : Form
    {
        //Zawiera publiczny string do folderu PDMSa
        public string pdmsFolder;
        //Flaga do pytania o zapisanie zmian stanu włączenia/wyłączenia addinów
        public bool hasAnythingChanged;
        private int lastIndex;

        public MainWindow()
        {
            InitializeComponent();
            Startup();
        }


        /// <summary>
        /// Metoda do ustawienia wartości początkowych programu
        /// </summary>
        public void Startup()
        {
            turnGadgetsOff();
            statusPDMSfolder.Text=@".\";
            hasAnythingChanged = false;
        }


        /// <summary>
        /// Poniższe 3 metody do ustawiania stanu gadżetów wyboru
        /// </summary>
        private void turnGadgetsOff()
        {
            addinsList.Enabled = false;
            modulesComboBox.Enabled = false;
        }
        private void turnGadgetsOn()
        {
            addinsList.Enabled = true;
            modulesComboBox.Enabled = true;
        }
        private void clearGadgets()
        {
            addinsList.Items.Clear();
            modulesComboBox.Items.Clear();
            addinsOnList.Items.Clear();
            addinsOffList.Items.Clear();
        }


        /// <summary>
        /// Uruchomienie okna wybory folderu wraz z możliwością zmian opcji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pDMSFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Obsługa opcji - później.
            //Zwraca pdmsfolder jako string oraz sprawdza czy istnieje plik addinsenabled.xml w pdmsfolder.
            //Jeżeli nie to znaczy że uruchomiono po raz pierwszy
            //Jeżeli tak to czyta dane i wypełnia listy

        }
        private void setLastIndex()
        {
            lastIndex = modulesComboBox.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //testbutton
            turnGadgetsOn();
            clearGadgets();
            
            pdmsFolder = @"C:\AVEVA\Plant\PDMS12.0.SP4";

            hasAnythingChanged = false;

            Addin addin = new Addin(pdmsFolder);
            foreach (string s in addin.ModuleList)
            {
                modulesComboBox.Items.Add(s);
            }

            modulesComboBox.SelectedIndex = 0;
            setLastIndex();
            
        }

        private void modulesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Zapamiętaj ostatni wybór moduleComboBox
            //setLastIndex();

            if(hasAnythingChanged)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save the changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                { // Zapisz zmiany i kontynuuj
                    MessageBox.Show("Changes were saved.", "Save.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.Cancel)
                { // Nie zapisuj ale i przerwij zmianę
                    hasAnythingChanged = false;
                    modulesComboBox.SelectedIndex = lastIndex;
                    
                }
                else
                {
                    // 
                }
                    
            }
            addinsList.Items.Clear();
            addinsOnList.Items.Clear();
            addinsOffList.Items.Clear();

            Addin addin = new Addin(pdmsFolder);
            string selectedModule = modulesComboBox.Text;
            addin.getAddins(selectedModule);
            foreach(string s in addin.AddinList)
            {
                addinsList.Items.Add(s,true);
                addinsOnList.Items.Add(s);
                
            }
            hasAnythingChanged = false;
            setLastIndex();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //testbutton - write xml
            Addin addin = new Addin(pdmsFolder);
            addin.generateSourceXml(pdmsFolder);
        }

        private void addinsList_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            hasAnythingChanged = true;
        }

        private void turnAddinOn_Click(object sender, EventArgs e)
        {
            if (addinsOnList.SelectedIndex>= 0)
            {
             
                addinsOffList.Items.Add(addinsOnList.Text);
                addinsOnList.Items.RemoveAt(addinsOnList.SelectedIndex);
                if (addinsOnList.Items.Count > 0) addinsOnList.SelectedIndex = 0;

            }


        }

        private void turnAddinOff_Click(object sender, EventArgs e)
        {
            if (addinsOffList.SelectedIndex>=0)
            {
                addinsOnList.Items.Add(addinsOffList.Text);
                addinsOffList.Items.RemoveAt(addinsOffList.SelectedIndex);
                if (addinsOffList.Items.Count > 0) addinsOffList.SelectedIndex = 0;
            }
        }

        private void addinsOnList_SizeChanged(object sender, EventArgs e)
        {
            hasAnythingChanged = true;
        }

        private void addinsOffList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
