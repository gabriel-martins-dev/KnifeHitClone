using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using context.gameplay.views;

namespace context.gameplay.views
{
	public class KnifeView : View 
	{
		[SerializeField]
		private SpriteRenderer spriteRenderer;
		public void FadeIn () 
		{
			spriteRenderer.color = new Color(1, 1, 1, 0);

			spriteRenderer.DOFade(1, 0.15f)
			.SetEase(Ease.InQuint);
		}

		public void FailedAnimation () {
			float direction = Random.Range(0f, 1f) > 0.5f ? 1 : -1;

			transform.DOMove(new Vector3(-7.5f * direction, -3.34f, 0), 0.5f);
			transform.DORotate(new Vector3(0, 0, 720f), 0.5f, RotateMode.LocalAxisAdd);
		}
	}
}