using UnityEngine;

namespace Application
{
	public class ListOverviewUI : ElementUI, ContentUI
	{
		public Transform RootTransform => transform;
		public string Title => "Your Lists";

		protected override void Init()
		{
			
		}
	}
}
