using UnityEngine;
using System.Collections;

public class BadGuyFleer : MonoBehaviour
{
	public Transform target;
	public float speed = 2.5f;
	protected LevelAttributes level;
	bool fleeing = false;
	float fleeThreshold = 4.5f;
	float approachThreshold = 8.0f;

	void Start() {
		target = Managers.Mission.thePlayer.transform;
		level = Managers.Mission.level.GetComponent<LevelAttributes>();
	}

	// Update is called once per frame
	void Update (){
		float size = gameObject.GetComponent<BadGuy>().size;
		
		float targetDistance = (target.transform.position - transform.position).magnitude;
		if(targetDistance < fleeThreshold){
			fleeing = true;
		}
		if(targetDistance > approachThreshold){
			fleeing = false;
		}
		
		float fleeMult = 1.0f;
		if(fleeing){
			fleeMult = -1.0f;
		}
		
		// this is a dumb follow behaviour. it will attempt to move towards the target, always.
		if(target){
			transform.position += ((target.transform.position - transform.position).normalized * speed * Time.deltaTime) * fleeMult;	
		}
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


