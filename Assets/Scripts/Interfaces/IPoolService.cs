using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface IPoolService 
	{
		GameObject Pop();
		void Push(GameObject item);
	}
}
