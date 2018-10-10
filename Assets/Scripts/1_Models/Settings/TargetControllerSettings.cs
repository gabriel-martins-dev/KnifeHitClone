using System;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.models.settings
{
	[CreateAssetMenu(fileName = "TargetControllerSettings.asset",
					 menuName = "Models/Settings/TargetController")]
	[Serializable]
	public class TargetControllerSettings : ScriptableObject, ITargetControllerSettings
	{
		[SerializeField]
		private Vector2 position;
		[SerializeField]
		private TargetControllerStageModel[] stageModel;

		#region ITargetControllerSettings
		public Vector2 Position {
			get { return position; }
		}

		public ITargetControllerStageModel[] StageModels {
			get { return stageModel; }
		}
		#endregion
	}
}

