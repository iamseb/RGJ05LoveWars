using UnityEngine;
using System.Collections;

public class BadGuyFollower : MonoBehaviour
{
	public Transform target;
	public float speed = 2.5f;

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
}

