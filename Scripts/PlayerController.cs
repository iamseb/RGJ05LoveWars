using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f;
	public LevelAttributes level;
	public float size = 1.0f;
	public Player player;
	
	public float Size {
		get { return size; }
		set { size = value; gameObject.transform.localScale = Vector3.one * size; }
	}
	
	void Awake(){
		player = GetComponent<Player>();
	}
	
	public int lives {
		get { return player.lives; }
	}
	
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
			transform.position = new Vector3(transform.position.x, transform.position.y, -level.height / 2 + size / 2);
		}
	}
	
}

