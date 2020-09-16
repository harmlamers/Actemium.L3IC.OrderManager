using System;
using System.Collections.Generic;
using System.Data;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids;
using Actemium.L3IC.OrderManager.Business;
using Actemium.L3IC.OrderManager.Model;
using Actemium.Windows.Forms.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers {
    public class MDHelper {
        private const string CLASSNAME = nameof(MDHelper);
        public static MDHelper Instance = new MDHelper();

        public DataTable GetDataTable(List<Material> materials) {
            try {
                var dataTable = SuperGrid.DefineGridColumns(
                  Translations.MasterData.Materials,
                  new SuperGrid.ColumnDefinition("Material", "Material", typeof(Material), inUI: false),
                  new SuperGrid.ColumnDefinition("Material Id", "Material Id", typeof(int), visible: false),
                  new SuperGrid.ColumnDefinition("Material Group", "Material Group", typeof(string), visible: true),
                  new SuperGrid.ColumnDefinition("Code", "Code", typeof(string)),
                  new SuperGrid.ColumnDefinition("Description", "Description", typeof(string))
                  );

                dataTable.BeginLoadData();

                foreach (var item in materials) {
                    var id = item.Id;
                    var groupId = new MaterialGroups().GetById(item.MaterialGroupId).Description;
                    var code = item.Code;
                    var description = item.Description;
                    var row = dataTable.NewRow();

                    dataTable.Rows.Add(
                      item,
                      id,
                      groupId,
                      code,
                      description
                      );

                    row.AcceptChanges();
                }

                dataTable.EndLoadData();
                return dataTable;
            }
            catch (Exception ex) {
                Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public List<PropertyGridElement> CreatePropertyGridElements(Material item) {
            var listOfProperties = new List<PropertyGridElement>();

            var category = $"01 - {string.Format(item.Description)}";

            listOfProperties.Add(new PropertyGridElement("MaterialGroup", new MaterialGroups().GetById(item.MaterialGroupId).Description, category, ""));
            listOfProperties.Add(new PropertyGridElement("Code", item.Code.ToString(), category, ""));
            listOfProperties.Add(new PropertyGridElement("Description", item.Description, category, ""));

            category = $"02 - {string.Format(Translations.MasterData.Properties)}";

            var materialParameters = new MaterialParameters().GetByMaterialGroupId(item.MaterialGroupId);

            foreach (var materialParameter in materialParameters) {
                var materialParameterValues = new MaterialParameterValues().GetByMaterialParameterId(materialParameter.Id);

                foreach (var materialParameterValue in materialParameterValues) {
                    if (item.Id == materialParameterValue.MaterialId) {
                        listOfProperties.Add(new PropertyGridElement(materialParameter.Code, materialParameterValue.Value, category, ""));
                    }
                }
            }

            return listOfProperties;
        }

        public void DeleteMaterialParameterValues(Material selectedMaterial) {
            List<MaterialParameterValue> materialParameterValues = new MaterialParameterValues().GetByMaterialId(selectedMaterial.Id);

            foreach (var materialParameterValue in materialParameterValues) {
                new MaterialParameterValues().Delete(materialParameterValue);
            }
        }
    }
}
