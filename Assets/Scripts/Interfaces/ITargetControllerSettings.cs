using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface ITargetControllerSettings
	{
		Vector2 Position { get; }
		ITargetControllerStageModel[] StageModels { get; }
	}
}
