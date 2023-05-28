using SBaier.DI;

namespace Application
{
    public class SelectedEntryNameDisplay : Label, Injectable
    {
		private Container<Entry> _entryContainer;

		public void Inject(Resolver resolver)
		{
			_entryContainer = resolver.Resolve<Container<Entry>>();
		}

		protected override void Start()
		{
			base.Start();
			_entryContainer.OnChange += UpdateText;
		}

		private void OnDestroy()
		{
			_entryContainer.OnChange -= UpdateText;
		}

		protected override string GetText()
		{
			return !_entryContainer.IsEmpty ? _entryContainer.Item.Name : string.Empty;
		}
	}
}
