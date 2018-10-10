using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace context.gameplay.views
{
	public class StageIndicatorUIView : View {
		[SerializeField]
		private Text stageIndicator;

		public void SetIndicator (int stage = 0) {
			stageIndicator.text = string.Format("Stage {0}", stage);
		}
	}
}

