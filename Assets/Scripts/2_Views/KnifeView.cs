using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using context.gameplay.views;

public class KnifeView : View {
	[SerializeField]
	private SpriteRenderer spriteRenderer;
	public void FadeIn () {
		spriteRenderer.color = new Color(1, 0, 0, 0);

		spriteRenderer.DOFade(1, 0.15f)
		.SetEase(Ease.InQuint);
	}

}
