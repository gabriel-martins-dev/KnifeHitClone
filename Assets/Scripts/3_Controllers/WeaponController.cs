using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;
using context.gameplay.models.settings;
using context.gameplay.services;
using context.gameplay.helpers;

namespace context.gameplay.controllers
{
	public class WeaponController : MonoBehaviour, IWeaponController 
	{
		private IWeaponControllerSettings model;
		private IPoolService weaponsPool;
		private float attackTime;

#region Methods
		private void Update() 
		{
			if(Input.GetKeyDown(KeyCode.Mouse0)) {
				Attack();
			}
		}

		private void OnStartGamePhase() {
			ShowWeapon();
		}

		private void ShowWeapon () 
		{
			GameObject weapon = weaponsPool.Pop();
			weapon.SetActive(true);
		}
		
		private void Attack () 
		{
			Messenger.Broadcast(Signals.ThrowKnive());
		}
#endregion

#region IWeaponController
		public void Initialize(IWeaponControllerSettings settings, IPoolService weaponsPool) 
		{
			this.model = settings;
			this.weaponsPool = weaponsPool;

			Messenger.AddListener(Signals.TargetReady(), OnStartGamePhase);
			Messenger.AddListener(Signals.AttackSucces(), ShowWeapon);
			Messenger.AddListener(Signals.TargetOut(), weaponsPool.Reset);
		}
#endregion
	}
}