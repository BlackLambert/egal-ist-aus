using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class OpenListOverviewButton : MonoBehaviour
    {
        [SerializeField]
        private BaseUI _ui;
        [SerializeField]
        private string _buttonID;
		[SerializeField]
		private ListOverviewUI _listOverviewPrefab;

        private Button _button;

		private void Start()
		{
            _button = _ui.Q<Button>(_buttonID);
            _button.clicked += OnClick;
        }

		private void OnDestroy()
		{
			_button.clicked -= OnClick;
		}

		private void OnClick()
		{
			ListOverviewUI listOverview = Instantiate(_listOverviewPrefab);
			listOverview.Create(_ui.Frame);
			_ui.Instances.Get<ContentContainer>().SetContent(listOverview);
		}
	}
}
