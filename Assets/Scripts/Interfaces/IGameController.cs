using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.interfaces
{
	public interface IGameController 
	{
		int numberOfTries { get; }
		void Initialize(IGameControllerSettings settings);
	}
}
