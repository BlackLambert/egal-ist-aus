namespace Application
{
	public class AddListButton : BaseButton
	{
		private ListsService _listsService;
		private NewListValuesInput _valuesInput;

		protected override void Start()
		{
			base.Start();
			_listsService = FindObjectOfType<ListsService>();
			_valuesInput = _ui.Instances.Get<NewListValuesInput>();
			_valuesInput.OnIsValidChanged += CheckButtonEnabled;
			CheckButtonEnabled();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		protected override void OnClick()
		{
			_listsService.Add(_valuesInput.Name);
			CheckButtonEnabled();
		}

		private void CheckButtonEnabled()
		{
			_button.SetEnabled(_valuesInput.IsValid);
		}
	}
}
