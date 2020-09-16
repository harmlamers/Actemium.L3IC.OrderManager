using System;

namespace Actemium.ApplicationSettings.Model
{

	/// <summary>
	/// Object model class for ApplicationSettings
	/// </summary>
	[Serializable]
	public partial class ApplicationSetting : ApplicationSettingGennie
  {
		private const string CLASSNAME = nameof(ApplicationSetting);

		public ApplicationSetting() : base() { }

		public ApplicationSetting(Int32 applicationSettingId, Int32 applicationSettingsCategoryId, String name, String description, Int32 dataTypeId, String value, Int32? listId)
			: base(applicationSettingId, applicationSettingsCategoryId, name, description, dataTypeId, value, listId)
		{

		}
  }


	/// <summary>
	/// Object model class for ApplicationSettingsGennie (Generated by Gennie)
	/// </summary>
	[Serializable]
	public abstract class ApplicationSettingGennie
	{
		private const string CLASSNAME = nameof(ApplicationSettingGennie);


		/// <summary>
		/// Default constructor
		/// </summary>
		public ApplicationSettingGennie()
		{
		    //Empty constructor
		}


		/// <summary>
		/// Constructor with all parameters
		/// </summary>
		public ApplicationSettingGennie(Int32 applicationSettingId, Int32 applicationSettingsCategoryId, String name, String description, Int32 dataTypeId, String value, Int32? listId)
		{
			_applicationSettingId = applicationSettingId;
			_applicationSettingsCategoryId = applicationSettingsCategoryId;
			_name = name;
			_description = description;
			_dataTypeId = dataTypeId;
			_value = value;
			_listId = listId;
		}


		/// <summary>
		/// Property: ApplicationSettingId
		/// </summary>
    public Int32 ApplicationSettingId
		{
			set { _applicationSettingId = value; }
			get { return _applicationSettingId; }
		} protected Int32 _applicationSettingId;


		/// <summary>
		/// Property: ApplicationSettingsCategoryId
		/// </summary>
    public Int32 ApplicationSettingsCategoryId
		{
			set { _applicationSettingsCategoryId = value; }
			get { return _applicationSettingsCategoryId; }
		} protected Int32 _applicationSettingsCategoryId;


		/// <summary>
		/// Property: Name
		/// </summary>
    public String Name
		{
			set { _name = value; }
			get { return _name; }
		} protected String _name;


		/// <summary>
		/// Property: Description
		/// </summary>
    public String Description
		{
			set { _description = value; }
			get { return _description; }
		} protected String _description;


		/// <summary>
		/// Property: DataTypeId
		/// </summary>
    public Int32 DataTypeId
		{
			set { _dataTypeId = value; }
			get { return _dataTypeId; }
		} protected Int32 _dataTypeId;


		/// <summary>
		/// Property: Value
		/// </summary>
    public String Value
		{
			set { _value = value; }
			get { return _value; }
		} protected String _value;


		/// <summary>
		/// Property: ListId
		/// </summary>
    public Int32? ListId
		{
			set { _listId = value; }
			get { return _listId; }
		} protected Int32? _listId;


    /// <summary>
		/// Override the default ToString function to show all properties of the class
		/// </summary>
    public override string ToString()
    {
      return string.Format("ApplicationSetting:ApplicationSettingId={0}, ApplicationSettingsCategoryId={1}, Name={2}, Description={3}, DataTypeId={4}, Value={5}, ListId={6}", 
			_applicationSettingId, _applicationSettingsCategoryId, _name, _description, _dataTypeId, _value, _listId);
    }
    
    
		/// <summary>
		/// Override the default Equals function to compare class
		/// </summary>    
    public override bool Equals(object obj)
    {
			if (obj is Int32)
			{
				return (ApplicationSettingId == (Int32)obj);
			}
			else
				if (obj is ApplicationSetting)
					return Equals((ApplicationSetting)obj);
			return false;

		}


		/// <summary>
		/// Equals function to compare class
		/// </summary>    
		public virtual bool Equals(ApplicationSetting obj)
		{
			return ((this.ApplicationSettingId.Equals(((ApplicationSetting)obj).ApplicationSettingId)));
		}


		/// <summary>
		/// Override the default GetHashCode
		/// </summary> 
		public override int GetHashCode()
		{
		  int result = 0;
		  result = ApplicationSettingId.GetHashCode();

		  return result;
		}
		
  }
}