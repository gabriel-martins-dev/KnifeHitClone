using System;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.models.settings
{
	[CreateAssetMenu(fileName = "WeaponControllerSetting.asset",
					 menuName = "Models/Settings/WeaponController")]
	[Serializable]
	public class WeaponControllerSettings : ScriptableObject, IWeaponControllerSettings
	{
		[SerializeField]
		private GameObject weaponPrefab;
		[SerializeField]
		private Vector3  weaponSpawnPosition;

		#region IWeaponControllerSettings
		public GameObject WeaponPrefab {
			get { return weaponPrefab; }
		}

		public Vector3 WeaponSpawnPosition {
			get { return weaponSpawnPosition; }
		}
		#endregion
	}
}
