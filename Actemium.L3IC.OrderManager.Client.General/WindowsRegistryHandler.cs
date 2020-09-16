using System;

namespace Actemium.L3IC.OrderManager.Client.General
{
  public class SavedUser
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public int LastPage { get; set; }

		public SavedUser(string username, string password)
			: this(username, password, -1)
		{
		}

		public SavedUser(string username, string password, int lastPage)
		{
			Username = username;
			Password = password;
			LastPage = lastPage;
		}

		public override String ToString()
		{
			return $"SavedUser:Username='{Username}', Password='***', LastPage='{LastPage.ToString()}'";
		}
	}
}
