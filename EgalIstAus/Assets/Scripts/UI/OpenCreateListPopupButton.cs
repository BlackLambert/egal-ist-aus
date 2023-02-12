using UnityEngine;

namespace Application
{
	public class OpenCreateListPopupButton : BaseButton
	{
		[SerializeField]
		private FrameUI _popupPrefab;

		protected override void OnClick()
		{
			Instantiate(_popupPrefab);
		}
	}
}
