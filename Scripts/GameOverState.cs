using UnityEngine;
using System.Collections;

public class GameOverState : GameState
{
	private GameOverGUI gog;
	
    public override void OnActivate() {
		gog = FindObjectOfType(typeof(GameOverGUI)) as GameOverGUI;
		gog.showing = true;
	}
	
    public override void OnDeactivate() {
		Managers.Mission.Reset();
		Application.LoadLevel(1);
	}
	
    public override void OnUpdate() {
		if(Input.GetButtonDown("Fire1")) {
			Managers.Game.SetState(typeof(MainMenuState));
			gog.showing = false;
		}
	}

}

