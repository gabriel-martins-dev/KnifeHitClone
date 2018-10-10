using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface IGameControllerSettings 
	{
		IGameControllerTriesModel[] TriesModels { get; }
		IWeaponControllerSettings WeaponSettings { get; }
		ITargetControllerSettings TargetSettings { get; }
	}
}
