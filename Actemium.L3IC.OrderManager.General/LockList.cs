using System.Collections.Generic;

namespace Actemium.L3IC.OrderManager.General
{
  public class LockList<T>
	{
		private readonly object _lock = new object();
		private List<T> _list = new List<T>();

		public LockList()
		{
			List = new List<T>();
		}

		public List<T> List
		{
			get
			{
				lock (_lock)
				{
					return _list;
				}
			}
			set
			{
				lock (_lock)
				{
					_list = value;
				}
			}
		}
	}
}
