using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface IGameControllerSettings 
	{
		int NumberOfTries{ get; }

		IWeaponControllerSettings WeaponSettings { get; }
		ITargetControllerSettings TargetSettings { get; }
	}
}
