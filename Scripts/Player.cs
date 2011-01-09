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
	public Transform childType;
	public ArrayList children;
	
	void Awake(){
		children = new ArrayList();
	}

	public void Damage(float amount){
		health -= amount;
		if(health <= 0.0f){
			LoseLife();
			health = maxHealth;
		}
		AddScore(amount);
	}
	
	public void AddScore(float amount){
		int multiplier = Managers.Mission.currentPhase.scoreMultiplier;
		score += (int)amount * multiplier;
	}
	
	public void Update(){
		health += regen * Time.deltaTime;
		if(health > maxHealth){
			health = maxHealth;
		}
	}

	public void LoseLife(){
		lives --;
		transform.position = Vector3.zero;
		Managers.Mission.thePlayer.Size *= 1.0f / Managers.Mission.currentPhase.growMultiplier;
	}


}

