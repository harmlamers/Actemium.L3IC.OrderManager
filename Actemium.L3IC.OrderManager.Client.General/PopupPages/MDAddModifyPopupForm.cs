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
using Actemium.L3IC.OrderManager.Model;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages {
    public partial class MDAddModifyPopupForm : BasePopupForm {
        private const string CLASSNAME = nameof(MDAddModifyPopupForm);
        private readonly Material _material;
        private List<MaterialGroup> materialGroups = new MaterialGroups().GetAll();

        public Material MaterialResult { get; private set; }

        public MDAddModifyPopupForm() {
            InitializeComponent();
            InitializeTranslations();
        }

        public MDAddModifyPopupForm(Material material) : this() {
            NavigationItem = NavigationItems.MasterData;
            ACICategory = ACICategories.GENERAL;
            _material = material;
            
            if (_material is null) {
                Text = "Add material";
            }
            else {
                Text = "Modify material";
            }
        }

        #region Translations

        private void InitializeTranslations() {
            Translations.Initialize();
        }

        #endregion

        private void OkButtonXClick(object sender, EventArgs e) {
            MaterialResult = CheckMaterialConstraints();
            if (MaterialResult == null) {
                return;
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void MDAddModifyPopupFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            DeActivateFromMain();
        }

        private void MDAddModifyPopupFormActivated(object sender, EventArgs e) {
            ActivateFromMain(e);
        }

        public override void ActivateFromMain(EventArgs e) {
            try {
                base.ActivateFromMain(e);
                Show();
                try {
                    ShowBusyBox = true;
                    EnableDisableControls();
                    FillFields();
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
            
            MaterialDescriptionTextBoxX.Visible = true;
            MaterialDescriptionLabelX.Visible = true;
            MaterialCodeTextBoxX.Visible = true;
            MaterialCodeLabelX.Visible = true;
            //TODO: Somewhere changed code back to Name (HLS)
            MaterialCodeLabelX.Text = "Code";
            MaterialGroupDropDown.Visible = true;
            MaterialGroupLabelX.Visible = true;

            if (_material == null) {
                MaterialDescriptionTextBoxX.Enabled = true;
                MaterialDescriptionLabelX.Enabled = true;
                MaterialCodeTextBoxX.Enabled = true;
                MaterialCodeLabelX.Enabled = true;
                MaterialGroupDropDown.Enabled = true;
                MaterialGroupLabelX.Enabled = true;
            }            
            else {
                MaterialDescriptionTextBoxX.Enabled = true;
                MaterialDescriptionLabelX.Enabled = true;
                MaterialCodeTextBoxX.Enabled = false;
                MaterialCodeLabelX.Enabled = false;
                MaterialGroupDropDown.Enabled = false;
                MaterialGroupLabelX.Enabled = false;
            }
        }

        private void FillFields() {
            materialGroups = new MaterialGroups().GetAll();
            MaterialGroupDropDown.Items.Clear();

            try {
                MaterialPanelX.Visible = true;

                foreach (var materialGroup in materialGroups) {
                    MaterialGroupDropDown.Items.Add(materialGroup.Description);
                }

                if (_material == null) {
                    MaterialCodeTextBoxX.Text = "";
                    MaterialDescriptionTextBoxX.Text = "";
                    MaterialGroupDropDown.Text = "";
                }
                else {
                    MaterialCodeTextBoxX.Text = _material.Code.ToString();
                    MaterialDescriptionTextBoxX.Text = _material.Description;
                    
                    foreach (var materialGroup in materialGroups) {
                        if (_material.MaterialGroupId == materialGroup.Id) {
                            MaterialGroupDropDown.Text = materialGroup.Description;
                        }
                    }
                }
            }
            catch (Exception ex) {
                Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        private Material CheckMaterialConstraints() {
            try {
                Material result = _material ?? new Material();

                bool errorMaterialCode = true;
                bool errorMaterialDescription = true;
                bool errorMaterialGroup = true;

                errorProvider.Clear();

                if (_material is null && !CheckMaterialCode()) {
                    result.Code = Convert.ToInt32(MaterialCodeTextBoxX.Text);
                    errorMaterialCode = false;
                }
                else if (_material != null){
                    errorMaterialCode = false;
                }


                if (!CheckMaterialDescription()) {
                    result.Description = MaterialDescriptionTextBoxX.Text;
                    errorMaterialDescription = false;
                }

                int groupId = CheckMaterialGroup();

                if (groupId != -1) {
                    result.MaterialGroupId = groupId;
                    errorMaterialGroup = false;
                }

                if (!errorMaterialCode && !errorMaterialDescription && !errorMaterialGroup) {
                    return result;
                }

                return null;
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        private bool CheckMaterialCode() {
            bool hasError = false;

            if (MaterialCodeTextBoxX.Text.Length > 0) {
                try {
                    int code = Convert.ToInt32(MaterialCodeTextBoxX.Text);
                    var materials = new Materials().GetByCode(code);

                    if (materials.Count != 0) {
                        errorProvider.SetError(MaterialCodeTextBoxX, Translations.General.MustBeUnique);
                        hasError = true;
                    }

                }
                catch (FormatException) {
                    errorProvider.SetError(MaterialCodeTextBoxX, Translations.MasterDataAddModifyPopupForm.MustBeNumeric);
                    hasError = true;
                }
                catch (OverflowException) {
                    errorProvider.SetError(MaterialCodeTextBoxX, Translations.MasterDataAddModifyPopupForm.TooLarge);
                    hasError = true;
                }
            }
            else {
                errorProvider.SetError(MaterialCodeTextBoxX, Translations.General.MandatoryData);
                hasError = true;
            }

            return hasError;
        }

        private bool CheckMaterialDescription() {
            bool hasError = false;

            if (MaterialDescriptionTextBoxX.Text.Length <= 0 || MaterialDescriptionTextBoxX.Text.Length > 50) {
                errorProvider.SetError(MaterialDescriptionTextBoxX, Translations.General.MandatoryData);
                hasError = true;
            }

            return hasError;
        }

        private int CheckMaterialGroup() {
            int HAS_ERROR = -1;
            int materialGroupId = HAS_ERROR;

            if (MaterialGroupDropDown.Text.Length > 0) {
                bool errorInDropDown = true;

                foreach (var materialGroup in materialGroups) {
                    if (materialGroup.Description == MaterialGroupDropDown.Text) {
                        materialGroupId = materialGroup.Id;
                        errorInDropDown = false;
                        break;
                    }
                }

                if (errorInDropDown) {
                    errorProvider.SetError(MaterialGroupDropDown, Translations.MasterDataAddModifyPopupForm.SelectFromList);
                }
            }
            else {
                errorProvider.SetError(MaterialGroupDropDown, Translations.General.MandatoryData);
            }

            return materialGroupId;
        }
    }
}
