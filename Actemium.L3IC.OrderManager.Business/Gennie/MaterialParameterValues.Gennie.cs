using System;
using System.Collections.Generic;
using Actemium.Data.Exceptions;
using Actemium.Diagnostics;
using Actemium.UserManagement2.Business;

namespace Actemium.L3IC.OrderManager.Business
{
	/// <summary>
	/// Business class for MaterialParameterValues (Generated by Gennie).
	/// Description: The value of the material specific parameters
	/// </summary>
	public sealed partial class MaterialParameterValues : MaterialParameterValuesGennie
	{
		private const string CLASSNAME = nameof(MaterialParameterValues);

		
		public static readonly MaterialParameterValues Instance = new MaterialParameterValues();
	}

	/// <summary>
	/// Business class for MaterialParameterValuesGennie (Generated by Gennie).
	/// </summary>
	public abstract class MaterialParameterValuesGennie
	{
		private const string CLASSNAME = nameof(MaterialParameterValuesGennie);
		
 		/// <summary>
		/// Add a new MaterialParameterValue to the database
		/// </summary>
		public virtual Int32 Add(Model.MaterialParameterValue newMaterialParameterValue)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, newMaterialParameterValue);

				CheckConstraints(newMaterialParameterValue);
				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();

        return materialParameterValues.Add(newMaterialParameterValue);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, newMaterialParameterValue);
        throw new BusinessException(string.Format("No related object found in {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, newMaterialParameterValue);
				throw;
			}
		}


		/// <summary>
		/// Check Datafield constraints
		/// </summary>
		protected virtual void CheckConstraints(Model.MaterialParameterValue materialParameterValue)
		{
			//Range checks, etc checks go here
			if (materialParameterValue.Value == null)
			  throw new BusinessException(string.Format("Value may not be NULL. ({0})", materialParameterValue.Value));

			if (materialParameterValue.Value.Length > 50)
			  throw new BusinessException(string.Format("Value may not be longer than 50 characters. ({0})", materialParameterValue.Value));

		}


		/// <summary>
		/// Delete the given MaterialParameterValue from the database
		/// </summary>
		public virtual void Delete(Model.MaterialParameterValue delMaterialParameterValue)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, delMaterialParameterValue);

				//Begin Checks
				if (!Exists(delMaterialParameterValue))
					throw new BusinessException(string.Format("There is no MaterialParameterValue with this id. ({0})", delMaterialParameterValue));

				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				materialParameterValues.Delete(delMaterialParameterValue);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, delMaterialParameterValue);
        throw new BusinessException(string.Format("The MaterialParameterValue is still used by {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, delMaterialParameterValue);
				throw;
			}
		}


		/// <summary>
		/// Modify the given MaterialParameterValue in the database
		/// </summary>
		public virtual void Modify(Model.MaterialParameterValue modifiedMaterialParameterValue)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, modifiedMaterialParameterValue);

				//Begin Checks
				CheckConstraints(modifiedMaterialParameterValue);

				if (!Exists(modifiedMaterialParameterValue))
					throw new BusinessException(string.Format("There is no MaterialParameterValue with this id. ({0})", modifiedMaterialParameterValue));

				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				materialParameterValues.Modify(modifiedMaterialParameterValue);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, modifiedMaterialParameterValue);
				throw;
			}
		}
		
		/// <summary>
		/// Modify only the specified properties of the MaterialParameterValue 
		/// specified by:
		/// </summary>
		/// <param name="id">PK</param>
	    /// <param name="propValues">Properties to change</param>
		public virtual void Modify(Int32 id,  params KeyValuePair<string,object>[] propValues)
		{
			try
			{
				Trace.WriteInformation("({0}, {1})", Trace.GetMethodName(), CLASSNAME, id, string.Join(",", propValues));

				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				materialParameterValues.Modify(
				id, 
				propValues);
				return;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, id);
				throw;
			}
		}


		/// <summary>
		/// Get all MaterialParameterValue records from the database
		/// </summary>
		public virtual List<Model.MaterialParameterValue> GetAll()
		{
			try
			{
				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				List<Model.MaterialParameterValue> result = materialParameterValues.GetAll();

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		/// <summary>
		/// Get a MaterialParameterValue by id from the database
		/// </summary>
		public virtual Model.MaterialParameterValue GetById(Int32 id)
		{
		  try
			{
		    DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				Model.MaterialParameterValue result = materialParameterValues.GetById(id);
			  return result;
			}
			catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
			  throw;
			}
		}


		/// <summary>
		/// Get a MaterialParameterValue by MaterialId from the database
		/// </summary>
		public virtual List<Model.MaterialParameterValue> GetByMaterialId(Int32 materialId)
		{
			try
			{
				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				List<Model.MaterialParameterValue> result = materialParameterValues.GetByMaterialId(materialId);

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, materialId);
				throw;
			}
		}

		/// <summary>
		/// Get a MaterialParameterValue by MaterialParameterId from the database
		/// </summary>
		public virtual List<Model.MaterialParameterValue> GetByMaterialParameterId(Int32 materialParameterId)
		{
			try
			{
				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				List<Model.MaterialParameterValue> result = materialParameterValues.GetByMaterialParameterId(materialParameterId);

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, materialParameterId);
				throw;
			}
		}


		/// <summary>
		/// Equals function to compare class
		/// </summary> 
		public virtual bool Exists(Model.MaterialParameterValue materialParameterValue)
		{
		  try
			{
				return (this.GetById(materialParameterValue.Id) != null);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, materialParameterValue);
				throw;
			}
		}


		/// <summary>
		/// Equals function to compare class
		/// </summary> 
		public virtual bool Exists(Int32 id )
		{
		  try
		  {
				DataAccess.MaterialParameterValues materialParameterValues = new DataAccess.MaterialParameterValues();
				return materialParameterValues.GetById(id) != null;
			}
		  catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
				throw;
			}
		}    

	}
}