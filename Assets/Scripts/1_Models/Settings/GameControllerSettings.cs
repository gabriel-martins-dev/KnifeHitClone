using System;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.models.settings
{
	[CreateAssetMenu(fileName = "GameControllerSetting.asset",
					 menuName = "Models/Settings/GameController")]
	[Serializable]
	public class GameControllerSettings : ScriptableObject, IGameControllerSettings
	{
		[SerializeField]
		private int numberOfTries;
		[SerializeField]
		private WeaponControllerSettings  weaponSettings;
		[SerializeField]
		private TargetControllerSettings  targetSettings;
	
		#region IGameControllerSettings
		public int NumberOfTries {
			get { return numberOfTries; }
		}

		public IWeaponControllerSettings WeaponSettings { 
			get { return weaponSettings; } 
		}

		public ITargetControllerSettings TargetSettings { 
			get { return targetSettings; } 
		}
		#endregion
	}
}
