using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using context.gameplay.helpers;

namespace context.gameplay.controllers 
{
	public class TargetController : MonoBehaviour {
		private Tweener rotation;
		
		void Start()
		{
			Messenger.AddListener(Signals.GameWinPhase(), Stop);
			Messenger.AddListener(Signals.GameLostPhase(), Stop);
			Rotate();
		}

		void Stop() {
			if(!ReferenceEquals(rotation, null)) {
				rotation.Kill();
			}
		}

		void Rotate () {
			rotation = transform.DOLocalRotate(new Vector3(0, 0, 360), 2, RotateMode.LocalAxisAdd)
			.SetEase(Ease.Linear)
			.OnComplete(() => Rotate());
		}
	}
}
