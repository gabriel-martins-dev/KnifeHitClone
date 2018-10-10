using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.interfaces
{
	public interface IGameController 
	{
		int NumberOfTries { get; }
		IGameControllerSettings Settings { get; }
		void Initialize(IGameControllerSettings settings);
	}
}
