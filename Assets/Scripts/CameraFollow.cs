using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	void LateUpdate ()
	{
		//positioning camera to center on target.x,y,z positions
		transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
	}
}
