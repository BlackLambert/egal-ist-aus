using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public interface ContentUI
    {
        public Transform RootTransform { get; }
        public string Title { get; }
        public void SetParent(VisualElement parent);
    }
}
