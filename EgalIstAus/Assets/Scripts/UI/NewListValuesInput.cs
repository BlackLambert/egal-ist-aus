using System;

namespace Application
{
    public interface NewListValuesInput
    {
        event Action OnIsValidChanged;
        bool IsValid { get; }
        string Name { get; }
    }
}
