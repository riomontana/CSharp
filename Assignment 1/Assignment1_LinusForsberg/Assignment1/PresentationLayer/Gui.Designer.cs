namespace Assignment1
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxViewEstates = new System.Windows.Forms.ListBox();
            this.textBoxSearchCity = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.listBoxAddCountry = new System.Windows.Forms.ListBox();
            this.textBoxAddZipCode = new System.Windows.Forms.TextBox();
            this.textBoxAddCity = new System.Windows.Forms.TextBox();
            this.textBoxAddStreet = new System.Windows.Forms.TextBox();
            this.groupBoxAddEditEstate = new System.Windows.Forms.GroupBox();
            this.dropDownUnique = new System.Windows.Forms.ComboBox();
            this.dropDownAddLegalForm = new System.Windows.Forms.ComboBox();
            this.dropDownAddType = new System.Windows.Forms.ComboBox();
            this.dropDownAddCategory = new System.Windows.Forms.ComboBox();
            this.groupBoxSearchViewEstates = new System.Windows.Forms.GroupBox();
            this.dropDownSearchType = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelEditEstate = new System.Windows.Forms.Label();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.groupBoxAddEditEstate.SuspendLayout();
            this.groupBoxSearchViewEstates.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxViewEstates
            // 
            this.listBoxViewEstates.FormattingEnabled = true;
            this.listBoxViewEstates.Location = new System.Drawing.Point(6, 74);
            this.listBoxViewEstates.Name = "listBoxViewEstates";
            this.listBoxViewEstates.Size = new System.Drawing.Size(156, 199);
            this.listBoxViewEstates.TabIndex = 0;
            this.listBoxViewEstates.DoubleClick += new System.EventHandler(this.listBoxViewEstates_DoubleClick);
            // 
            // textBoxSearchCity
            // 
            this.textBoxSearchCity.Location = new System.Drawing.Point(6, 19);
            this.textBoxSearchCity.Name = "textBoxSearchCity";
            this.textBoxSearchCity.Size = new System.Drawing.Size(156, 20);
            this.textBoxSearchCity.TabIndex = 2;
            this.textBoxSearchCity.Text = "City";
            this.textBoxSearchCity.Enter += new System.EventHandler(this.textBoxSearchCity_Enter);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(18, 326);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Clear form";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(99, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Add/Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(275, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(194, 326);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // listBoxAddCountry
            // 
            this.listBoxAddCountry.FormattingEnabled = true;
            this.listBoxAddCountry.Location = new System.Drawing.Point(6, 203);
            this.listBoxAddCountry.Name = "listBoxAddCountry";
            this.listBoxAddCountry.ScrollAlwaysVisible = true;
            this.listBoxAddCountry.Size = new System.Drawing.Size(156, 69);
            this.listBoxAddCountry.TabIndex = 13;
            this.listBoxAddCountry.SelectedValueChanged += new System.EventHandler(this.listBoxAddCountry_SelectedValueChanged);
            // 
            // textBoxAddZipCode
            // 
            this.textBoxAddZipCode.Location = new System.Drawing.Point(6, 153);
            this.textBoxAddZipCode.Name = "textBoxAddZipCode";
            this.textBoxAddZipCode.Size = new System.Drawing.Size(156, 20);
            this.textBoxAddZipCode.TabIndex = 14;
            this.textBoxAddZipCode.Text = "Zip code";
            this.textBoxAddZipCode.TextChanged += new System.EventHandler(this.textBoxAddZipCode_TextChanged);
            this.textBoxAddZipCode.Enter += new System.EventHandler(this.textBoxAddZipCode_Enter);
            // 
            // textBoxAddCity
            // 
            this.textBoxAddCity.Location = new System.Drawing.Point(6, 179);
            this.textBoxAddCity.Name = "textBoxAddCity";
            this.textBoxAddCity.Size = new System.Drawing.Size(156, 20);
            this.textBoxAddCity.TabIndex = 15;
            this.textBoxAddCity.Text = "City";
            this.textBoxAddCity.TextChanged += new System.EventHandler(this.textBoxAddCity_TextChanged);
            this.textBoxAddCity.Enter += new System.EventHandler(this.textBoxAddCity_Enter);
            // 
            // textBoxAddStreet
            // 
            this.textBoxAddStreet.Location = new System.Drawing.Point(6, 127);
            this.textBoxAddStreet.Name = "textBoxAddStreet";
            this.textBoxAddStreet.Size = new System.Drawing.Size(156, 20);
            this.textBoxAddStreet.TabIndex = 16;
            this.textBoxAddStreet.Text = "Street";
            this.textBoxAddStreet.TextChanged += new System.EventHandler(this.textBoxAddStreet_TextChanged);
            this.textBoxAddStreet.Enter += new System.EventHandler(this.textBoxAddStreet_Enter);
            // 
            // groupBoxAddEditEstate
            // 
            this.groupBoxAddEditEstate.Controls.Add(this.dropDownUnique);
            this.groupBoxAddEditEstate.Controls.Add(this.dropDownAddLegalForm);
            this.groupBoxAddEditEstate.Controls.Add(this.dropDownAddType);
            this.groupBoxAddEditEstate.Controls.Add(this.dropDownAddCategory);
            this.groupBoxAddEditEstate.Controls.Add(this.listBoxAddCountry);
            this.groupBoxAddEditEstate.Controls.Add(this.textBoxAddCity);
            this.groupBoxAddEditEstate.Controls.Add(this.textBoxAddStreet);
            this.groupBoxAddEditEstate.Controls.Add(this.textBoxAddZipCode);
            this.groupBoxAddEditEstate.Location = new System.Drawing.Point(12, 41);
            this.groupBoxAddEditEstate.Name = "groupBoxAddEditEstate";
            this.groupBoxAddEditEstate.Size = new System.Drawing.Size(170, 279);
            this.groupBoxAddEditEstate.TabIndex = 17;
            this.groupBoxAddEditEstate.TabStop = false;
            this.groupBoxAddEditEstate.Text = "Add / Edit estate";
            // 
            // dropDownUnique
            // 
            this.dropDownUnique.FormattingEnabled = true;
            this.dropDownUnique.Location = new System.Drawing.Point(6, 100);
            this.dropDownUnique.Name = "dropDownUnique";
            this.dropDownUnique.Size = new System.Drawing.Size(156, 21);
            this.dropDownUnique.TabIndex = 20;
            this.dropDownUnique.Text = "Unique attribute";
            this.dropDownUnique.SelectedIndexChanged += new System.EventHandler(this.dropDownUnique_SelectedIndexChanged);
            // 
            // dropDownAddLegalForm
            // 
            this.dropDownAddLegalForm.FormattingEnabled = true;
            this.dropDownAddLegalForm.Items.AddRange(new object[] {
            "Ownership",
            "Tenement",
            "Rental"});
            this.dropDownAddLegalForm.Location = new System.Drawing.Point(7, 73);
            this.dropDownAddLegalForm.Name = "dropDownAddLegalForm";
            this.dropDownAddLegalForm.Size = new System.Drawing.Size(155, 21);
            this.dropDownAddLegalForm.TabIndex = 19;
            this.dropDownAddLegalForm.Text = "Legal form";
            this.dropDownAddLegalForm.SelectedIndexChanged += new System.EventHandler(this.dropDownAddLegalForm_SelectedIndexChanged);
            // 
            // dropDownAddType
            // 
            this.dropDownAddType.FormattingEnabled = true;
            this.dropDownAddType.Items.AddRange(new object[] {
            "Choose a category first"});
            this.dropDownAddType.Location = new System.Drawing.Point(7, 45);
            this.dropDownAddType.Name = "dropDownAddType";
            this.dropDownAddType.Size = new System.Drawing.Size(155, 21);
            this.dropDownAddType.TabIndex = 18;
            this.dropDownAddType.Text = "Type";
            this.dropDownAddType.SelectedIndexChanged += new System.EventHandler(this.dropDownAddType_SelectedIndexChanged);
            // 
            // dropDownAddCategory
            // 
            this.dropDownAddCategory.FormattingEnabled = true;
            this.dropDownAddCategory.Items.AddRange(new object[] {
            "Commercial",
            "Residential"});
            this.dropDownAddCategory.Location = new System.Drawing.Point(6, 18);
            this.dropDownAddCategory.Name = "dropDownAddCategory";
            this.dropDownAddCategory.Size = new System.Drawing.Size(156, 21);
            this.dropDownAddCategory.TabIndex = 17;
            this.dropDownAddCategory.Text = "Category";
            this.dropDownAddCategory.SelectedIndexChanged += new System.EventHandler(this.dropDownAddCategory_SelectedIndexChanged);
            // 
            // groupBoxSearchViewEstates
            // 
            this.groupBoxSearchViewEstates.Controls.Add(this.dropDownSearchType);
            this.groupBoxSearchViewEstates.Controls.Add(this.textBoxSearchCity);
            this.groupBoxSearchViewEstates.Controls.Add(this.listBoxViewEstates);
            this.groupBoxSearchViewEstates.Location = new System.Drawing.Point(188, 41);
            this.groupBoxSearchViewEstates.Name = "groupBoxSearchViewEstates";
            this.groupBoxSearchViewEstates.Size = new System.Drawing.Size(172, 279);
            this.groupBoxSearchViewEstates.TabIndex = 18;
            this.groupBoxSearchViewEstates.TabStop = false;
            this.groupBoxSearchViewEstates.Text = "Search / View estates";
            // 
            // dropDownSearchType
            // 
            this.dropDownSearchType.FormattingEnabled = true;
            this.dropDownSearchType.Items.AddRange(new object[] {
            "Shop",
            "Warehouse",
            "House",
            "Villa",
            "Apartment",
            "Townhouse"});
            this.dropDownSearchType.Location = new System.Drawing.Point(7, 46);
            this.dropDownSearchType.Name = "dropDownSearchType";
            this.dropDownSearchType.Size = new System.Drawing.Size(155, 21);
            this.dropDownSearchType.TabIndex = 3;
            this.dropDownSearchType.Text = "Type";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveAs});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(112, 22);
            this.mnuFileNew.Text = "New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(112, 22);
            this.mnuFileOpen.Text = "Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.Size = new System.Drawing.Size(112, 22);
            this.mnuFileSave.Text = "Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(112, 22);
            this.mnuFileSaveAs.Text = "Save as";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(378, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Choose a file";
            // 
            // labelEditEstate
            // 
            this.labelEditEstate.AutoSize = true;
            this.labelEditEstate.ForeColor = System.Drawing.Color.Red;
            this.labelEditEstate.Location = new System.Drawing.Point(192, 351);
            this.labelEditEstate.Name = "labelEditEstate";
            this.labelEditEstate.Size = new System.Drawing.Size(0, 13);
            this.labelEditEstate.TabIndex = 20;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Location = new System.Drawing.Point(194, 326);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEdit.TabIndex = 21;
            this.btnCancelEdit.Text = "Cancel Edit";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Visible = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 373);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.labelEditEstate);
            this.Controls.Add(this.groupBoxSearchViewEstates);
            this.Controls.Add(this.groupBoxAddEditEstate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(386, 400);
            this.MinimumSize = new System.Drawing.Size(386, 400);
            this.Name = "Gui";
            this.Text = "Homes For Sale Registry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Gui_FormClosing);
            this.groupBoxAddEditEstate.ResumeLayout(false);
            this.groupBoxAddEditEstate.PerformLayout();
            this.groupBoxSearchViewEstates.ResumeLayout(false);
            this.groupBoxSearchViewEstates.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxViewEstates;
        private System.Windows.Forms.TextBox textBoxSearchCity;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox listBoxAddCountry;
        private System.Windows.Forms.TextBox textBoxAddZipCode;
        private System.Windows.Forms.TextBox textBoxAddCity;
        private System.Windows.Forms.TextBox textBoxAddStreet;
        private System.Windows.Forms.GroupBox groupBoxAddEditEstate;
        private System.Windows.Forms.GroupBox groupBoxSearchViewEstates;
        private System.Windows.Forms.ComboBox dropDownAddCategory;
        private System.Windows.Forms.ComboBox dropDownAddType;
        private System.Windows.Forms.ComboBox dropDownAddLegalForm;
        private System.Windows.Forms.ComboBox dropDownSearchType;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelEditEstate;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.ComboBox dropDownUnique;
    }
}

