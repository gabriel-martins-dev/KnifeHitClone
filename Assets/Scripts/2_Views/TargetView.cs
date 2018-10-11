using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.helpers;
using context.gameplay.views;
using DG.Tweening;

namespace context.gameplay.views 
{
	public class TargetView : View {
		[SerializeField]
		private SpriteRenderer spriteRenderer;
		private Sequence rotationSequence;
		private Tweener scaleTweener;

		public void FadeIn (TweenCallback callback) 
		{
			KillTween(scaleTweener);
			Hide();
			scaleTweener = transform.DOScale(Vector3.one, 0.5f)
			.OnComplete(() => callback());
		}

		public void FadeOut (TweenCallback callback) 
		{
			KillTween(scaleTweener);
			scaleTweener = transform.DOScale(Vector3.zero, 0.5f)
			.OnComplete(() => callback());
		}

		public void DoRotation (Sequence newRotation) {
			KillTween(rotationSequence);
			rotationSequence = newRotation;

			rotationSequence.Play();
		}

		public void Hide () 
		{
			transform.localScale = Vector3.zero;
		}

		public void StopTweens () {
			KillTween(rotationSequence);
			KillTween(scaleTweener);
		}
	}
}
