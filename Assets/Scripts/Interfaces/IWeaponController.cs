using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.models.settings;

namespace context.gameplay.interfaces 
{
	public interface IWeaponController 
	{
		void Initialize(IWeaponControllerSettings settings, IPoolService weaponsPool);
		void Attack();
	}
}