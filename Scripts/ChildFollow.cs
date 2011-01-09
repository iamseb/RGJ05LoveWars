using UnityEngine;
using System.Collections;
using System;

public class ChildFollow : MonoBehaviour
{
	public Transform target;
	public float speed = 5.0f;
	public float orbitPos = 0.0f;
	public float orbitSpeed = 5.0f;
	public float size = 0.25f;
	
	void Awake(){
		transform.localScale = Vector3.one * size;
	}

	void Start() {
		target = Managers.Mission.thePlayer.transform;
	}
	
	public Vector3 CalculateDesiredPosition(){
		Vector3 targetPos = target.position;
		float orbitDistance = Managers.Mission.thePlayer.size + size * 2;
		float x = orbitDistance * (float)Math.Sin(orbitPos);
		float z = orbitDistance * (float)Math.Cos(orbitPos);
		return targetPos + new Vector3(x, 0, z);
		
	}

	// Update is called once per frame
	void Update (){
		// this is a dumb follow behaviour. it will attempt to move towards the target, always.
		if(target){
			transform.position += (CalculateDesiredPosition() - transform.position).normalized * speed * Time.deltaTime;	
		}
		orbitPos += orbitSpeed * Time.deltaTime;
	}
}

