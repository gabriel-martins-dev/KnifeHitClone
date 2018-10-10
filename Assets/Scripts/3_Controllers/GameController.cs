using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;
using context.gameplay.helpers;

namespace context.gameplay.controllers
{
	public class GameController: MonoBehaviour, IGameController {
		public int numberOfTries { get; private set; }
		private IGameControllerSettings settings;

		private void StartGame () 
		{
			numberOfTries = 0;

			Messenger.AddListener(Signals.StartAttack(), UpdateTries);
			Messenger.AddListener(Signals.AttackSucces(), AttackSuccesHandler);
			Messenger.AddListener(Signals.AttackFailed(), AttackFailedHandler);
			
			GameStartModel model = new GameStartModel(RemainingTries);
			Messenger.Broadcast<IGameStartModel>(Signals.UpdateAttackTries(), model);
			Messenger.Broadcast(Signals.GameStartPhase());
		}

		private void UpdateTries () 
		{
			numberOfTries = (int)Mathf.Clamp(numberOfTries + 1, 0, settings.NumberOfTries);

			GameStartModel model = new GameStartModel(RemainingTries);
			Messenger.Broadcast<IGameStartModel>(Signals.UpdateAttackTries(), model);
		}

		private void AttackSuccesHandler () 
		{
			if(numberOfTries >= settings.NumberOfTries) {
				Debug.Log("WIN");
				Messenger.Broadcast(Signals.GameWinPhase());
			}
		}

		private void AttackFailedHandler () 
		{
			Debug.Log("LOST");
			Messenger.Broadcast(Signals.GameLostPhase());
		}

		private int RemainingTries {
			get { return settings.NumberOfTries - numberOfTries; }
		}

		#region IGameController
		public void Initialize(IGameControllerSettings settings) 
		{
			this.settings = settings;
			StartGame();
		}
		#endregion
	}
}
