using UnityEngine;
using System.Collections;

public class BadGuy : MonoBehaviour
{
	public Color color = Color.red;
	public float size = 1.0f;
	public Spawner spawner;
	private bool destroyed = false;
	public float lifeTime = 5.0f;
	
	void Awake(){
		Renderer r = gameObject.GetComponentInChildren<Renderer>();
		r.material.color = color;
		transform.localScale = Vector3.one * size;
	}
	
	void OnCollisionEnter(Collision c){
		GameObject g = c.gameObject;
		
		if(g.tag == "Player"){
			g.SendMessage("Damage", size);
			spawner.DeleteEnemy(this.transform);
			destroyed = true;
		}
		if(g.tag == "Child"){
			g.SendMessage("Hit");
			spawner.DeleteEnemy(this.transform);
			destroyed = true;
		}
	}
	
	void Update(){
		lifeTime -= Time.deltaTime;
		if(lifeTime <= 0.0f){
			spawner.DeleteEnemy(this.transform);
			destroyed = true;
		}
		
		if(destroyed){
			Transform t = (Transform)Instantiate(spawner.particles, transform.position, transform.rotation);
			Destroy(gameObject);
			Destroy(t.gameObject, 3.0f);
		}		
	}
}

