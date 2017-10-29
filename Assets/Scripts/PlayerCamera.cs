using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
	public Transform player;
	public float x;
	public float y;
	public float xSpeed = 1f;
	public float ySpeed = 1f;
	public float scrollSpeed = 1f;
	public float distance = 2f;
	public float minDistance = 1f;
	public float maxDistance = 5.5f;

	Quaternion rotationEuler;
	Vector3 cameraPosition;

	void LateUpdate () {
		x += Input.GetAxis ("Mouse X") * xSpeed * Time.deltaTime;
		//y += Input.GetAxis ("Mouse Y") * ySpeed * Time.deltaTime;

		if (Input.mousePosition.x >= Screen.width * 0.95) {
			x += 2 * xSpeed * Time.deltaTime;
			print ("border");
		} else if (Input.mousePosition.x <= Screen.width * 0.05) {
			x -= 2 * xSpeed * Time.deltaTime;
			print ("border");
		}
		
		if (x > 360) {
			x -= 360;
		} else if (x < 0) {
			x += 360;
		}



		distance -= Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
		distance = Mathf.Clamp (distance, minDistance, maxDistance);

		rotationEuler = Quaternion.Euler (y+40, x, 0);
		cameraPosition = rotationEuler * new Vector3 (0.4f, 1.5f, -distance) + player.position;
		transform.rotation = rotationEuler;
		transform.position = cameraPosition;
	}
}
