using SBaier.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Application
{
    public class StylesInstaller : MonoInstaller
    {
        [SerializeField]
        private TextStyles _styles;

		public override void InstallBindings(Binder binder)
		{
			binder.BindInstance(_styles);
		}
	}
}
