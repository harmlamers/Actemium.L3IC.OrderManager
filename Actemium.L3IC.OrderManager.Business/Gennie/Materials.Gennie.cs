using System;
using System.Collections.Generic;
using Actemium.Data.Exceptions;
using Actemium.Diagnostics;
using Actemium.UserManagement2.Business;

namespace Actemium.L3IC.OrderManager.Business
{
	/// <summary>
	/// Business class for Materials (Generated by Gennie).
	/// Description: The raw and finished goods materials for the production
	/// </summary>
	public sealed partial class Materials : MaterialsGennie
	{
		private const string CLASSNAME = nameof(Materials);

		
		public static readonly Materials Instance = new Materials();
	}

	/// <summary>
	/// Business class for MaterialsGennie (Generated by Gennie).
	/// </summary>
	public abstract class MaterialsGennie
	{
		private const string CLASSNAME = nameof(MaterialsGennie);
		
 		/// <summary>
		/// Add a new Material to the database
		/// </summary>
		public virtual Int32 Add(Model.Material newMaterial)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, newMaterial);

				CheckConstraints(newMaterial);
				DataAccess.Materials materials = new DataAccess.Materials();

        return materials.Add(newMaterial);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, newMaterial);
        throw new BusinessException(string.Format("No related object found in {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, newMaterial);
				throw;
			}
		}


		/// <summary>
		/// Check Datafield constraints
		/// </summary>
		protected virtual void CheckConstraints(Model.Material material)
		{
			//Range checks, etc checks go here
			if (material.Description == null)
			  throw new BusinessException(string.Format("Description may not be NULL. ({0})", material.Description));

			if (material.Description.Length > 50)
			  throw new BusinessException(string.Format("Description may not be longer than 50 characters. ({0})", material.Description));

		}


		/// <summary>
		/// Delete the given Material from the database
		/// </summary>
		public virtual void Delete(Model.Material delMaterial)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, delMaterial);

				//Begin Checks
				if (!Exists(delMaterial))
					throw new BusinessException(string.Format("There is no Material with this id. ({0})", delMaterial));

				DataAccess.Materials materials = new DataAccess.Materials();
				materials.Delete(delMaterial);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, delMaterial);
        throw new BusinessException(string.Format("The Material is still used by {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, delMaterial);
				throw;
			}
		}


		/// <summary>
		/// Modify the given Material in the database
		/// </summary>
		public virtual void Modify(Model.Material modifiedMaterial)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, modifiedMaterial);

				//Begin Checks
				CheckConstraints(modifiedMaterial);

				if (!Exists(modifiedMaterial))
					throw new BusinessException(string.Format("There is no Material with this id. ({0})", modifiedMaterial));

				DataAccess.Materials materials = new DataAccess.Materials();
				materials.Modify(modifiedMaterial);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, modifiedMaterial);
				throw;
			}
		}
		
		/// <summary>
		/// Modify only the specified properties of the Material 
		/// specified by:
		/// </summary>
		/// <param name="id">PK</param>
	    /// <param name="propValues">Properties to change</param>
		public virtual void Modify(Int32 id,  params KeyValuePair<string,object>[] propValues)
		{
			try
			{
				Trace.WriteInformation("({0}, {1})", Trace.GetMethodName(), CLASSNAME, id, string.Join(",", propValues));

				DataAccess.Materials materials = new DataAccess.Materials();
				materials.Modify(
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
		/// Get all Material records from the database
		/// </summary>
		public virtual List<Model.Material> GetAll()
		{
			try
			{
				DataAccess.Materials materials = new DataAccess.Materials();
				List<Model.Material> result = materials.GetAll();

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		/// <summary>
		/// Get a Material by id from the database
		/// </summary>
		public virtual Model.Material GetById(Int32 id)
		{
		  try
			{
		    DataAccess.Materials materials = new DataAccess.Materials();
				Model.Material result = materials.GetById(id);
			  return result;
			}
			catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
			  throw;
			}
		}


		/// <summary>
		/// Get a Material by MaterialGroupId from the database
		/// </summary>
		public virtual List<Model.Material> GetByMaterialGroupId(Int32 materialGroupId)
		{
			try
			{
				DataAccess.Materials materials = new DataAccess.Materials();
				List<Model.Material> result = materials.GetByMaterialGroupId(materialGroupId);

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, materialGroupId);
				throw;
			}
		}


		/// <summary>
		/// Equals function to compare class
		/// </summary> 
		public virtual bool Exists(Model.Material material)
		{
		  try
			{
				return (this.GetById(material.Id) != null);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, material);
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
				DataAccess.Materials materials = new DataAccess.Materials();
				return materials.GetById(id) != null;
			}
		  catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
				throw;
			}
		}    

	}
}