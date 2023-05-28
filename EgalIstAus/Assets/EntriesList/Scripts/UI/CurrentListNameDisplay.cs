using SBaier.DI;

namespace Application
{
    public class CurrentListNameDisplay : Label, Injectable
    {
		private ListsService _listsService;

		public void Inject(Resolver resolver)
		{
			_listsService = resolver.Resolve<ListsService>();
		}

		protected override void Start()
		{
			base.Start();
			_listsService.OnCurrentChange += UpdateText;
		}

		private void OnDestroy()
		{
			_listsService.OnCurrentChange -= UpdateText;
		}

		protected override string GetText()
		{
			return _listsService.CurrentListName;
		}
	}
}
