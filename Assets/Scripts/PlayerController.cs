using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	bool isDead = false;
	Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FallDeath(){
		StartCoroutine (KillPlayer ());
	}
	IEnumerator KillPlayer(){
		isDead = true;
		//_animator.SetTrigger("Death");
		yield return new WaitForSeconds(2.0f);
		print ("playerDead");
		Application.LoadLevel(Application.loadedLevelName);

	}
}
