using UnityEngine;
using System.Collections;

public class LevelAttributes : MonoBehaviour
{
	public float width = 30.0f;
	public float height = 30.0f;
	
	public void Setup(){
		Debug.Log("Awake: " + this.name);
		PlayerController p = (PlayerController)Instantiate(Managers.Mission.thePlayer);
		p.name = "Player 1";
		p.level = this;
		Managers.Mission.thePlayer = p;		
		Managers.Mission.isRunning = true;
	}
	
	void OnDrawGizmos(){
		Debug.DrawLine(
			new Vector3(transform.position.x - width/2, 0, transform.position.y - height/2), 
			new Vector3(transform.position.x - width/2, 0, transform.position.y + height/2)
		);
		Debug.DrawLine(
			new Vector3(transform.position.x - width/2, 0, transform.position.y - height/2), 
			new Vector3(transform.position.x + width/2, 0, transform.position.y - height/2)
		);
		Debug.DrawLine(
			new Vector3(transform.position.x + width/2, 0, transform.position.y - height/2), 
			new Vector3(transform.position.x + width/2, 0, transform.position.y + height/2)
		);
		Debug.DrawLine(
			new Vector3(transform.position.x + width/2, 0, transform.position.y + height/2), 
			new Vector3(transform.position.x - width/2, 0, transform.position.y + height/2)
		);
	}
	
}
