using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public abstract class ElementUI : BaseUI
    {
        [SerializeField]
        private VisualTreeAsset _visualTreeAsset;

        public override VisualElement RootElement => _rootElement;
        public override FrameUI Frame => _frame;
		public override InstancesContainer Instances => _frame.Instances;

		protected InstancesContainer instances => Frame.Instances;
        private VisualElement _rootElement;
        private FrameUI _frame;

        public void Create(FrameUI frameUI, VisualElement parent = null)
        {
            _frame = frameUI;
            _rootElement = _visualTreeAsset.Instantiate();
            if(parent != null)
                parent.Add(_rootElement);
            Init();
        }

        public void SetParent(VisualElement parent)
        {
            parent.Add(RootElement);
        }

        protected abstract void Init();
    }
}
