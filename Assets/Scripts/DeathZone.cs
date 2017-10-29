using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	public float fallSpeed = 0.1f;
	void Update(){
		transform.position += new Vector3 (0, -fallSpeed, 0);
	}
	// Handle gameobjects collider with a deathzone object
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			
			other.gameObject.GetComponent<PlayerHealth> ().FallDeath ();
		} else {
			DestroyObject (other.gameObject);
		}

	}
}
