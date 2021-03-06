﻿using System;

namespace Actemium.History.Model
{

	/// <summary>
	/// Object model class for HistoryActions
	/// </summary>
	[Serializable]
	public partial class HistoryAction : HistoryActionGennie
  {
		private const string CLASSNAME = nameof(HistoryAction);

		public HistoryAction() : base() { }

		public HistoryAction(Int64 historyActionId, String historyKey, DateTime timeStampUTC, Int32? userId, Int32? computerId, String parameters)
			: base(historyActionId, historyKey, timeStampUTC, userId, computerId, parameters)
		{

		}
  }


	/// <summary>
	/// Object model class for HistoryActionsGennie (Generated by Gennie)
	/// </summary>
	[Serializable]
	public abstract class HistoryActionGennie
	{
		private const string CLASSNAME = nameof(HistoryActionGennie);


		/// <summary>
		/// Default constructor
		/// </summary>
		public HistoryActionGennie()
		{
		    //Empty constructor
		}


		/// <summary>
		/// Constructor with all parameters
		/// </summary>
		public HistoryActionGennie(Int64 historyActionId, String historyKey, DateTime timeStampUTC, Int32? userId, Int32? computerId, String parameters)
		{
			_historyActionId = historyActionId;
			_historyKey = historyKey;
			_timeStampUTC = timeStampUTC;
			_userId = userId;
			_computerId = computerId;
			_parameters = parameters;
		}


		/// <summary>
		/// Property: HistoryActionId
		/// </summary>
    public Int64 HistoryActionId
		{
			set { _historyActionId = value; }
			get { return _historyActionId; }
		} protected Int64 _historyActionId;


		/// <summary>
		/// Property: HistoryKey
		/// </summary>
    public String HistoryKey
		{
			set { _historyKey = value; }
			get { return _historyKey; }
		} protected String _historyKey;


		/// <summary>
		/// Property: TimeStampUTC
		/// </summary>
    public DateTime TimeStampUTC
		{
			set { _timeStampUTC = value; }
			get { return _timeStampUTC; }
		} protected DateTime _timeStampUTC;


		/// <summary>
		/// Property: UserId
		/// </summary>
    public Int32? UserId
		{
			set { _userId = value; }
			get { return _userId; }
		} protected Int32? _userId;


		/// <summary>
		/// Property: ComputerId
		/// </summary>
    public Int32? ComputerId
		{
			set { _computerId = value; }
			get { return _computerId; }
		} protected Int32? _computerId;


		/// <summary>
		/// Property: Parameters
		/// </summary>
    public String Parameters
		{
			set { _parameters = value; }
			get { return _parameters; }
		} protected String _parameters;


    /// <summary>
		/// Override the default ToString function to show all properties of the class
		/// </summary>
    public override string ToString()
    {
      return string.Format("HistoryAction:HistoryActionId={0}, HistoryKey={1}, TimeStampUTC={2}, UserId={3}, ComputerId={4}, Parameters={5}", 
			_historyActionId, _historyKey, _timeStampUTC, _userId, _computerId, _parameters);
    }
    
    
		/// <summary>
		/// Override the default Equals function to compare class
		/// </summary>    
    public override bool Equals(object obj)
    {
      if (obj is Int64)
      {
        return (HistoryActionId == (Int64)obj);
      }
      else
        if (obj is HistoryAction)
      {
        return Equals((HistoryAction)obj);
      }

      return false;

		}


		/// <summary>
		/// Equals function to compare class
		/// </summary>    
		public virtual bool Equals(HistoryAction obj)
		{
			return ((this.HistoryActionId.Equals(obj.HistoryActionId)));
		}


		/// <summary>
		/// Override the default GetHashCode
		/// </summary> 
		public override int GetHashCode()
		{
		  return HistoryActionId.GetHashCode();
    }
		
  }
}
