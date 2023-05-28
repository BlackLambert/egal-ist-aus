using SBaier.DI;

namespace Application
{
    public class EntriesAmountDisplay : Label, Injectable
    {
		private EntriesService _entriesService;
		private ListsService _listsService;

		public void Inject(Resolver resolver)
		{
			_entriesService = resolver.Resolve<EntriesService>();
			_listsService = resolver.Resolve<ListsService>();
		}

		protected override void Start()
		{
			base.Start();
			_entriesService.OnChange += UpdateText;
			_listsService.OnCurrentChange += UpdateText;
		}

		private void OnDestroy()
		{
			_entriesService.OnChange -= UpdateText;
			_listsService.OnCurrentChange -= UpdateText;
		}

		protected override string GetText()
		{
			return $"({_entriesService.Amount})";
		}
    }
}
