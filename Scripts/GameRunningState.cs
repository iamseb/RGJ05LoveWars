using UnityEngine;
using System.Collections;

public class GameRunningState : GameState
{
    public override void OnActivate() {
		Application.LoadLevel(2);
	}
	
    public override void OnDeactivate() {
	}
	
    public override void OnUpdate() {
	}
}
