using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public abstract class BaseUI : MonoBehaviour
    {
        public abstract VisualElement RootElement { get; }
        public abstract FrameUI Frame { get; }
        public abstract InstancesContainer Instances { get; }

        public T Q<T>(string iD) where T : VisualElement
		{
            T result = RootElement.Q<T>(iD);
            if (result != null)
                return result;
            throw new ArgumentException($"There is not UI element with the ID {iD}.");
        }
	}
}
