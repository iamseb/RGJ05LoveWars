using UnityEngine;
using System.Collections;

public class GameRunningState : GameState
{
    public override void OnActivate() {
		Application.LoadLevel(2);
		Managers.Mission.Setup();
		Managers.Audio.Setup();
	}
	
    public override void OnDeactivate() {
	}
	
    public override void OnUpdate() {
	}
}
