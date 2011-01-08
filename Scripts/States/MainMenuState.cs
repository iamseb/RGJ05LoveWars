using UnityEngine;
using System.Collections;


public class MainMenuState : GameState
{
    public override void OnActivate() {
		Application.LoadLevel(1);
	}
	
    public override void OnDeactivate() {
	}
	
    public override void OnUpdate() {
	}
}

