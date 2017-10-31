using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	EnemyHealth enemyHealth;
	PlayerHealth playerHealth;
	Animator _animator;
	bool isRunning = true;
	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		_animator = GetComponent<Animator> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
	}


	void Update (){
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
			isRunning = true;
			nav.SetDestination (player.position);
		}else{
			nav.enabled = false;
			isRunning = false;
			_animator.SetTrigger ("Respawn");
		}
		_animator.SetBool ("Running", isRunning);
	}
}
