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

			Messenger.AddListener(Signals.AttackSucces(), AttackSuccesHandler);
			Messenger.AddListener(Signals.AttackFailed(), AttackFailedHandler);
			Messenger.Broadcast(Signals.GameStartPhase());
		}

		private void AttackSuccesHandler () 
		{
			numberOfTries++;

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

		#region IGameController
		public void Initialize(IGameControllerSettings settings) 
		{
			this.settings = settings;
			StartGame();
		}
		#endregion
	}
}
