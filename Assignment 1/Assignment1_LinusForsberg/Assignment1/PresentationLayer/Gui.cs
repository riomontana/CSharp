using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Gui : Form
    {
        private int id = 1;
        private List<string> typeList;
        private List<string> attributeList;
        private EstateManager estateManager = new EstateManager();
        private string fileName;
        private bool fileIsSaved = false;
        private BindingSource categoryBinding = new BindingSource();
        private BindingSource countriesBinding = new BindingSource();
        private Estate selectedEstate;
        private int selectedEstateIndex;
        private List<Countries> countryList = Enum.GetValues(typeof(Countries)).Cast<Countries>().ToList();
        private string selectedCountry, selectedCategory, selectedType, selectedLegalForm, selectedStreet,
                        selectedZipCode, selectedCity, selectedUniqueAttr, strAttribute;
        private bool estateIsEdited = false;
        private bool typeIsSelected = false;
        private DataController dataController = new DataController();

        // Constructor
        public Gui()
        {
            CenterToScreen();
            InitializeComponent();
            countriesBinding.DataSource = countryList;
            listBoxAddCountry.DataSource = countriesBinding;
            listBoxViewEstates.DataSource = estateManager.ToStringList();
        }

        // Resets gui fields to default values
        private void ClearGuiFields()
        {
            dropDownAddCategory.Text = "Category";
            dropDownAddType.Text = "Type";
            dropDownAddLegalForm.Text = "Legal form";
            dropDownUnique.Text = "Unique Attribute";
            textBoxAddCity.Text = "City";
            textBoxAddStreet.Text = "Street";
            textBoxAddZipCode.Text = "Zip code";
            listBoxAddCountry.SelectedIndex = 0;
            labelEditEstate.Text = "";
            typeIsSelected = false;
        }

        // Checks if all needed input is present for creating an estate object
        private bool CheckInputFields()
        {
            if ((dropDownAddCategory.Text == "" || dropDownAddCategory.Text == "Category") ||
                (dropDownAddType.Text == "" || dropDownAddType.Text == "Type") ||
                (dropDownAddLegalForm.Text == "" || dropDownAddLegalForm.Text == "Legal form") ||
                (dropDownUnique.Text == "" || dropDownUnique.Text == "Unique attribute") ||
                (textBoxAddCity.Text == "" || textBoxAddCity.Text == "City") ||
                (textBoxAddStreet.Text == "" || textBoxAddStreet.Text == "Street") ||
                (textBoxAddZipCode.Text == "" || textBoxAddZipCode.Text == "Zip code"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Adds new estate to list
        private void AddEstate(Address address)
        {
            switch (selectedType)
            {
                case "Shop":
                    estateManager.Add(new Shop(id, selectedCategory, selectedType, 
                        selectedLegalForm, address, selectedUniqueAttr));
                    break;
                case "Warehouse":
                    estateManager.Add(new Warehouse(id, selectedCategory, selectedType,
                        selectedLegalForm, address, selectedUniqueAttr));
                    break;
                case "House":
                    estateManager.Add(new House(id, selectedCategory, selectedType,
                        selectedLegalForm, address, selectedUniqueAttr));
                    break;
                case "Villa":
                    estateManager.Add(new Villa(id, selectedCategory, selectedType,
                        selectedLegalForm, address, selectedUniqueAttr));
                    break;
                case "Apartment":
                    estateManager.Add(new Apartment(id, selectedCategory, selectedType,
                        selectedLegalForm, address, selectedUniqueAttr));
                    break;
                case "Townhouse":
                    estateManager.Add(new Townhouse(id, selectedCategory, selectedType,
                        selectedLegalForm, address, selectedUniqueAttr));
                    break;
            }
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            id++;
        }

        // Edits estate object
        private void EditEstate(Address address)
        {
            switch (selectedType)
            {
                case "Shop":
                    estateManager.ChangeAt(new Shop(selectedEstate.Id, selectedCategory,
                        selectedType, selectedLegalForm, address, selectedUniqueAttr),
                        selectedEstateIndex);
                    break;
                case "Warehouse":
                    estateManager.ChangeAt(new Warehouse(selectedEstate.Id, selectedCategory,
                        selectedType, selectedLegalForm, address, selectedUniqueAttr),
                        selectedEstateIndex);
                    break;
                case "House":
                    estateManager.ChangeAt(new House(selectedEstate.Id, selectedCategory,
                        selectedType, selectedLegalForm, address, selectedUniqueAttr),
                        selectedEstateIndex);
                    break;
                case "Villa":
                    estateManager.ChangeAt(new Villa(selectedEstate.Id, selectedCategory,
                        selectedType, selectedLegalForm, address, selectedUniqueAttr),
                        selectedEstateIndex);
                    break;
                case "Apartment":
                    estateManager.ChangeAt(new Apartment(selectedEstate.Id, selectedCategory,
                       selectedType, selectedLegalForm, address, selectedUniqueAttr),
                       selectedEstateIndex);
                    break;
                case "Townhouse":
                    estateManager.ChangeAt(new Townhouse(selectedEstate.Id, selectedCategory,
                        selectedType, selectedLegalForm, address, selectedUniqueAttr),
                          selectedEstateIndex);
                    break;
            }
            btnCancelEdit.Visible = false;
            btnEdit.Visible = true;
            labelEditEstate.Text = "";
            estateIsEdited = false;
        }

        // Button handler for clear form button
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearGuiFields();
        }

        // Button handler for Add/Save button
        // Add estate object to list or edit estate object 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInputFields())
            {
                Address address = new Address(selectedStreet, selectedZipCode, selectedCity, selectedCountry);

                if (estateIsEdited)
                {
                    EditEstate(address);
                    MessageBox.Show("Estate edited");
                }
                else
                {
                    AddEstate(address);
                    MessageBox.Show("Estate added to list");
                }
                listBoxViewEstates.DataSource = null;
                listBoxViewEstates.DataSource = estateManager.ToStringList();
                fileIsSaved = false;
                ClearGuiFields();
            }
            else
            {
                MessageBox.Show("Please input all values needed");
            }
        }

        // Button handler for delete estate
        // Deletes selected estate object from estate list and listbox
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (estateManager.Count > 0)
            {
                int selectedIndex = listBoxViewEstates.SelectedIndex;
                estateManager.DeleteAt(selectedIndex);
                listBoxViewEstates.DataSource = null;
                listBoxViewEstates.DataSource = estateManager.ToStringList();
                fileIsSaved = false;
                MessageBox.Show("Estate deleted");

                if (estateManager.Count == 0)
                {
                    btnDelete.Enabled = false;
                }
            }
        }

        // Button handler for edit button
        // Fills fields with the current information about the estate to be edited
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (estateManager.Count > 0)
            {
                btnEdit.Visible = false;
                btnCancelEdit.Visible = true;
                estateIsEdited = true;
                selectedEstateIndex = listBoxViewEstates.SelectedIndex;
                selectedEstate = estateManager.GetAt(selectedEstateIndex);
                labelEditEstate.Text = selectedEstate.Type + " is beeing edited";;
                dropDownAddCategory.Text = selectedEstate.Category;
                dropDownAddType.Text = selectedEstate.Type;
                dropDownAddLegalForm.Text = selectedEstate.LegalForm;
                textBoxAddStreet.Text = selectedEstate.Address.Street;
                textBoxAddZipCode.Text = selectedEstate.Address.ZipCode;
                textBoxAddCity.Text = selectedEstate.Address.City;

                if (selectedEstate.GetType() == typeof(Apartment))
                {
                    Apartment apartment = (Apartment)selectedEstate;
                    dropDownUnique.Text = apartment.NbrOfRooms;
                }
                else if (selectedEstate.GetType() == typeof(House))
                {
                    House house = (House)selectedEstate;
                    dropDownUnique.Text = house.NbrOfBalconys;
                }
                else if (selectedEstate.GetType() == typeof(Shop))
                {
                    Shop shop = (Shop)selectedEstate;
                    dropDownUnique.Text = shop.HasEscalator;
                }
                else if (selectedEstate.GetType() == typeof(Townhouse))
                {
                    Townhouse townhouse = (Townhouse)selectedEstate;
                    dropDownUnique.Text = townhouse.HasFirePlace;
                }
                else if (selectedEstate.GetType() == typeof(Villa))
                {
                    Villa villa = (Villa)selectedEstate;
                    dropDownUnique.Text = villa.HasPool;
                }
                else if (selectedEstate.GetType() == typeof(Warehouse))
                {
                    Warehouse warehouse = (Warehouse)selectedEstate;
                    dropDownUnique.Text = warehouse.NbrOfLoadingPorts;
                }
                for (int i = 0; i < countryList.Count; i++)
                {
                    if (countryList[i].ToString().Equals(selectedEstate.Address.Country))
                    {
                        listBoxAddCountry.SelectedIndex = i;
                    }
                }
            }
            else
            {
                MessageBox.Show("There is nothing to edit");
            }
        }

        // Button handler for cancel edit button
        // Cancels editing
        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            estateIsEdited = false;
            btnCancelEdit.Visible = false;
            btnEdit.Visible = true;
            ClearGuiFields();
        }

        // Event handler for when double clicking on item in listbox 
        // Shows message box with information about the selected object
        private void listBoxViewEstates_DoubleClick(object sender, EventArgs e)
        {
            selectedEstate = estateManager.GetAt(listBoxViewEstates.SelectedIndex);
            MessageBox.Show(selectedEstate.ToString());
        }

        // Adds different types of attributes in dropdownlist depending on what type i chosen
        private void AddUniqueAttributeToList()
        {
            attributeList = new List<string>();
            strAttribute = "Unique attribute";

            if (!typeIsSelected)
            {
                typeIsSelected = true;
            }
            else if (selectedType.Equals("Warehouse"))
            {
                strAttribute = "Nbr of loading ports?";
                attributeList.Add("None");
                attributeList.Add("1");
                attributeList.Add("2");
                attributeList.Add("3");
                attributeList.Add("4");
                attributeList.Add("5");
            }
            else if (selectedType.Equals("Shop"))
            {
                strAttribute = "Has escalator?";
                attributeList.Add("Yes");
                attributeList.Add("No");
            }
            else if (selectedType.Equals("Townhouse"))
            {
                strAttribute = "Has fireplace?";
                attributeList.Add("Yes");
                attributeList.Add("No");
            }
            else if (selectedType.Equals("Apartment"))
            {
                strAttribute = "Nbr of rooms?";
                attributeList.Add("1");
                attributeList.Add("2");
                attributeList.Add("3");
                attributeList.Add("4");
                attributeList.Add("5");
                attributeList.Add("6");
            }
            else if (selectedType.Equals("House"))
            {
                strAttribute = "Nbr of balconys?";
                attributeList.Add("None");
                attributeList.Add("1");
                attributeList.Add("2");
                attributeList.Add("3");
                attributeList.Add("4");
            }
            else if (selectedType.Equals("Villa"))
            {
                strAttribute = "Has pool?";
                attributeList.Add("No");
                attributeList.Add("Yes");
            }
            dropDownUnique.DataSource = new BindingSource(attributeList, null);
            dropDownUnique.Text = strAttribute;
        }

        // Adds different types of buildings to drop down list depending on what category is chosen
        private void AddTypesToDropDownList()
        {
            typeList = new List<string>();

            if (selectedCategory.Equals("Commercial"))
            {
                typeList.Add("Shop");
                typeList.Add("Warehouse");
            }
            else if (selectedCategory.Equals("Residential"))
            {
                typeList.Add("House");
                typeList.Add("Villa");
                typeList.Add("Apartment");
                typeList.Add("Townhouse");
            }
            dropDownAddType.DataSource = new BindingSource(typeList, null);
            dropDownAddType.Text = "Type";
        }

        // Resets the form completely
        private void ResetForm()
        {
            Gui gui = new Gui();
            gui.Show();
            this.Dispose(false);
        }

        // Button handler for X button in form
        // Checks if there are unsaved changes and lets user decide to quit application or not
        private void Gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !fileIsSaved && estateManager.Count > 0)
            {
                if (MessageBox.Show(this, "There are unsaved changes. Are you sure you want to quit?", 
                    "Close application?", 
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        // Button handler for new button in menu
        // Check if user wants to reset the form and delete list of estates if there are unsaved changes
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            if (estateManager.Count > 0 && !fileIsSaved)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "There are unsaved changes that will be discarded", "Unsaved changes", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    ResetForm();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    // do nothing
                }
            }
            else
            {
                ResetForm();
            }
        }

        // Button handler for open file button in menu
        // Opens file with saved estates
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            openFileDialog1.Filter = ".dat |*.dat";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                estateManager.DeleteAll();
                fileName = openFileDialog1.FileName;
                try
                {
                    if (!File.Exists(fileName))
                    {
                        errorMessage = $"The file {fileName} was not found. ";
                        throw (new FileNotFoundException(errorMessage));
                    }
                    estateManager = dataController.DeSerializeFile<EstateManager>(fileName);
                    ClearGuiFields();
                    listBoxViewEstates.DataSource = null;
                    listBoxViewEstates.DataSource = estateManager.ToStringList();
                    fileIsSaved = true;
                    id = estateManager.Count+1;
                }
                catch (Exception ex)
                {
                    if (errorMessage != null)
                    {
                        errorMessage = ex.ToString();
                        MessageBox.Show("Error opening file: " + errorMessage);
                    }
                }

                if (estateManager.Count > 0)
                {
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                }
            }
        }

        // Button handler for save button in menu
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (estateManager.Count > 0)
            {
                if (fileName == null)
                {
                    ShowSaveDialog();
                }
                else
                {
                    string errorMsg = null;
                    try
                    {
                        dataController.SerializeFile(estateManager, fileName);
                    }
                    catch (Exception ex)
                    {
                        errorMsg = ex.ToString();
                        MessageBox.Show("Error writing to file: " + errorMsg);
                    }
                    MessageBox.Show("File saved");
                    fileIsSaved = true;
                }
            }
            else
            {
                MessageBox.Show("There is nothing to save");
            }
        }

        // Button handler for save as button in file menu
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (estateManager.Count > 0)
            {
                ShowSaveDialog();
            }
            else
            {
                MessageBox.Show("There is nothing to save");
            }
        }

        // Opens a save file dialog box
        private void ShowSaveDialog()
        {
            saveFileDialog1.Filter = ".dat |*.dat";
            saveFileDialog1.Title = "Save estates to file";
            saveFileDialog1.ShowDialog();      
        }

        // Saves the file at chosen destination
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fileName = saveFileDialog1.FileName;
            string errorMsg = null;
            try
            {
                dataController.SerializeFile(estateManager, fileName);
            }
            catch (Exception ex)
            {
                errorMsg = ex.ToString();
                MessageBox.Show("Error writing to file: " + errorMsg);
            }
            MessageBox.Show("File saved");
            fileIsSaved = true;
        }

        // Changes string variable to selected value in listbox
        private void listBoxAddCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedCountry = listBoxAddCountry.SelectedItem.ToString();
        }

        // Changes string variable to selected value in drop down list
        private void dropDownAddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = dropDownAddCategory.SelectedItem.ToString();
            AddTypesToDropDownList();
        }

        // Changes string variable to selected value in drop down list
        private void dropDownAddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = dropDownAddType.SelectedItem.ToString();
            AddUniqueAttributeToList();
        }

        // Changes string variable to selected value in drop down list
        private void dropDownUnique_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUniqueAttr = dropDownUnique.SelectedItem.ToString();
        }

        // Changes string variable to selected value in drop down list
        private void dropDownAddLegalForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLegalForm = dropDownAddLegalForm.SelectedItem.ToString();
        }

        // Empty the textbox when clicked
        private void textBoxAddStreet_Enter(object sender, EventArgs e)
        {
            textBoxAddStreet.ResetText();
        }

        // Empty the textbox when clicked
        private void textBoxAddZipCode_Enter(object sender, EventArgs e)
        {
            textBoxAddZipCode.ResetText();
        }

        // Empty the textbox when clicked
        private void textBoxAddCity_Enter(object sender, EventArgs e)
        {
            textBoxAddCity.ResetText();
        }

        // Empty the textbox when clicked
        private void textBoxSearchCity_Enter(object sender, EventArgs e)
        {
            textBoxSearchCity.ResetText();
        }

        // Changes value of string if textbox is changed
        private void textBoxAddStreet_TextChanged(object sender, EventArgs e)
        {
            selectedStreet = textBoxAddStreet.Text;
        }

        // Changes value of string if textbox is changed
        private void textBoxAddZipCode_TextChanged(object sender, EventArgs e)
        {
            selectedZipCode = textBoxAddZipCode.Text;
        }

        // Changes value of string if textbox is changed
        private void textBoxAddCity_TextChanged(object sender, EventArgs e)
        {
            selectedCity = textBoxAddCity.Text;
        }
    }
}
