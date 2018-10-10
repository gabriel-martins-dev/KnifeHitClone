using UnityEngine;
using System.Collections;

namespace context.gameplay.services {
	public class CameraResolutionService : MonoBehaviour {
		[SerializeField, Range(-1,1)]
		private int adaptPosition;
		float defaultWidth;
		float defaultHeight;
		Vector3 cameraPosition;

		private void Awake () {
			cameraPosition = Camera.main.transform.position;
			defaultHeight = Camera.main.orthographicSize;
			defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
		}

		private void Update () {
			Camera.main.transform.position= new Vector3(cameraPosition.x + adaptPosition*(defaultWidth-Camera.main.orthographicSize*Camera.main.aspect) ,cameraPosition.y,cameraPosition.z);
		}
	}
}
