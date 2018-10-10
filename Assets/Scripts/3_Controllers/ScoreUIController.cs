using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;

public class ScoreUIController : MonoBehaviour, IScoreUIController {
	private IScoreUIControllerSettings settings;
	private IPoolService poolService;
	private RectTransform[] icons;

	#region Methods
	private void CreateIcons() 
	{
		for (int i = 0; i < 8; i++) {
			var icon = poolService.Pop();

			icon.transform.SetParent(transform);
			icon.SetActive(true);			
		}
	}
	#endregion

	#region IScoreUIController
	public void Initialize(IScoreUIControllerSettings settings, IPoolService poolService) 
	{
		this.settings = settings;
		this.poolService = poolService;

		CreateIcons();
	}
	#endregion
}
