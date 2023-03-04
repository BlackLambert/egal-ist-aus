using System;

namespace Application
{
    public interface DataContainer<TData>
    {
        event Action OnChange;
        void SetDefault();
        void Set(TData data);
        TData Get();
    }
}
