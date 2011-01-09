using UnityEngine;
using System.Collections;

public class MessageGUI : MonoBehaviour
{
	public float messageDisplayTime = 3.0f;
	public float timeSinceMessageDisplayed = 0.0f;
	public string message = "";
	
	void Start(){
	}
	
	public void DisplayMessage(string m){
		message = m;
		timeSinceMessageDisplayed = 0.0f;
	}
	
	void OnGUI() {
		GUILayout.BeginArea(new Rect(Screen.width/2-100, 0, 200, 100));
		GUILayout.Label("Current phase: " + Managers.Mission.currentPhase.name);
		if(message != "" && timeSinceMessageDisplayed < messageDisplayTime){
			GUILayout.Label(message);
		}
		GUILayout.EndArea();
	}
	
	void Update(){
		timeSinceMessageDisplayed += Time.deltaTime;
	}
}

