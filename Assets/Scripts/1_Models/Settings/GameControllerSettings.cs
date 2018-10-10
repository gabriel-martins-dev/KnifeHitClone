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


#region IGameControllerSettings
		public int NumberOfTries {
			get { return numberOfTries; }
		}
#endregion
	}
}
