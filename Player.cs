using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float health = 100.0f;

	public void Damage(float amount){
		health -= amount;
		if(health <= 0.0f){
			PlayerController pc = gameObject.GetComponent<PlayerController>();
			pc.LoseLife();
		}
	}

}

