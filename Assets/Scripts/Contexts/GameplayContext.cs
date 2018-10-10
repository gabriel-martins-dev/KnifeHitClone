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
		#region Settings
		[SerializeField]
		private GameControllerSettings _gameControllerSettings;
		[SerializeField]
		private ScoreUIControllerSettings _scoreUIControllerSettings;
		#endregion

		#region Interfaces
		private IPoolService _weaponPoolService;
		private IPoolService _uiPoolService;
		#endregion

		#region Methods
		private void Awake () 
		{
			_weaponPoolService = new PoolService(this, _gameControllerSettings.WeaponSettings.WeaponPrefab);
			_uiPoolService = new PoolService(this, _scoreUIControllerSettings.IconPrefab as GameObject);
		}

		private void Start()
		{
			Configure();
		}

		private void Configure () 
		{
			IWeaponController weaponController = InterfaceService.GetInterface<IWeaponController>();
			ITargetController targetController = InterfaceService.GetInterface<ITargetController>();
			IGameController gameController = InterfaceService.GetInterface<IGameController>();
			IScoreUIController scoreUIController = InterfaceService.GetInterface<IScoreUIController>();

			weaponController.Initialize(_gameControllerSettings.WeaponSettings, _weaponPoolService);
			targetController.Initialize(_gameControllerSettings.TargetSettings);
			scoreUIController.Initialize(_scoreUIControllerSettings, _uiPoolService);
			gameController.Initialize(_gameControllerSettings);
		}
		#endregion

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
