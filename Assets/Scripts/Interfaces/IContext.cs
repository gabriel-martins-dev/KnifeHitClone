using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContext
{
	GameObject CreateInstanceOf(GameObject gameObject, Transform parent = null);
	GameObject Container();
}
