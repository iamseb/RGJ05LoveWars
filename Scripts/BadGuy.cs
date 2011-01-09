using UnityEngine;
using System.Collections;

public class BadGuy : MonoBehaviour
{
	public Color color = Color.red;
	public float size = 1.0f;
	public Spawner spawner;
	
	void Awake(){
		Renderer r = gameObject.GetComponentInChildren<Renderer>();
		r.material.color = color;
		transform.localScale = Vector3.one * size;
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

