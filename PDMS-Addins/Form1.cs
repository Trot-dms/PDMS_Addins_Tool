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

        //private Addin addin;
        private AddinListManipulation addinList;
        private List<Addin> addins;
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
            //addinsList.Enabled = false;
            modulesComboBox.Enabled = false;
        }
        /// <summary>
        /// Method for setting gadgets on - addinList and modulesCombobox
        /// </summary>
        private void turnGadgetsOn()
        {
            //addinsList.Enabled = true;
            modulesComboBox.Enabled = true;
        }
        /// <summary>
        /// Method for clearing all data from gadgets
        /// </summary>
        private void clearGadgets()
        {
           // addinsList.Items.Clear();
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

        //private List<string> GetModuleList(Addin_ addin)
        //{
        //    List<string> modules = new List<string>();
        //    foreach(KeyValuePair<string, List<string>> s in addin.MainList)
        //    {
        //        modules.Add(s.Key);
        //    }
        //    return modules;
           
        //}

        //private List<string> GetAddinList(Addin_ addin,string module)
        //{

        //    List<string> addins = new List<string>();

        //    addins = addin.MainList.SelectMany(d => d.Value).ToList();
        //    return addins;
            
        //}

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

            pdmsFolder = @"C:\AVEVA\Plant\PDMS12.0.SP4";

            addinList = new AddinListManipulation(pdmsFolder);
            addins = new List<Addin>(addinList.AddinList);

            hasAnythingChanged = false;
            modules = new List<Module>(addinList.ModuleList);


            //Addin_ addin = new Addin_(pdmsFolder);
            //List<string> modules = new List<string>(GetModuleList(addin));

            foreach (Module s in modules)
            {
                modulesComboBox.Items.Add(s.ModuleName);
            }

            modulesComboBox.SelectedIndex = 0;
            setLastIndex();
            //Dictionary<string, List<string>> test = new Dictionary<string, List<string>>(addin.MainList);
          
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
            //addinsList.Items.Clear();
            addinsOnList.Items.Clear();
            addinsOffList.Items.Clear();

            addinList = new AddinListManipulation(pdmsFolder);
            addins = new List<Addin>(addinList.AddinList);        
           
            foreach(Addin item in addins)
            {
                string selModule = modulesComboBox.Text;
                if (item.AddinModule.ModuleName==selModule && item.AddinState==true)
                {
                    addinsOnList.Items.Add(item.AddinName);
                } 
                else if (item.AddinModule.ModuleName == selModule && item.AddinState == false)
                {
                    addinsOffList.Items.Add(item.AddinName);
                }
            }
            //Addin_ addin = new Addin_(pdmsFolder);
            //string selectedModule = modulesComboBox.Text;
            //List<string> addins = new List<string>(GetAddinList(addin, selectedModule));

            ////addin.getAddins(selectedModule);
            //foreach (string s in addins)
            //{
            //    addinsList.Items.Add(s, true);
            //    addinsOnList.Items.Add(s);

            //}
            hasAnythingChanged = false;
            setLastIndex();

        }

        // TODO: Delete test button later
        /// <summary>
        /// Test button2 - save xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            //Addin addin = new Addin(pdmsFolder);
            //addin.generateSourceXml(pdmsFolder);
        }

        /// <summary>
        /// Set flag when addinsList item is checked - will be deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addinsList_ItemCheck(Object sender, ItemCheckEventArgs e)
        {
            hasAnythingChanged = true;
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

                addinsOffList.Items.Add(addinsOnList.Text);
                addinsOnList.Items.RemoveAt(addinsOnList.SelectedIndex);
                if (addinsOnList.Items.Count > 0) addinsOnList.SelectedIndex = 0;

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
                addinsOnList.Items.Add(addinsOffList.Text);
                addinsOffList.Items.RemoveAt(addinsOffList.SelectedIndex);
                if (addinsOffList.Items.Count > 0) addinsOffList.SelectedIndex = 0;
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

        private void addinsOffList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
