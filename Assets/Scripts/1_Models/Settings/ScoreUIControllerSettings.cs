using System;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.models.settings
{
	[CreateAssetMenu(fileName = "ScoreUIControllerSettings.asset",
					 menuName = "Models/Settings/ScoreUIController")]
	[Serializable]
	public class ScoreUIControllerSettings : ScriptableObject, IScoreUIControllerSettings
	{
		[SerializeField]
		private GameObject iconPrefab;


		#region IScoreUIControllerSettings
		public GameObject IconPrefab {
			get {
				return iconPrefab; 
			}
		}
		#endregion
	}
}

