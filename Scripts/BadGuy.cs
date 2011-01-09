using UnityEngine;
using System.Collections;

public class BadGuy : MonoBehaviour
{
	public float speed = 2.5f;
	public Color color = Color.red;
	public Transform target;
	public float size = 1.0f;
	public Spawner spawner;
	
	void Awake(){
		Renderer r = gameObject.GetComponentInChildren<Renderer>();
		r.material.color = color;
		transform.localScale = Vector3.one * size;
	}
	
	void Start() {
		target = Managers.Mission.thePlayer.transform;
	}

	// Update is called once per frame
	void Update (){
		// this is a dumb follow behaviour. it will attempt to move towards the target, always.
		if(target){
			transform.position += (target.transform.position - transform.position).normalized * speed * Time.deltaTime;	
		}
	}
	
	void OnCollisionEnter(Collision c){
		GameObject g = c.gameObject;
		Debug.Log("Hit " + g.tag);
		if(g.tag == "Player"){
			g.SendMessage("Damage", size);
			spawner.DeleteEnemy(this.transform);
			Destroy(gameObject);
		}
		if(g.tag == "Child"){
			g.SendMessage("Hit");
			spawner.DeleteEnemy(this.transform);
			Destroy(gameObject);
		}
		
	}
}

