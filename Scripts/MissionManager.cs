using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour
{
	
	public PlayerController thePlayer;
	public bool isRunning = false;	
	
	void Update(){
		if (isRunning) {
			//Debug.Log("Running " + this.name);
			if(thePlayer.lives < 1){
				GameOver();
			}
		}
	}
	
	protected void GameOver(){
		Debug.Log("GAME OVER MAN");
		isRunning = false;
		Managers.Game.SetState(typeof(GameOverState));
	}
	
	public void Reset(){
		isRunning = false;
	}
	
}

