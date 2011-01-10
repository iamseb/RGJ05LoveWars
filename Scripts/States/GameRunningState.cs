using UnityEngine;
using System.Collections;

public class GameRunningState : GameState
{
	
	public Phase firstPhase;
	public Phase currentPhase;
	public Phase mourning;
	public Transform level;
	public MessageGUI messageGUI;
	public ScoreGUI scoreGUI;
	public PlayerController player;

    public override void OnActivate() {
		Application.LoadLevel(2);
	}
	
    public override void OnDeactivate() {
	}
	
    public override void OnUpdate() {
	}
}
