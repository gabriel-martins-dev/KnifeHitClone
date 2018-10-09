using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface IWeaponControllerSettings 
	{
		GameObject WeaponPrefab{ get; }
		Vector3 WeaponSpawnPosition{ get; }
	}
}
