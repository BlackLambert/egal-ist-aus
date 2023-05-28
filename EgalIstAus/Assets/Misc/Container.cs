using System;

namespace Application
{
    public class Container<TItem>
    {
        public event Action OnChange;
        public TItem Item { get; private set; }
        public bool IsEmpty => Item == null;

        public void Store(TItem item)
		{
            Item = item;
            OnChange?.Invoke();
        }
	}
}
