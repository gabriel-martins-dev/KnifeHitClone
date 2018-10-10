using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface IScoreUIController 
	{
		void Initialize(IScoreUIControllerSettings settings, IPoolService poolService);
	}
}
