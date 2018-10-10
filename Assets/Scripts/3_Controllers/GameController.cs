using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;
using context.gameplay.models;
using context.gameplay.helpers;

namespace context.gameplay.controllers
{
	public class GameController: MonoBehaviour, IGameController {
		public int NumberOfTries { get; private set; }
		private IGameControllerSettings _settings;
		private int _numberOfValidTries;
		private int _stage;

		private void StartGame (int stage = 0) 
		{
			_stage = stage;
			_numberOfValidTries = 0;
			NumberOfTries = 0;

			Messenger.AddListener(Signals.StartAttack(), UpdateTries);
			Messenger.AddListener(Signals.AttackSucces(), AttackSuccesHandler);
			Messenger.AddListener(Signals.AttackFailed(), AttackFailedHandler);
			
			GameStartModel model = new GameStartModel(RemainingTries);
			Messenger.Broadcast<IGameStartModel>(Signals.UpdateAttackTries(), model);
			Messenger.Broadcast(Signals.GameStartPhase());
		}

		private void EndGame () 
		{
			Messenger.RemoveListener(Signals.StartAttack(), UpdateTries);
			Messenger.RemoveListener(Signals.AttackSucces(), AttackSuccesHandler);
			Messenger.RemoveListener(Signals.AttackFailed(), AttackFailedHandler);
		}

		private void UpdateTries () 
		{
			NumberOfTries = (int)Mathf.Clamp(NumberOfTries + 1, 0, _settings.NumberOfTries);
			GameStartModel startModel = new GameStartModel(RemainingTries);
			Messenger.Broadcast<IGameStartModel>(Signals.UpdateAttackTries(), startModel);
		}

		private void AttackSuccesHandler () 
		{
			_numberOfValidTries++;

			if(_numberOfValidTries >= _settings.NumberOfTries) {
				Debug.Log("WON");
				EndGame();
				Messenger.AddListener(Signals.TargetOut(), NextStage);
				Messenger.Broadcast(Signals.GameWinPhase());
				Messenger.Broadcast<bool>(Signals.GameResultPhase(), true);
			}
		}

		private void AttackFailedHandler () 
		{
			Debug.Log("LOST");
			EndGame();
			Messenger.AddListener(Signals.TargetOut(), Restart);
			Messenger.Broadcast(Signals.GameLostPhase());
			Messenger.Broadcast<bool>(Signals.GameResultPhase(), false);
		}

		private int RemainingTries {
			get { return _settings.NumberOfTries - NumberOfTries; }
		}

		private void Restart() {
			Messenger.RemoveListener(Signals.TargetOut(), Restart);

			int newStage = 0;
			GameResultModel resultModel = new GameResultModel(newStage, false);
			Messenger.Broadcast<IGameResultModel>(Signals.GameResult(), resultModel);

			StartGame();

			/*
			_stage = 0;
			_numberOfValidTries = 0;
			NumberOfTries = 0;

			GameResultModel resultModel = new GameResultModel(_stage, false);
			Messenger.Broadcast<IGameResultModel>(Signals.GameResult(), resultModel);

			GameStartModel startModel = new GameStartModel(RemainingTries);
			Messenger.Broadcast<IGameStartModel>(Signals.UpdateAttackTries(), startModel);
			Messenger.Broadcast(Signals.GameStartPhase());
			 */
		}

		private void NextStage() {
			Messenger.RemoveListener(Signals.TargetOut(), NextStage);

			int newStage = _stage + 1;
			GameResultModel resultModel = new GameResultModel(newStage, true);
			Messenger.Broadcast<IGameResultModel>(Signals.GameResult(), resultModel);

			StartGame(newStage);

			/*
			_stage++;
			_numberOfValidTries = 0;
			NumberOfTries = 0;

			GameResultModel resultModel = new GameResultModel(_stage, true);
			Messenger.Broadcast<IGameResultModel>(Signals.GameResult(), resultModel);

			GameStartModel startModel = new GameStartModel(RemainingTries);
			Messenger.Broadcast<IGameStartModel>(Signals.UpdateAttackTries(), startModel);
			Messenger.Broadcast(Signals.GameStartPhase());
			 */
		}

		#region IGameController
		public void Initialize(IGameControllerSettings settings) 
		{
			this._settings = settings;
			StartGame();
		}

		public IGameControllerSettings Settings 
		{ 
			get {return _settings; } 
		}
		#endregion
	}
}
