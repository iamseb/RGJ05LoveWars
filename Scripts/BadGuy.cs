using UnityEngine;
using System.Collections;

public class BadGuy : MonoBehaviour
{
	public float speed = 2.5f;
	public Color color = Color.red;
	public Transform target;
	public float size = 1.0f;
	
	void Awake(){
		transform.localScale = Vector3.one * size;
	}
	
	void Start() {
		target = Managers.Mission.thePlayer.transform;
	}

	// Update is called once per frame
	void FixedUpdate (){
		// this is a dumb follow behaviour. it will attempt to move towards the target, always.
		if(target){
			transform.position += (target.transform.position - transform.position).normalized * speed * Time.fixedDeltaTime;	
		}
	}
	
	void OnCollisionEnter(Collision c){
		GameObject g = c.gameObject;
		if(g.tag == "Player"){
			g.SendMessage("Damage", size);
			Destroy(gameObject);
		}
		
	}
}

