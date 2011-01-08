using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f;
	public LevelAttributes level;
	public float size = 1.0f;
	public int lives = 3;

	// Update is called once per frame
	void FixedUpdate (){
		float hmov = Input.GetAxis("Horizontal");
		float vmov = Input.GetAxis("Vertical");
		Vector3 v = new Vector3(hmov, 0, vmov);
		transform.position += v  * speed * Time.fixedDeltaTime;
		if (transform.position.x + size / 2 > level.width / 2){
			transform.position = new Vector3(level.width / 2 - size / 2, transform.position.y, transform.position.z);
		}
		if (transform.position.x - size / 2 < -level.width / 2){
			transform.position = new Vector3(-level.width / 2 + size / 2, transform.position.y, transform.position.z);
		}
		if (transform.position.z + size / 2 > level.height / 2){
			transform.position = new Vector3(transform.position.x, transform.position.y, level.height / 2 - size / 2);
		}
		if (transform.position.z - size / 2 < -level.height / 2){
			transform.position = new Vector3(transform.position.x, transform.position.y, -level.height / 2 - size / 2);
		}
	}
	
	public void LoseLife(){
		lives --;
		transform.position = Vector3.zero;
	}
}

