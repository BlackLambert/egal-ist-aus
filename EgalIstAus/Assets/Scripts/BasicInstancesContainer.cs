using System;
using System.Collections.Generic;

namespace Application
{
	public class BasicInstancesContainer : InstancesContainer
	{
		private Dictionary<Type, object> _instances = new Dictionary<Type, object>();

		public void Register<TContract, TConcete>(TConcete instance) where TConcete : TContract
		{
			Type contract = typeof(TContract);
			if (_instances.ContainsKey(contract))
			{
				throw new ArgumentException($"There is already an instance of type {contract}");
			}
			_instances[contract] = instance;
		}

		public TContract Get<TContract>()
		{
			Type contract = typeof(TContract);
			if (!_instances.ContainsKey(contract))
			{
				throw new ArgumentException($"There is no instance of type {contract}");
			}
			return (TContract)_instances[contract];
		}
	}
}
