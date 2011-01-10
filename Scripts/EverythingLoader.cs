using UnityEngine;
using System.Collections;

public class EverythingLoader : MonoBehaviour
{

	// Use this for initialization
	void Awake(){
		Managers.Audio.DoSetup();
		Managers.Mission.DoSetup(Managers.Game.State.GetComponent<GameRunningState>());
		Debug.Log("Running");
	}
}

