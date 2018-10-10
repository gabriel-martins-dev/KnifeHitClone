using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace context.gameplay.views 
{
	public class View : MonoBehaviour
	{
		protected void KillTween(Tween tween)
		{
			if(!ReferenceEquals(tween, null)) {
				tween.Kill();
			}
		}
	}
}
