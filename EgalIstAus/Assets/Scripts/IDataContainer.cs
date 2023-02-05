using System;

namespace Application
{
    public interface IDataContainer<TData>
    {
        event Action OnChange;
        void Set(TData data);
        TData Get();
    }
}
