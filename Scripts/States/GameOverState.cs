using UnityEngine;
using System.Collections;

public class GameOverState : GameState
{
	private GameOverGUI gog;
	
    public override void OnActivate() {
		Debug.Log("Waking Up Game Over State");
		gog = FindObjectOfType(typeof(GameOverGUI)) as GameOverGUI;
		Debug.Log("Found GOG: " + gog.name);
		gog.showing = true;
		Managers.Mission.isRunning = false;
	}
	
    public override void OnDeactivate() {
		Managers.Mission.Reset();
	}
	
    public override void OnUpdate() {
		if(Input.GetButtonDown("Fire1")) {
			gog.showing = false;
			Managers.Mission.isRunning = true;
		}
	}

}

