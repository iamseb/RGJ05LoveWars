using UnityEngine;
using System.Collections;

public class Child : MonoBehaviour
{
	public void Hit(){
		Managers.Mission.LostChild();
		Destroy(gameObject);
	}
}

