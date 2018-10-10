using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace context.gameplay.interfaces 
{
	public interface ITargetControllerStageModel
	{
		bool RandomDirection { get; }
		float Velocity { get; }
		float VelocityRange { get; }
		float Angle { get; }
		float AngleRange { get; }
		Ease EaseMode { get; }
	}
}
