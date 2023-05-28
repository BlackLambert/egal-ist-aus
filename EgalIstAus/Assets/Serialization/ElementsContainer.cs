using System;
using System.Collections.Generic;

namespace Application
{
    public interface ElementsContainer<TElement>
    {
        event Action<TElement> OnAdded;
        event Action<TElement> OnRemoved;
        IReadOnlyCollection<TElement> Elements { get; }
    }
}
