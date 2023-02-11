using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class MainFrameUI : FrameUI, ContentContainer
	{
        [SerializeField]
        private string _headerHookID = "HeaderHook";
        [SerializeField]
        private string _contentHookID = "ContentHook";
		[SerializeField]
		private HeaderUI _headerPrefab;

        private VisualElement _headerHook;
		private VisualElement _contentHook;
		private HeaderUI _header;
		private ContentUI _currentContent;

		protected override void Awake()
		{
			base.Awake();
			FindUI();
			CreateUI();
			Instances.Register<ContentContainer, MainFrameUI>(this);
			Instances.Register<FrameUI, MainFrameUI>(this);
		}

		private void FindUI()
		{
			_headerHook = Q<VisualElement>(_headerHookID);
			_contentHook = Q<VisualElement>(_contentHookID);
		}

		private void CreateUI()
		{
			_header = Instantiate(_headerPrefab);
			_header.Create(this, _headerHook);
			_header.transform.SetParent(transform);
		}

		public void SetContent(ContentUI content)
		{
			_contentHook.Clear();
			_currentContent = content;
			_currentContent.SetParent(_contentHook);
			content.RootTransform.SetParent(transform);
			_header.SetTitle(content.Title);
		}
	}
}
