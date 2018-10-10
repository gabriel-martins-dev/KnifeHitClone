using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using context.gameplay.helpers;
using context.gameplay.interfaces;

namespace context.gameplay.controllers 
{
	public class TargetController : MonoBehaviour, ITargetController {
		[SerializeField]
		private TargetView _view;
		private ITargetControllerSettings _settings;
		private int _currentSettingsModel;

		private void OnGameStart () 
		{
			_view.FadeIn(
				() => {
					Messenger.Broadcast(Signals.TargetReady());
					Rotate();
				}
			);
		}

		private void OnGameResultPhase(bool result) 
		{
			_view.StopTweens();
			_view.FadeOut(() => Messenger.Broadcast(Signals.TargetOut()));
		}

		private void OnGameResult(IGameResultModel result) 
		{
			_currentSettingsModel = Mathf.Clamp(result.Stage, 0, _settings.StageModels.Length - 1);
		}

		private void Rotate () 
		{
			ITargetControllerStageModel model = _settings.StageModels[_currentSettingsModel];
			int direction = model.RandomDirection 
				? (Random.Range(0f, 1f) > 0.5f ? 1 : -1)
				: 1;
			float velocity = Random.Range(model.Velocity, model.Velocity + model.VelocityRange);
			float angle = Random.Range(model.Angle, model.Angle + model.AngleRange) * direction;
			
			Sequence sequence = DOTween.Sequence();
			sequence.Pause();
			sequence.Append(
				transform.DOLocalRotate(new Vector3(0, 0, angle), velocity, RotateMode.LocalAxisAdd)
				.SetEase(model.EaseMode)
				.OnComplete(() => Rotate())
			);

			_view.DoRotation(sequence);
		}

		#region ITargetController
		public void Initialize (ITargetControllerSettings settings) 
		{
			_settings = settings;
			_currentSettingsModel = 0;

			transform.position = _settings.Position;

			_view.Hide();

			Messenger.AddListener(Signals.GameStartPhase(), OnGameStart);
			Messenger.AddListener<bool>(Signals.GameResultPhase(), OnGameResultPhase);
			Messenger.AddListener<IGameResultModel>(Signals.GameResult(), OnGameResult);
		}
		#endregion
	}
}
