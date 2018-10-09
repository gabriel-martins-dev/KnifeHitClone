using UnityEngine;
using System.Collections;

namespace context.gameplay.services {
	public class CameraResolutionService : MonoBehaviour {
		[Range(-1,1)]
		public int adaptPosition;


		float defaultWidth;
		float defaultHeight;
		Vector3 CameraPos;

		void Start () {
			CameraPos = Camera.main.transform.position;
			defaultHeight = Camera.main.orthographicSize;
			defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
		}

		void Update () {
				Camera.main.transform.position= new Vector3(CameraPos.x + adaptPosition*(defaultWidth-Camera.main.orthographicSize*Camera.main.aspect) ,CameraPos.y,CameraPos.z);
		}
	}
}
