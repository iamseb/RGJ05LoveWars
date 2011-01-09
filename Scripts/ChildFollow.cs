using UnityEngine;
using System.Collections;
using System;

public class ChildFollow : MonoBehaviour
{
	public Transform target;
	public float speed = 4.0f;
	public float orbitPos = 0.0f;
	public float orbitSpeed = 5.0f;
	public float size = 0.5f;
	
	void Awake(){
		transform.localScale = Vector3.one * size;
	}

	void Start() {
		target = Managers.Mission.thePlayer.transform;
	}
	
	public Vector3 CalculateDesiredPosition(){
		Vector3 targetPos = target.position;
		int idx = Managers.Mission.thePlayer.player.children.IndexOf(this);
		float orbitDistance = Managers.Mission.thePlayer.size / 2 + size;
		float x = orbitDistance * (float)Math.Sin(orbitPos + (float)idx);
		float z = orbitDistance * (float)Math.Cos(orbitPos + (float)idx);
		return targetPos + new Vector3(x, 0, z);
		
	}

	// Update is called once per frame
	void Update (){
		orbitPos += orbitSpeed * Time.deltaTime;
		if(Managers.Mission.currentPhase != Managers.Mission.mourning){
			float hmov = Input.GetAxis("Horizontal2");
			float vmov = Input.GetAxis("Vertical2");
			Vector3 v = new Vector3(hmov, 0, -vmov);
			transform.position += v  * speed / 2.0f * Time.deltaTime;
		}

		// this is a dumb follow behaviour. it will attempt to move towards the target, always.
		if(target){
			transform.position += (CalculateDesiredPosition() - transform.position).normalized * speed * Time.deltaTime;	
		}
	}
}

