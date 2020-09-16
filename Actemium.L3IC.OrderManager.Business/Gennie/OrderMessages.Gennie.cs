using System;
using System.Collections.Generic;
using Actemium.Data.Exceptions;
using Actemium.Diagnostics;
using Actemium.UserManagement2.Business;

namespace Actemium.L3IC.OrderManager.Business
{
	/// <summary>
	/// Business class for OrderMessages (Generated by Gennie).
	/// Description: Logging of all messages that have been received for orders from an external system
	/// </summary>
	public sealed partial class OrderMessages : OrderMessagesGennie
	{
		private const string CLASSNAME = nameof(OrderMessages);

		
		public static readonly OrderMessages Instance = new OrderMessages();
	}

	/// <summary>
	/// Business class for OrderMessagesGennie (Generated by Gennie).
	/// </summary>
	public abstract class OrderMessagesGennie
	{
		private const string CLASSNAME = nameof(OrderMessagesGennie);
		
 		/// <summary>
		/// Add a new OrderMessage to the database
		/// </summary>
		public virtual Int32 Add(Model.OrderMessage newOrderMessage)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, newOrderMessage);

				CheckConstraints(newOrderMessage);
				DataAccess.OrderMessages orderMessages = new DataAccess.OrderMessages();

        return orderMessages.Add(newOrderMessage);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, newOrderMessage);
        throw new BusinessException(string.Format("No related object found in {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, newOrderMessage);
				throw;
			}
		}


		/// <summary>
		/// Check Datafield constraints
		/// </summary>
		protected virtual void CheckConstraints(Model.OrderMessage orderMessage)
		{
			//Range checks, etc checks go here
			if (orderMessage.Code == null)
			  throw new BusinessException(string.Format("Code may not be NULL. ({0})", orderMessage.Code));

			if (orderMessage.Code.Length > 50)
			  throw new BusinessException(string.Format("Code may not be longer than 50 characters. ({0})", orderMessage.Code));

		}


		/// <summary>
		/// Delete the given OrderMessage from the database
		/// </summary>
		public virtual void Delete(Model.OrderMessage delOrderMessage)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, delOrderMessage);

				//Begin Checks
				if (!Exists(delOrderMessage))
					throw new BusinessException(string.Format("There is no OrderMessage with this id. ({0})", delOrderMessage));

				DataAccess.OrderMessages orderMessages = new DataAccess.OrderMessages();
				orderMessages.Delete(delOrderMessage);
			}
			catch (DalForeignKeyException ex_fk)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex_fk, delOrderMessage);
        throw new BusinessException(string.Format("The OrderMessage is still used by {0}", ex_fk.Table), ex_fk);
      }
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, delOrderMessage);
				throw;
			}
		}


		/// <summary>
		/// Modify the given OrderMessage in the database
		/// </summary>
		public virtual void Modify(Model.OrderMessage modifiedOrderMessage)
		{
			try
			{
				Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, modifiedOrderMessage);

				//Begin Checks
				CheckConstraints(modifiedOrderMessage);

				if (!Exists(modifiedOrderMessage))
					throw new BusinessException(string.Format("There is no OrderMessage with this id. ({0})", modifiedOrderMessage));

				DataAccess.OrderMessages orderMessages = new DataAccess.OrderMessages();
				orderMessages.Modify(modifiedOrderMessage);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, modifiedOrderMessage);
				throw;
			}
		}
		
		/// <summary>
		/// Modify only the specified properties of the OrderMessage 
		/// specified by:
		/// </summary>
		/// <param name="id">PK</param>
	    /// <param name="propValues">Properties to change</param>
		public virtual void Modify(Int32 id,  params KeyValuePair<string,object>[] propValues)
		{
			try
			{
				Trace.WriteInformation("({0}, {1})", Trace.GetMethodName(), CLASSNAME, id, string.Join(",", propValues));

				DataAccess.OrderMessages orderMessages = new DataAccess.OrderMessages();
				orderMessages.Modify(
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
		/// Get all OrderMessage records from the database
		/// </summary>
		public virtual List<Model.OrderMessage> GetAll()
		{
			try
			{
				DataAccess.OrderMessages orderMessages = new DataAccess.OrderMessages();
				List<Model.OrderMessage> result = orderMessages.GetAll();

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		/// <summary>
		/// Get a OrderMessage by id from the database
		/// </summary>
		public virtual Model.OrderMessage GetById(Int32 id)
		{
		  try
			{
		    DataAccess.OrderMessages orderMessages = new DataAccess.OrderMessages();
				Model.OrderMessage result = orderMessages.GetById(id);
			  return result;
			}
			catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
			  throw;
			}
		}



		/// <summary>
		/// Equals function to compare class
		/// </summary> 
		public virtual bool Exists(Model.OrderMessage orderMessage)
		{
		  try
			{
				return (this.GetById(orderMessage.Id) != null);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, orderMessage);
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
				DataAccess.OrderMessages orderMessages = new DataAccess.OrderMessages();
				return orderMessages.GetById(id) != null;
			}
		  catch (Exception ex)
			{
			  Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, id);
				throw;
			}
		}    

	}
}