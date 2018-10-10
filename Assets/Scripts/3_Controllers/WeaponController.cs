﻿using System.Collections;
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
		private void ShowWeapon () 
		{
			GameObject weapon = weaponsPool.Pop();
			weapon.transform.position = model.WeaponSpawnPosition;
			weapon.SetActive(true);
		}
		
		private void ThrowAttack () 
		{
			Messenger.Broadcast(Signals.StartAttack());
		}

		private void AttackSuccessHandler () {
			ShowWeapon();
		}
#endregion

#region IWeaponController
		public void Initialize(IWeaponControllerSettings settings, IPoolService weaponsPool) 
		{
			this.model = settings;
			this.weaponsPool = weaponsPool;

			Messenger.AddListener(Signals.GameStartPhase(), ShowWeapon);
			Messenger.AddListener(Signals.AttackSucces(), ShowWeapon);
		}

		public void Attack ()
		{

		}
#endregion
	}
}