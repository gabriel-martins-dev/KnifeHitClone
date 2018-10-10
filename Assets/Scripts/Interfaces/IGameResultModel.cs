using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface IGameResultModel
	{
		int Stage { get; }
		bool HasWon { get; }
	}
}

