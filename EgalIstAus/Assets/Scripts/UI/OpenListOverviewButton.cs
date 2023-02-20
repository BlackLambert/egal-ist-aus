using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class OpenListOverviewButton : ElementUI
	{
        [SerializeField]
        private string _buttonID;
		[SerializeField]
		private ListOverviewUI _listOverviewPrefab;

        private Button _button;

		private void OnDestroy()
		{
			_button.clicked -= OnClick;
		}

		protected override void Init()
		{
			_button = Q<Button>(_buttonID);
			_button.clicked += OnClick;
		}

		private void OnClick()
		{
			ListOverviewUI listOverview = Instantiate(_listOverviewPrefab);
			listOverview.Create(Frame);
			Instances.Get<ContentContainer>().SetContent(listOverview);
		}
	}
}
