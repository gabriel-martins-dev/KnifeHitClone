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
		private Stack<GameObject> _poolStack;
		private List<GameObject> _poolDirty;
		private GameObject _poolGameObject;
		private GameObject _poolRoot;
		private bool _preserveScale;
		int count = 0;

		public PoolService 
		(
			IContext context, 
			GameObject poolGameObject, 
			bool preserveScale = true 
		) {
			_context = context;
			_poolGameObject = poolGameObject;
			_preserveScale = preserveScale;
			_poolStack = new Stack<GameObject>();
			_poolDirty = new List<GameObject>();
			_poolRoot = new GameObject("PoolService");
			_poolRoot.transform.SetParent(context.Container().transform);
		}

		private void CreateItem()
		{
			GameObject newObject = _context.CreateInstanceOf(_poolGameObject, _poolRoot.transform);
			newObject.name = newObject.name + count.ToString();
			ResetItem(ref newObject);
			_poolStack.Push(newObject);
			count++;
		}

		private GameObject ResetItem(ref GameObject item)
		{
			item.SetActive(false);

			item.transform.SetParent(_poolRoot.transform);
			item.transform.localPosition = Vector3.zero;
			item.transform.localRotation = Quaternion.identity;
			item.transform.localScale = _preserveScale 
			? _poolGameObject.transform.localScale : Vector3.one;

			return item;
		}

		#region IPoolService
		public GameObject Pop()
		{
			if (_poolStack.Count == 0) {
				CreateItem();
			}

			GameObject pop = null;
			
			for (int i = 0; i < _poolStack.Count; i++) {
				pop = _poolStack.Pop();

				if(!_poolDirty.Contains(pop)) {
					break;
				} 
				Debug.Log("Dirty contains" + pop.name);
			}

			_poolDirty.Add(pop);
			return pop;
		}

		public void Push(GameObject item) {
			if(_poolDirty.Contains(item)) {
				_poolDirty.Remove(item);
			}

			ResetItem(ref item);

			_poolStack.Push(item);
		}

		public void Reset()
		{
			for (int i = 0; i < _poolDirty.Count; i++) {
				GameObject item = _poolDirty[i];
				ResetItem(ref item);
				_poolStack.Push(item);
			}

			_poolDirty.Clear();
		}
		#endregion
	}
}
