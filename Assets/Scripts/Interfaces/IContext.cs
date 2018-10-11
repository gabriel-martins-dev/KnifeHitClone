using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.gameplay.interfaces 
{
	public interface IContext
	{
		GameObject CreateInstanceOf(GameObject gameObject, Transform parent = null);
		GameObject Container();
	}
}