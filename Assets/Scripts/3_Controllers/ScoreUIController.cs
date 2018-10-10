using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;
using context.gameplay.helpers;

namespace context.gameplay.controllers 
{
	public class ScoreUIController : MonoBehaviour, IScoreUIController 
	{
		private IScoreUIControllerSettings settings;
		private IPoolService poolService;
		private List<GameObject> icons;

		#region Methods
		private void UpdateIcons(IGameStartModel model) 
		{
			bool pull = model.numberOfTries > icons.Count;
			int amount = Math.Abs(model.numberOfTries - icons.Count);

			for (int i = 0; i < amount; i++) {
				if(pull) {
					var icon = poolService.Pop();
					icon.transform.SetParent(transform);
					icon.SetActive(true);
					icons.Add(icon);
				}	
				else {
					if(icons.Count - 1 < icons.Count) {
						poolService.Push(icons[icons.Count - 1]);
						icons.RemoveAt(icons.Count - 1);
					}
				}
			}
		}
		#endregion

		#region IScoreUIController
		public void Initialize(IScoreUIControllerSettings settings, IPoolService poolService) 
		{
			this.icons = new List<GameObject>();
			this.settings = settings;
			this.poolService = poolService;

			Messenger.AddListener<IGameStartModel>(Signals.UpdateAttackTries(), UpdateIcons);
		}
		#endregion
	}
}
