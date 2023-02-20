using System;

namespace Application
{
	public class ListsOverviewElement : ElementUI
	{
		public EntryList List { get; private set; }
		public event Action OnListChanged;

		public void Init(EntryList list)
		{
			List = list;
			OnListChanged?.Invoke();
		}

		protected override void Init()
		{
			
		}
	}
}
