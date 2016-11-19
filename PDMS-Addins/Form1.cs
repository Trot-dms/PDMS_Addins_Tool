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
    /// <summary>
    /// Main window
    /// </summary>
    public partial class MainWindow : Form
    {
        #region Fields
        /// <summary>
        /// Public string for storing path to PDMS folder
        /// </summary>
        public string pdmsFolder;
        /// <summary>
        /// Public flag for notify if something was changed eg. turn on or off addin
        /// </summary>
        public bool hasAnythingChanged;
        /// <summary>
        /// Private int for last Index in checked list box - AddinList
        /// </summary>
        private int lastIndex;
        /// <summary>
        /// Main list with addins.
        /// </summary>
        private AddinListManipulation addinList;
        /// <summary>
        /// Single addin object list
        /// </summary>
        private List<Addin> addins;
        /// <summary>
        /// Single module object list
        /// </summary>
        private List<Module> modules;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Startup();
        }
        
        /// <summary>
        /// Method for setting up defaults eg. turning gadgets off until path is set
        /// </summary>
        public void Startup()
        {
            turnGadgetsOff();
            statusPDMSfolder.Text = @".\";
            hasAnythingChanged = false;
        }
        
        /// <summary>
        /// Method for setting gadgets off - addinList and modulesCombobox
        /// </summary>
        private void turnGadgetsOff()
        {
            modulesComboBox.Enabled = false;
        }
        
        /// <summary>
        /// Method for setting gadgets on - addinList and modulesCombobox
        /// </summary>
        private void turnGadgetsOn()
        {
            modulesComboBox.Enabled = true;
        }
        
        /// <summary>
        /// Method for clearing all data from gadgets
        /// </summary>
        private void clearGadgets()
        {
            modulesComboBox.Items.Clear();
            addinsOnList.Items.Clear();
            addinsOffList.Items.Clear();
        }
        
        // TODO: Implement all logic for options
        /// <summary>
        /// Menu strip implementation
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
        
        /// <summary>
        /// Method for setting last index in the list if nothing was changed
        /// </summary>
        private void setLastIndex()
        {
            lastIndex = modulesComboBox.SelectedIndex;
        }
        
        // TODO: Delete test button later
        /// <summary>
        /// Test button for setting pdmsFolder
        /// To be deleted later
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            turnGadgetsOn();
            clearGadgets();
            pdmsFolder = @"X:\Dokumenty\Visual Studio 2015\Projects\PDMS12";
            addinList = new AddinListManipulation(pdmsFolder);
            addins = new List<Addin>(addinList.AddinList);
            modules = new List<Module>(addinList.ModuleList);
            hasAnythingChanged = false;
            foreach (Module s in modules)
            {
                modulesComboBox.Items.Add(s.ModuleName);
            }
            modulesComboBox.SelectedIndex = 0;
            setLastIndex();
        }
        
        /// <summary>
        /// Method for changing module in combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modulesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Zapamiętaj ostatni wybór moduleComboBox
            //setLastIndex();
            if (hasAnythingChanged)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save the changes?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                { // TODO: Zapisz zmiany i kontynuuj
                    MessageBox.Show("Changes were saved.", "Save.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.Cancel)
                { // TODO: Nie zapisuj ale i przerwij zmianę
                    hasAnythingChanged = false;
                    modulesComboBox.SelectedIndex = lastIndex;
                }
                else
                {
                    // TODO: Jeżeli nie będzie ani OK ani CANCEL
                }
            }
            fillLists();
            hasAnythingChanged = false;
            setLastIndex();
        }
       
        /// <summary>
        /// Method that fills both form lists with addins. Clear lists first.
        /// </summary>
        private void fillLists()
        {
            addinsOnList.Items.Clear();
            addinsOffList.Items.Clear();
            addins = new List<Addin>(addinList.AddinList);
            string selModule = modulesComboBox.Text;
            foreach (Addin item in addins)
            {
                //string selModule = modulesComboBox.Text;
                if (item.AddinModule.ModuleName == selModule)
                {
                    if(item.AddinState) addinsOnList.Items.Add(item.AddinName);
                    else addinsOffList.Items.Add(item.AddinName);
                }
            }
        }
       
        // TODO: Delete test button later
        /// <summary>
        /// Test button2 - save xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            string module = modulesComboBox.Text;
            List<string> addins = new List<string>(addinsOnList.Items.Cast<string>().ToList());
            List<string> addinsOff = new List<string>(addinsOffList.Items.Cast<string>().ToList());
            addinList.saveAddinsToXML(addins, module);
            addinList.saveAddinsToXML(addinsOff, module + "_off");
        }

        private void changeAddinState(string addinName)
        {
            addins = new List<Addin>(addinList.AddinList);
                string selModule = modulesComboBox.Text;
                var i = addinList.AddinList.FindIndex(x => (x.AddinName == addinName) && (x.AddinModule.ModuleName==selModule));
                if (addinList.AddinList[i].AddinState)
                    addinList.AddinList[i].AddinState = false;
                else
                    addinList.AddinList[i].AddinState = true;
        }   
           
        /// <summary>
        /// Move addin from On list to Off list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void turnAddinOn_Click(object sender, EventArgs e)
        {
            if (addinsOnList.SelectedIndex >= 0)
            {
                changeAddinState(addinsOnList.Text);
                fillLists();
                if (addinsOnList.Items.Count > 0) addinsOnList.SelectedIndex = 0;
                //TODO obsługa undo - z tym poniżej.
                //hasAnythingChanged = true;
            }
        }

        /// <summary>
        /// Move addin from Off list to On list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void turnAddinOff_Click(object sender, EventArgs e)
        {
            if (addinsOffList.SelectedIndex >= 0)
            {
                changeAddinState(addinsOffList.Text);
                fillLists();
                if (addinsOffList.Items.Count > 0) addinsOffList.SelectedIndex = 0;
                //TODO obsługa undo - z tym poniżej.
                //hasAnythingChanged = true;
            }
        }

        /// <summary>
        /// Set flag when size of list changes (added or removed items)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addinsOnList_SizeChanged(object sender, EventArgs e)
        {
            hasAnythingChanged = true;
        }

   
    }
}
