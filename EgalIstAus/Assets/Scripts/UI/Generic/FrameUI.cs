using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
	public class FrameUI : BaseUI
	{
		[SerializeField]
		private UIDocument _uiDocument;

		public override VisualElement RootElement => _uiDocument.rootVisualElement;
		public override FrameUI Frame => this;
		public override InstancesContainer Instances => instances;

		private InstancesContainer instances;

		protected virtual void Awake()
		{
			instances = new BasicInstancesContainer();
		}

		protected virtual void Reset()
		{
			_uiDocument = GetComponent<UIDocument>();
		}
	}
}
