namespace Application
{
	public interface InstancesContainer
	{
		TContract Get<TContract>();
		void Register<TContract, TConcete>(TConcete instance) where TConcete : TContract;
	}
}