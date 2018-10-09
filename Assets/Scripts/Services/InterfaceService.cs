using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace context.gameplay.services
{
	public static class InterfaceService
	{
		/// <summary>
		/// Gets the interfaces.
		/// </summary>
		public static T[] GetInterfaces<T>()
		{
			if (!typeof(T).IsInterface) {
				throw new SystemException("Specified type is not an interface!");
			}

			var monoBehaviours = Object.FindObjectsOfType<MonoBehaviour>();

			return (from m in monoBehaviours
					where m.GetType().GetInterfaces().Any(a => a == typeof(T))
					select (T)(object)m).ToArray();
		}

		public static T[] FindObjectsOfType<T>() {
    	T[] objects = Object.FindObjectsOfType(typeof(T)) as T[];

    	return objects;
		}

		/// <summary>
		/// Gets the interface.
		/// </summary>
		public static T GetInterface<T>()
		{
			if (!typeof(T).IsInterface) {
				throw new SystemException("Specified type is not an interface!");
			}

			return GetInterfaces<T>().FirstOrDefault();
		}

		/// <summary>
		/// Returns all monobehaviours (casted to T)
		/// </summary>
		public static T[] GetInterfaces<T>(this GameObject gameObject)
		{
			if (!typeof(T).IsInterface) {
				throw new SystemException("Specified type is not an interface!");
			}

			var monoBehaviours = gameObject.GetComponents<MonoBehaviour>();

			return (from m in monoBehaviours
					where m.GetType().GetInterfaces().Any(a => a == typeof(T))
					select (T)(object)m).ToArray();
		}

		/// <summary>
		/// Returns the first monobehaviour that is of the interface type (casted to T)
		/// </summary>
		public static T GetInterface<T>(this GameObject gameObject)
		{
			if (!typeof(T).IsInterface) {
				throw new SystemException("Specified type is not an interface!");
			}

			return gameObject.GetInterfaces<T>().FirstOrDefault();
		}

		/// <summary>
		/// Returns the first instance of the monobehaviour that is of the interface type T (casted to T)
		/// </summary>
		public static T GetInterfaceInChildren<T>(this GameObject gameObject)
		{
			if (!typeof(T).IsInterface) {
				throw new SystemException("Specified type is not an interface!");
			}

			return gameObject.GetInterfacesInChildren<T>().FirstOrDefault();
		}

		/// <summary>
		/// Gets all monobehaviours in children that implement the interface of type T (casted to T)
		/// </summary>
		public static T[] GetInterfacesInChildren<T>(this GameObject gameObject)
		{
			if (!typeof(T).IsInterface) {
				throw new SystemException("Specified type is not an interface!");
			}

			var monoBehaviours = gameObject.GetComponentsInChildren<MonoBehaviour>();

			return (from m in monoBehaviours
					where m.GetType().GetInterfaces().Any(a => a == typeof(T))
					select (T)(object)m).ToArray();
		}
	}
}