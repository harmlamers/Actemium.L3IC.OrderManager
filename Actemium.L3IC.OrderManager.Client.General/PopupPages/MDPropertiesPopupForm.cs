using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Business;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.L3IC.OrderManager.Model;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages {
    public partial class MDPropertiesPopupForm : BasePopupForm {
        private const string CLASSNAME = nameof(MDPropertiesPopupForm);
        private readonly Material _selectedMaterial;
        private List<MaterialParameterValue> materialParametersValues = new List<MaterialParameterValue>();
        private List<MaterialParameter> materialParameters = new List<MaterialParameter>();
        private int selectedMaterialParameterId = -1;
        private MaterialParameterValue selectedMaterialParameterValue;
        bool textChanged;

        public Material PropertiesResult { get; private set; }

        public MDPropertiesPopupForm() {
            InitializeComponent();
            InitializeTranslations();
        }

        public MDPropertiesPopupForm(Material material) : this() {
            NavigationItem = NavigationItems.MasterData;
            ACICategory = ACICategories.GENERAL;
            _selectedMaterial = material;

            InitializeButtons();
        }

        private void InitializeButtons() {
            var saveimage = Properties.Resources.IE_PropertiesSave_16;

            MaterialPropertyValueSaveButtonX1.Image = saveimage;
        }

        private void FillListBox() {
            materialParameters = new MaterialParameters().GetByMaterialGroupId(_selectedMaterial.MaterialGroupId);

            MaterialPropertiesListBoxX.Items.Clear();

            foreach (var materialParameter in materialParameters) {
                MaterialPropertiesListBoxX.Items.Add(materialParameter.Code);
            }
        }

        private void GetActualValues() {
            materialParametersValues = new MaterialParameterValues().GetByMaterialId(_selectedMaterial.Id);
        }

        #region Translations

        private void InitializeTranslations() {
            Translations.Initialize();
        }

        #endregion

        private void OkButtonXClick(object sender, EventArgs e) {
            try {
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) {
                Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public void ListboxSelectionChanged(object sender, EventArgs e) {
            int selectedIndex = MaterialPropertiesListBoxX.SelectedIndex;
            
            if (selectedIndex >= 0) {
                string selected = MaterialPropertiesListBoxX.Items[MaterialPropertiesListBoxX.SelectedIndex].ToString();

                foreach (var materialParameter in materialParameters) {
                    if (selected == materialParameter.Code) {
                        selectedMaterialParameterId = materialParameter.Id;
                        break;
                    }
                }

                foreach (var materialParameterValue in materialParametersValues) {
                    if (materialParameterValue.MaterialParameterId == selectedMaterialParameterId) {
                        selectedMaterialParameterValue = materialParameterValue;
                        break;
                    }
                    else {
                        selectedMaterialParameterValue = null;
                    }
                }
            }

            if (selectedMaterialParameterValue != null) {
                MaterialPropertyValueTextBoxX.Text = selectedMaterialParameterValue.Value;
            }
            else {
                MaterialPropertyValueTextBoxX.Text = "";
            }

            textChanged = false;
            EnableDisableControls();
        }

        private void MaterialPropertyValueTextBoxX_TextChanged(object sender, EventArgs e) {
            if (selectedMaterialParameterValue != null) {
                foreach (var materialParameterValue in materialParametersValues) {
                    if (selectedMaterialParameterValue.Id == materialParameterValue.Id) {
                        if (MaterialPropertyValueTextBoxX.Text != materialParameterValue.Value) {
                            textChanged = true;
                        }
                        else {
                            textChanged = false;
                        }
                    }
                }
            }
            else {
                if (MaterialPropertyValueTextBoxX.Text.Length != 0) {
                    textChanged = true;
                }
                else {
                    textChanged = false;
                }
            }

            EnableDisableControls();
        }

        private void SaveButtonClicked(object sender, EventArgs e) {
            try {
                if (MaterialPropertyValueTextBoxX.Text.Length > 0) {
                    AddModifyProperty();
                }
                else {
                    DeleteProperty();
                }

                GetActualValues();

                textChanged = false;

                EnableDisableControls();
            }
            catch (Exception ex) {
                Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        private void AddModifyProperty() {

            if (Confirm(TranslationKey.Confirm_UserGroup_Modify, "Modify Material Property",
                        "Are you sure to modify this material property?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                if (selectedMaterialParameterValue != null) {
                    selectedMaterialParameterValue.Value = MaterialPropertyValueTextBoxX.Text;
                    new MaterialParameterValues().Modify(selectedMaterialParameterValue);
                }
                else {
                    MaterialParameterValue newMaterialParameterValue = new MaterialParameterValue();
                    newMaterialParameterValue.MaterialId = _selectedMaterial.Id;
                    newMaterialParameterValue.MaterialParameterId = selectedMaterialParameterId;
                    newMaterialParameterValue.Value = MaterialPropertyValueTextBoxX.Text;

                    new MaterialParameterValues().Add(newMaterialParameterValue);
                }
            }
        }

        private void DeleteProperty() {
            if (Confirm(TranslationKey.Confirm_UserGroup_Delete, "Delete Material Property",
                        "Are you sure to delete this material property?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                new MaterialParameterValues().Delete(selectedMaterialParameterValue);
            }
        }

        private void MDPropertiesPopupFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            DeActivateFromMain();
        }

        private void MDPropertiesPopupFormActivated(object sender, EventArgs e) {
            ActivateFromMain(e);
        }

        public override void ActivateFromMain(EventArgs e) {
            try {
                base.ActivateFromMain(e);
                Show();
                try {
                    ShowBusyBox = true;
                    EnableDisableControls();
                    FillListBox();
                    GetActualValues();
                }
                catch (Exception ex) {
                    Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                    throw;
                }
                finally {
                    ShowBusyBox = false;
                }
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public override void DeActivateFromMain() {
            try {
                base.DeActivateFromMain();
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        private void EnableDisableControls() {
            errorProvider.Clear();

            MaterialPropertiesLabelX.Visible = true;
            MaterialPropertiesListBoxX.Visible = true;
            MaterialPropertyValueLabelX.Visible = true;
            MaterialPropertyValueTextBoxX.Visible = true;
            MaterialPropertyValueSaveButtonX1.Visible = true;

            if (MaterialPropertiesListBoxX.SelectedIndex >= 0) {
                MaterialPropertyValueLabelX.Enabled = true;
                MaterialPropertyValueTextBoxX.Enabled = true;
            }
            else {
                MaterialPropertyValueLabelX.Enabled = false;
                MaterialPropertyValueTextBoxX.Enabled = false;
            }

            if (textChanged) {
                MaterialPropertyValueSaveButtonX1.Enabled = true;
            }
            else {
                MaterialPropertyValueSaveButtonX1.Enabled = false;
            }

            MaterialPropertiesLabelX.Enabled = true;
            MaterialPropertiesListBoxX.Enabled = true;
        }
    }
}
