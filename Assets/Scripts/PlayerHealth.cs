using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;

	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	//public AudioClip deathClip;

	//AudioSource audioSource;

	bool isDead;
	bool damaged = false;

	// Use this for initialization
	void Start () {
		//audioSource = GetComponent<AudioSource> ();
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			//audioSource.PlayOneShot (deathClip);
			StartCoroutine (KillPlayer());
		}
		if(damaged){
			damageImage.color = flashColour;
		}
		else{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
	public void applyDamage(int damage){
		damaged = true;
		currentHealth -= damage;
		healthSlider.value = currentHealth;
	}
	public void FallDeath(){
		applyDamage(startingHealth);
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
