using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;
using DG.Tweening;

namespace context.gameplay.models 
{
	[Serializable]
	public class TargetControllerStageModel : ITargetControllerStageModel
	{
		public bool randomDirection;
		public float velocity;
		public float velocityRange;
		public float angle;
		public float angleRange;
		public Ease easeMode;

		public bool RandomDirection { get { return randomDirection; } }
		public float Velocity { get { return velocity; } }
		public float VelocityRange { get { return velocityRange; } }
		public float Angle { get { return angle; } }
		public float AngleRange { get { return angleRange; } }
		public Ease EaseMode { get { return easeMode; } }
	}
}
