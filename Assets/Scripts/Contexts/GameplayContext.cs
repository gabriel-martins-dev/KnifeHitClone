using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using context.gameplay.services;
using context.gameplay.interfaces;
using context.gameplay.controllers;
using context.gameplay.models.settings;


namespace context.gameplay 
{
	///
	/// Gameplay Context
	///
	public class GameplayContext : MonoBehaviour, IContext 
	{
		/* settings */
		[SerializeField]
		private WeaponControllerSettings _weaponControllerSettings;

		/* interfaces */
		private IPoolService _poolService;
		private IWeaponController[] _weaponControllers;

		void Awake () 
		{
			_poolService = new PoolService(this, _weaponControllerSettings.WeaponPrefab);
			_weaponControllers = InterfaceService.GetInterfaces<IWeaponController>();
		}

		void Start()
		{
			Configure();
		}

		private void Configure () 
		{
			for (int i = 0; i < _weaponControllers.Length; i++) {
					_weaponControllers[i].Initialize(_weaponControllerSettings, _poolService);
			}
		}

#region IContext
	public GameObject CreateInstanceOf(GameObject gameObject, Transform parent = null) 
	{
		GameObject clone = Instantiate(gameObject);
		
		if(parent) {
			clone.transform.SetParent(parent);
		}

		return clone;
	}

	public GameObject Container() 
	{
		return gameObject;
	}
#endregion
	}
}
