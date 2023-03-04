using UnityEngine;

namespace Application
{
	public class CreateFrameButton : BaseButton
	{
		[SerializeField]
		private FrameUI _prefab;

		protected override void OnClick()
		{
			Instantiate(_prefab);
		}
	}
}
