using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	
	public float startingHealth = 100;
	public float currentHealth;
	public int scoreValue = 10;
	public float sinkSpeed = 2.5f;
	public Image healthBar;

	//public AudioClip[] deathAudio;

	//AudioSource audioSource;
	//AudioClip deathClip;
	Animator _animator;


	bool isDead;
	bool isSinking;
	bool gettingHit = false;

	void Awake (){
		_animator = GetComponent <Animator> ();

		currentHealth = startingHealth;
		//audioSource = gameObject.GetComponent<AudioSource> ();
	}


	void Update (){
		if(isSinking){
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
		_animator.SetBool ("GetHit", gettingHit);
		gettingHit = false;


	}

	//the function must public ,because it will be call by animation event and you need to set it by yourself
	public void StartSinking (){
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		Destroy (gameObject, 2f);
	}

	void Death (){
		isDead = true;

		_animator.SetTrigger ("Dead");

		//GameObject.Find ("GameManager").GetComponent<GameManager> ().addScore (scoreValue);
		//int index = Random.Range (0, deathAudio.Length);
		//deathClip = deathAudio [index];
		//audioSource.clip = deathClip;
		//audioSource.Play ();


	}
	public void applyDamage(int damage){
		if(isDead)
			return;
		gettingHit = true;
		currentHealth -= damage;
		healthBar.fillAmount = currentHealth / startingHealth;
		_animator.SetTrigger("Respawn");
		if(currentHealth <= 0){
			Death ();
		}
	}

}
