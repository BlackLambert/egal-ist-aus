using UnityEngine;
using UnityEngine.UIElements;

namespace Application
{
    public class DestroyObjectButton : BaseButton
    {
        [SerializeField]
        private GameObject _objectToDestroy;

        protected override void OnClick()
		{
            Destroy(_objectToDestroy);
        }
    }
}
