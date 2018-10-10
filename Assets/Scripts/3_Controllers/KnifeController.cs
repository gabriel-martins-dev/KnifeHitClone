using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using context.gameplay.helpers;
using context.gameplay.services;
using context.gameplay.interfaces;

namespace context.gameplay.controllers 
{
	enum KniveState {
		Sleeping,
		Attacking,
		FinishedAttack
	}	

	public class KnifeController : MonoBehaviour 
	{
		[SerializeField]
		private KnifeView _view;
		[SerializeField]
		private Rigidbody2D _body;
		private KniveState _state;
		private IGameControllerSettings _gameControllerSettings;
		private Tweener move;

		#region Methods
		private void OnEnable()
		{
			_state = KniveState.Sleeping;
			_view.FadeIn();

			Messenger.AddListener(Signals.ThrowKnive(), OnAttack);
			Messenger.AddListener<bool>(Signals.GameResultPhase(), OnGameResult);
			transform.position = _gameControllerSettings.WeaponSettings.SpawnPosition;
		}

		private void OnDisable()
		{
			Messenger.RemoveListener(Signals.ThrowKnive(), OnAttack);
		}

		private void Awake()
		{
			_gameControllerSettings = InterfaceService.GetInterface<IGameController>().Settings;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if(_state == KniveState.Attacking) {
				OnAttackFaied();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			transform.SetParent(other.transform);
			OnAttackSucceded();
		}

		private void OnAttack() 
		{
			if(_state != KniveState.Sleeping) {
				return;
			}

			_state = KniveState.Attacking;

			Messenger.Broadcast(Signals.StartAttack());
	
			move = _body.DOMove(_gameControllerSettings.TargetSettings.Position, 0.1f)
			.SetEase(Ease.Linear)
			.OnComplete(() => {
					_state = KniveState.FinishedAttack;
					OnAttackSucceded();
				}
			);
		}

		private void OnGameResult(bool result)
		{
			if(_state == KniveState.Sleeping 
			|| _state == KniveState.Attacking) {
				move.Kill();
				gameObject.SetActive(false);
			}
		}

		private void OnAttackFaied() 
		{
			move.Kill();
			_state = KniveState.FinishedAttack;
			Messenger.Broadcast(Signals.AttackFailed());
		}

		private void OnAttackSucceded() 
		{
			move.Kill();
			_state = KniveState.FinishedAttack;
			Messenger.Broadcast(Signals.AttackSucces());
		}
		#endregion
	}
}
