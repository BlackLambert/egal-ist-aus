using System;

namespace Application
{
    public interface NewEntryValuesInput
    {
        event Action OnIsValidChanged;
        bool IsValid { get; }
        string Name { get; }
    }
}
