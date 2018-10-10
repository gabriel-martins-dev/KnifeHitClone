using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using UnityEngine;
using context.gameplay.interfaces;

namespace context.gameplay.services 
{
	[System.Serializable]
	public class PoolService : IPoolService 
	{
		private IContext _context;
		private Stack<GameObject> _stack;
		private GameObject _poolGameObject;
		private GameObject _poolRoot;

		public PoolService (IContext context, GameObject poolGameObject) {
			_context = context;
			_poolGameObject = poolGameObject;
			_stack = new Stack<GameObject>();
			_poolRoot = new GameObject("PoolService");
			_poolRoot.transform.SetParent(context.Container().transform);
		}

		#region IPoolService
		public GameObject Pop()
		{
			if (_stack.Count == 0) {
				CreateItem();
			}

			return _stack.Pop();
		}

		public void Push(GameObject item) {
			ResetItem(ref item);

			_stack.Push(item);
		}
		#endregion

		private void CreateItem()
		{
			GameObject newObject = _context.CreateInstanceOf(_poolGameObject, _poolRoot.transform);
			ResetItem(ref newObject);
			_stack.Push(newObject);
		}

		private GameObject ResetItem(ref GameObject item)
		{
			item.SetActive(false);

			item.transform.SetParent(_poolRoot.transform);
			item.transform.localPosition = Vector3.zero;
			item.transform.localRotation = Quaternion.identity;

			return item;
		}
	}
}
