using System;
using System.Collections.Generic;
using Actemium.Data.Exceptions;
using Actemium.Diagnostics;
using Actemium.UserManagement2.Business;

namespace Actemium.L3IC.OrderManager.Business
{
	/// <summary>
	/// Business class for Orders (Generated by Gennie).
	/// Description: All production orders
	/// </summary>
	public sealed partial class Orders : OrdersGennie
	{
		private const string CLASSNAME = nameof(Orders);

		
		public static readonly Orders Instance = new Orders();
	}

	/// <summary>
	/// Business class for OrdersGennie (Generated by Gennie).
	/// </summary>
	public abstract class OrdersGennie
	{
		private const string CLASSNAME = nameof(OrdersGennie);
		
 		/// <summary>
		/// Add a new Order to the database
		/// </summary>
		public virtual Int32 Add(Model.Order newOrder)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, newOrder);

				CheckConstraints(newOrder);
				DataAccess.Orders orders = new DataAccess.Orders();

        return orders.Add(newOrder);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, newOrder);
        throw new BusinessException(string.Format("No related object found in {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, newOrder);
				throw;
			}
		}


		/// <summary>
		/// Check Datafield constraints
		/// </summary>
		protected virtual void CheckConstraints(Model.Order order)
		{
			//Range checks, etc checks go here
			if (order.Code == null)
			  throw new BusinessException(string.Format("Code may not be NULL. ({0})", order.Code));

			if (order.Code.Length > 50)
			  throw new BusinessException(string.Format("Code may not be longer than 50 characters. ({0})", order.Code));

			if (order.UOM == null)
			  throw new BusinessException(string.Format("UOM may not be NULL. ({0})", order.UOM));

			if (order.UOM.Length > 10)
			  throw new BusinessException(string.Format("UOM may not be longer than 10 characters. ({0})", order.UOM));

		}


		/// <summary>
		/// Delete the given Order from the database
		/// </summary>
		public virtual void Delete(Model.Order delOrder)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, delOrder);

				//Begin Checks
				if (!Exists(delOrder))
					throw new BusinessException(string.Format("There is no Order with this id. ({0})", delOrder));

				DataAccess.Orders orders = new DataAccess.Orders();
				orders.Delete(delOrder);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, delOrder);
        throw new BusinessException(string.Format("The Order is still used by {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, delOrder);
				throw;
			}
		}


		/// <summary>
		/// Modify the given Order in the database
		/// </summary>
		public virtual void Modify(Model.Order modifiedOrder)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, modifiedOrder);

				//Begin Checks
				CheckConstraints(modifiedOrder);

				if (!Exists(modifiedOrder))
					throw new BusinessException(string.Format("There is no Order with this id. ({0})", modifiedOrder));

				DataAccess.Orders orders = new DataAccess.Orders();
				orders.Modify(modifiedOrder);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, modifiedOrder);
				throw;
			}
		}
		
		/// <summary>
		/// Modify only the specified properties of the Order 
		/// specified by:
		/// </summary>
		/// <param name="id">PK</param>
	    /// <param name="propValues">Properties to change</param>
		public virtual void Modify(Int32 id,  params KeyValuePair<string,object>[] propValues)
		{
			try
			{
				Trace.WriteInformation("({0}, {1})", Trace.GetMethodName(), CLASSNAME, id, string.Join(",", propValues));

				DataAccess.Orders orders = new DataAccess.Orders();
				orders.Modify(
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
		/// Get all Order records from the database
		/// </summary>
		public virtual List<Model.Order> GetAll()
		{
			try
			{
				DataAccess.Orders orders = new DataAccess.Orders();
				List<Model.Order> result = orders.GetAll();

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		/// <summary>
		/// Get a Order by id from the database
		/// </summary>
		public virtual Model.Order GetById(Int32 id)
		{
		  try
			{
		    DataAccess.Orders orders = new DataAccess.Orders();
				Model.Order result = orders.GetById(id);
			  return result;
			}
			catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
			  throw;
			}
		}


		/// <summary>
		/// Get a Order by OrderMessageId from the database
		/// </summary>
		public virtual List<Model.Order> GetByOrderMessageId(Int32 orderMessageId)
		{
			try
			{
				DataAccess.Orders orders = new DataAccess.Orders();
				List<Model.Order> result = orders.GetByOrderMessageId(orderMessageId);

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, orderMessageId);
				throw;
			}
		}

		/// <summary>
		/// Get a Order by MaterialId from the database
		/// </summary>
		public virtual List<Model.Order> GetByMaterialId(Int32 materialId)
		{
			try
			{
				DataAccess.Orders orders = new DataAccess.Orders();
				List<Model.Order> result = orders.GetByMaterialId(materialId);

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, materialId);
				throw;
			}
		}

		/// <summary>
		/// Get a Order by ResourceId from the database
		/// </summary>
		public virtual List<Model.Order> GetByResourceId(Int32 resourceId)
		{
			try
			{
				DataAccess.Orders orders = new DataAccess.Orders();
				List<Model.Order> result = orders.GetByResourceId(resourceId);

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, resourceId);
				throw;
			}
		}


		/// <summary>
		/// Equals function to compare class
		/// </summary> 
		public virtual bool Exists(Model.Order order)
		{
		  try
			{
				return (this.GetById(order.Id) != null);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, order);
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
				DataAccess.Orders orders = new DataAccess.Orders();
				return orders.GetById(id) != null;
			}
		  catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
				throw;
			}
		}    

	}
}