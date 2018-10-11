using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace context.gameplay.views
{
	public class StageIndicatorUIView : View 
	{
		[SerializeField]
		private Text stageIndicator;

		public void SetIndicator (int stage = 0) 
		{
			stageIndicator.text = string.Format("Stage {0}", stage);
			stageIndicator.text = string.Format("Stage {0}", stage);
		}
	}
}

