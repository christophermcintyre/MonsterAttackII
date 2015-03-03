using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;

	public float defaultDistance = 10;
	//TODO make camera default to a certain height
	//TODO make camera return to default positions gradually while moving
	//TODO make zoom more fluid
	public float defaultHeight = 5;
	public float minViewDistance = 1.0f;
	public float maxViewDistance = 25.0f;

	public int zoomRate = 30;
	public int CameraEaseRate = 5;

	private float x = 0.0f;
	private float y = 0.0f;
	private int mouseXSpeedMod = 5;
	private int mouseYSpeedMod = 3;

	public bool cameraPositionHold;

	void Start () {	
		Vector3 angles = transform.eulerAngles;
		x = angles.x;
		y = angles.y;
	}

	void LateUpdate () {

		if (Input.GetMouseButton (0)) {
			x += Input.GetAxis("Mouse X") * mouseXSpeedMod;
			y -= Input.GetAxis("Mouse Y")* mouseYSpeedMod;
		}

		//else if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0){
		//	float targetRotationAngle = target.eulerAngles.y;
		//	float cameraRotationAngle = transform.eulerAngles.y;
		//	x = Mathf.LerpAngle (cameraRotationAngle, targetRotationAngle, CameraEaseRate * Time.deltaTime);
		//}

		else if (!cameraPositionHold){
			float targetRotationAngle = target.eulerAngles.y;
			float cameraRotationAngle = transform.eulerAngles.y;
			
			x = Mathf.LerpAngle (cameraRotationAngle, targetRotationAngle, CameraEaseRate * Time.deltaTime);
		}

		y = ClampAngle (y, -50, 80);

		Quaternion rotation = Quaternion.Euler (y, x, 0);

		defaultDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(defaultDistance);
		defaultDistance = Mathf.Clamp (defaultDistance, minViewDistance, maxViewDistance);
		//correctedDistance = desiredDistance;

		Vector3 position = target.position - (rotation * Vector3.forward * defaultDistance);

		transform.rotation = rotation;
		transform.position = position;
	
	}


	private static float ClampAngle(float angle, float min, float max) {

		if (angle < -360) {
			angle += 360;
		}
		if (angle > 360) {
			angle -= 360;
		}
		return Mathf.Clamp (angle, min, max);
	}

}
