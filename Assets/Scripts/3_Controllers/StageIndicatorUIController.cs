using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.views;
using context.gameplay.interfaces;
using context.gameplay.helpers;

public class StageIndicatorUIController : MonoBehaviour 
{
	[SerializeField]
	private StageIndicatorUIView _view;

	private 	void Awake()
	{
		_view.SetIndicator();
		Messenger.AddListener<IGameResultModel>(Signals.GameResult(), OnGameResult);
	}

	private void OnGameResult (IGameResultModel resultModel) 
	{
		_view.SetIndicator(resultModel.Stage);
	}
}
