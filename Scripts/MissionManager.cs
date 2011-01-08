using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour
{
	
	public bool isRunning = false;
	
	void Awake (){
	}
	
	
	void Update(){
		if (isRunning) {
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

