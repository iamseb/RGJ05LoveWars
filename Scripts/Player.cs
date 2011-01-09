using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float health = 100.0f;
	public float maxHealth = 100.0f;
	public float regen = 0.50f;
	public int lives = 3;
	public int score = 0;
	public int scoreMultiplier = 100;

	public void Damage(float amount){
		health -= amount;
		if(health <= 0.0f){
			LoseLife();
			health = maxHealth;
		}
		AddScore(amount);
	}
	
	public void AddScore(float amount){
		int multiplier = (Managers.Mission.currentPhaseNum + 1) * scoreMultiplier;
		score += (int)amount * multiplier;
	}
	
	public void FixedUpdate(){
		health += regen * Time.fixedDeltaTime;
		if(health > maxHealth){
			health = maxHealth;
		}
	}

	public void LoseLife(){
		lives --;
		transform.position = Vector3.zero;
	}


}

