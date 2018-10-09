using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;
using context.gameplay.models.settings;
using context.gameplay.services;

namespace context.gameplay.controllers 
{
	public class WeaponController : MonoBehaviour, IWeaponController 
	{
		private IWeaponControllerSettings model;
		private IPoolService weaponsPool;

#region Public/Private Methods
		void Update () 
		{
			if(Input.GetKeyDown(KeyCode.Mouse0)) {
				ThrowAttack();
			}
		}
		
		private void ThrowAttack () 
		{
			GameObject weapon = weaponsPool.Pop();
			weapon.transform.position = model.WeaponSpawnPosition;
			weapon.SetActive(true);
		}
#endregion

#region IWeaponController
		public void Initialize(IWeaponControllerSettings settings, IPoolService weaponsPool) 
		{
			this.model = settings;
			this.weaponsPool = weaponsPool;
		}

		public void Attack ()
		{

		}
#endregion
	}
}