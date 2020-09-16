﻿using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Actemium.Diagnostics;
using Actemium.Data.Common;
using Actemium.Data.Exceptions;

namespace Actemium.History.DataAccess
{
	/// <summary>
	/// Data access to the data in table HistoryActions in the database (Generated by Gennie)
	/// </summary>
	public partial class HistoryActions : HistoryActionsGennie
	{
		private const string CLASSNAME = nameof(HistoryActions);

	}

	/// <summary>
	/// Data access to the data in table HistoryActionsGennie in the database (Generated by Gennie)
	/// </summary>
	public abstract class HistoryActionsGennie
	{
		private const string CLASSNAME = nameof(HistoryActionsGennie);


		/// <summary>
		/// Add a new HistoryAction to the database
		/// </summary>
		public virtual Int64 Add(Model.HistoryAction newHistoryAction)
		{
			try
			{
				Trace.WriteVerbose("({0})", "Add", CLASSNAME, newHistoryAction.ToString());
				var helper = Database.GetDbHelper();
				DbParameter HistoryActionIdParam = helper.CreateOutputParam("@HistoryActionId", DbType.Int64);

				int recordsAffected = helper.ExecuteSPNonQuery(_storedProcedure_Add,
					HistoryActionIdParam,
					helper.CreateInputParam("@HistoryKey", newHistoryAction.HistoryKey),
					helper.CreateInputParam("@TimeStampUTC", newHistoryAction.TimeStampUTC),
					helper.CreateInputParam("@UserId", newHistoryAction.UserId.HasValue ? (object)newHistoryAction.UserId : DBNull.Value),
					helper.CreateInputParam("@ComputerId", newHistoryAction.ComputerId.HasValue ? (object)newHistoryAction.ComputerId : DBNull.Value),
					helper.CreateInputParam("@Parameters", newHistoryAction.Parameters != null ? (object)newHistoryAction.Parameters : DBNull.Value));

				if (recordsAffected == 0)
					throw new DalNothingUpdatedException("Unable to add HistoryAction with HistoryActionId={0}", newHistoryAction);

				return (Int64)HistoryActionIdParam.Value;
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", "Add", CLASSNAME, ex, newHistoryAction.ToString());
				throw DbHelper.TranslateException(ex);
			}
		}

    /// <summary>
    /// String containing stored procedure name
    /// </summary>
		protected string _storedProcedure_Add = "[HIST].[HistoryActionsGennie_Add]";
		


		/// <summary>
		/// Delete the given HistoryAction from the database
		/// </summary>
		public virtual void Delete(Model.HistoryAction historyAction)
		{
			try
			{
				Trace.WriteVerbose("({0})", "Delete", CLASSNAME, historyAction.ToString());

        var helper = Database.GetDbHelper();
				helper.ExecuteSPNonQuery(_storedProcedure_Delete,
					helper.CreateInputParam("@HistoryActionId", historyAction.HistoryActionId));
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", "Delete", CLASSNAME, ex, historyAction.ToString());
				throw DbHelper.TranslateException(ex);
			}
		}

    /// <summary>
    /// String containing stored procedure name
    /// </summary>
		protected string _storedProcedure_Delete = "[HIST].[HistoryActionsGennie_Delete]";



		/// <summary>
		/// Modify the given HistoryAction in the database
		/// </summary>
		public virtual void Modify(Model.HistoryAction modifiedHistoryAction)
		{
			try
			{
				Trace.WriteVerbose("({0})", "Modify", CLASSNAME, modifiedHistoryAction.ToString());

				var helper = Database.GetDbHelper();
        int recordsAffected = helper.ExecuteSPNonQuery(_storedProcedure_Modify,
					helper.CreateInputParam("@HistoryActionId", modifiedHistoryAction.HistoryActionId),
					helper.CreateInputParam("@HistoryKey", modifiedHistoryAction.HistoryKey),
					helper.CreateInputParam("@TimeStampUTC", modifiedHistoryAction.TimeStampUTC),
					helper.CreateInputParam("@UserId", modifiedHistoryAction.UserId.HasValue ? (object)modifiedHistoryAction.UserId : DBNull.Value),
					helper.CreateInputParam("@ComputerId", modifiedHistoryAction.ComputerId.HasValue ? (object)modifiedHistoryAction.ComputerId : DBNull.Value),
					helper.CreateInputParam("@Parameters", modifiedHistoryAction.Parameters != null ? (object)modifiedHistoryAction.Parameters : DBNull.Value));

				if (recordsAffected == 0)
				{
					throw new DalNothingUpdatedException("No records were updated (Table: HistoryActions). HistoryAction=" + modifiedHistoryAction.ToString());
				}
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", "Modify", CLASSNAME, ex, modifiedHistoryAction.ToString());
				throw DbHelper.TranslateException(ex);
			}
		}
		
            /// <summary>
            /// String containing stored procedure name
            /// </summary>
	    protected string _storedProcedure_Modify = "[HIST].[HistoryActionsGennie_Modify]";
		
	/// <summary>
	/// Modify only the specified properties of the HistoryAction 
	/// specified by:
	/// </summary>
		/// <param name="historyActionId">PK</param>
	/// <param name="propValues">Properties to update</param>
		public virtual void Modify( Int64 historyActionId,  params KeyValuePair<string,object>[] propValues)
		{
			 try
      {
        Trace.WriteVerbose("({0})", "Modify", CLASSNAME, historyActionId);
        
        if (propValues.Length == 0)
        {
			Trace.WriteVerbose("No properties to update.", "Modify", CLASSNAME);
			return;
		}
        
        var helper = Database.GetDbHelper();
        StringBuilder sqlStatement =  new StringBuilder("UPDATE [HIST].[HistoryActions] SET ");
        List<DbParameter> parameterList = new List<DbParameter>();
        for (int i = 0; i < propValues.Length ; i++)
        { 
          sqlStatement.AppendFormat( "[{0}]=@{0}", propValues[i].Key);
          if (i< propValues.Length -1)
            sqlStatement.Append( ", ");

          parameterList.Add(helper.CreateInputParam("@" + propValues[i].Key, propValues[i].Value ?? DBNull.Value));
          
        }
        sqlStatement.Append(" WHERE ");
         sqlStatement.Append("[HistoryActionId]=@HistoryActionId");
			     parameterList.Add( helper.CreateInputParam("@HistoryActionId", historyActionId));
			

              int recordsAffected = helper.ExecuteText(sqlStatement.ToString(),
                                              parameterList.ToArray());
        
        if (recordsAffected == 0)
        {
          throw new DalNothingUpdatedException(string.Format("No records were updated (Table: HistoryActions). Id={0}", historyActionId));
        }

      }
      catch (Exception ex)
      {
        Trace.WriteError("({0})", "Modify", CLASSNAME, ex, historyActionId);
        throw DbHelper.TranslateException(ex);
      }

      }



		/// <summary>
		/// Get a HistoryAction by id from the database
		/// </summary>
		public virtual Model.HistoryAction GetById(Int64 historyActionId)
		{
			DbDataReader reader = null;
			try
			{
        var helper = Database.GetDbHelper();
                
        reader = helper.ExecuteSPReader(_storedProcedure_GetById,
					helper.CreateInputParam("@HistoryActionId", historyActionId));
				
				Model.HistoryAction result = null;

				if (reader.Read())
          result = CreateHistoryAction(reader);

				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("{0}", "GetById", CLASSNAME, ex, historyActionId);
				throw DbHelper.TranslateException(ex);
			}
			finally 
			{
				reader?.Close();
			}
		}
		
    /// <summary>
    /// String containing stored procedure name
    /// </summary>
		protected string _storedProcedure_GetById = "[HIST].[HistoryActionsGennie_GetById]";



		/// <summary>
		/// Get a HistoryAction by HistoryKey from the database
		/// </summary>
		public virtual List<Model.HistoryAction> GetByHistoryKey(String historyKey)
		{
			DbDataReader reader = null;
			try
			{
        var helper = Database.GetDbHelper();
        reader = helper.ExecuteSPReader(_storedProcedure_GetByHistoryKey, 
					helper.CreateInputParam("@HistoryKey", historyKey));
                
        List<Model.HistoryAction> result = new List<Model.HistoryAction>();
				while (reader.Read())
				{
				  result.Add(CreateHistoryAction(reader));
				}
				return result;

			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", "GetByHistoryKey", CLASSNAME, ex, historyKey);
				throw DbHelper.TranslateException(ex);
			}
			finally 
			{
				reader?.Close();
			}
		}
		
		/// <summary>
    /// String containing stored procedure name
    /// </summary>
		protected string _storedProcedure_GetByHistoryKey = "[HIST].[HistoryActionsGennie_GetByHistoryKey]";
		
		

		/// <summary>
		/// Get a HistoryAction by UserId from the database
		/// </summary>
		public virtual List<Model.HistoryAction> GetByUserId(Int32 userId)
		{
			DbDataReader reader = null;
			try
			{
        var helper = Database.GetDbHelper();
        reader = helper.ExecuteSPReader(_storedProcedure_GetByUserId, 
					helper.CreateInputParam("@UserId", userId));
                
        List<Model.HistoryAction> result = new List<Model.HistoryAction>();
				while (reader.Read())
				{
				  result.Add(CreateHistoryAction(reader));
				}
				return result;

			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", "GetByUserId", CLASSNAME, ex, userId);
				throw DbHelper.TranslateException(ex);
			}
			finally 
			{
				reader?.Close();
			}
		}
		
		/// <summary>
    /// String containing stored procedure name
    /// </summary>
		protected string _storedProcedure_GetByUserId = "[HIST].[HistoryActionsGennie_GetByUserId]";
		
		

		/// <summary>
		/// Get a HistoryAction by ComputerId from the database
		/// </summary>
		public virtual List<Model.HistoryAction> GetByComputerId(Int32 computerId)
		{
			DbDataReader reader = null;
			try
			{
        var helper = Database.GetDbHelper();
        reader = helper.ExecuteSPReader(_storedProcedure_GetByComputerId, 
					helper.CreateInputParam("@ComputerId", computerId));
                
        List<Model.HistoryAction> result = new List<Model.HistoryAction>();
				while (reader.Read())
				{
				  result.Add(CreateHistoryAction(reader));
				}
				return result;

			}
			catch (Exception ex)
			{
				Trace.WriteError("({0})", "GetByComputerId", CLASSNAME, ex, computerId);
				throw DbHelper.TranslateException(ex);
			}
			finally 
			{
				reader?.Close();
			}
		}
		
		/// <summary>
    /// String containing stored procedure name
    /// </summary>
		protected string _storedProcedure_GetByComputerId = "[HIST].[HistoryActionsGennie_GetByComputerId]";
		
		
		
		/// <summary>
		/// Get all HistoryAction records from the database
		/// </summary>
		public virtual List<Model.HistoryAction> GetAll()
		{
			DbDataReader reader = null;
			try
			{
        var helper = Database.GetDbHelper();
        reader = helper.ExecuteSPReader(_storedProcedure_GetAll);
								
				List<Model.HistoryAction> result = new List<Model.HistoryAction>();
				while (reader.Read())
				{
				  result.Add(CreateHistoryAction(reader));
				}
				
				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", "GetAll", CLASSNAME, ex);
				throw DbHelper.TranslateException(ex);
			}
			finally 
			{
				reader?.Close();
			}
		}
		
		/// <summary>
    /// String containing stored procedure name
    /// </summary>
		protected string _storedProcedure_GetAll = "[HIST].[HistoryActionsGennie_GetAll]";
		
		
		
		/// <summary>
		/// Create a Model.HistoryAction
		/// </summary>
		protected virtual Model.HistoryAction CreateHistoryAction(DbDataReader reader)
		{
			try
			{	
        Model.HistoryAction result = new Model.HistoryAction(
          (Int64)reader["HistoryActionId"], 
          (String)reader["HistoryKey"], 
          (DateTime)reader["TimeStampUTC"], 
          reader["UserId"] != DBNull.Value ? (Int32?)          reader["UserId"] : null, 
          reader["ComputerId"] != DBNull.Value ? (Int32?)          reader["ComputerId"] : null, 
          reader["Parameters"] != DBNull.Value ? (String)          reader["Parameters"] : null
						);
				return result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("", "CreateHistoryAction", CLASSNAME, ex);
				throw DbHelper.TranslateException(ex);
			}
		}	
	}
}
