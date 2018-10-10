using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using context.gameplay.helpers;

namespace context.gameplay.controllers 
{
	public class KnifeController : MonoBehaviour 
	{
		[SerializeField]
		private KnifeView view;
		[SerializeField]
		private Rigidbody2D body;
		private Tweener move;
		private Callback attackHandler;
		private bool isAttacking;
		private bool isAttackFinished;

		private void OnEnable()
		{
			view.FadeIn();

			Messenger.AddListener(Signals.StartAttack(), attackHandler);
		}

		private void OnDisable()
		{
			Messenger.RemoveListener(Signals.StartAttack(), attackHandler);
		}

		private void Awake()
		{
			attackHandler += OnAttack;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if(isAttacking && !isAttackFinished) {
				OnAttackFaied();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			transform.SetParent(other.transform);
			OnAttackSucceded();
		}

		private void OnAttack() {
			if(isAttacking || isAttackFinished) return;

			Debug.Log("ATTACK!");

			isAttacking = true;
	
			move = body.DOMoveY(1f, 0.1f)
			.SetEase(Ease.Linear)
			.OnComplete(() => {
					isAttacking = false;
					isAttackFinished = true;
					OnAttackSucceded();
				}
			);
		}

		private void OnAttackFaied() {
			move.Kill();
			isAttacking = false;
			isAttackFinished = true;
			Messenger.Broadcast(Signals.AttackFailed());
		}

		private void OnAttackSucceded() {
			move.Kill();
			isAttacking = false;
			isAttackFinished = true;
			Messenger.Broadcast(Signals.AttackSucces());
		}
	}
}
