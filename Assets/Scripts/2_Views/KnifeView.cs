using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnifeView : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer spriteRenderer;
	public void FadeIn () {
		spriteRenderer.color = new Color(1, 0, 0, 0);

		spriteRenderer.DOFade(1, 0.1f)
		.SetEase(Ease.InQuint);
	}

}
