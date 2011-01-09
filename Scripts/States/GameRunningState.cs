using UnityEngine;
using System.Collections;

public class GameRunningState : GameState
{
    public override void OnActivate() {
		Application.LoadLevel(2);
		Managers.Audio.DoSetup();
		Managers.Mission.DoSetup();
		Debug.Log("Running");
	}
	
    public override void OnDeactivate() {
	}
	
    public override void OnUpdate() {
	}
}
