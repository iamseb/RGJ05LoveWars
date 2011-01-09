using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour
{
	
	public PlayerController thePlayer;
	public bool isRunning = false;
	public Phase firstPhase;
	public Phase currentPhase;
	public float elapsedTime = 0.0f;
	public Spawner spawner;
	
	void Awake(){
		spawner = gameObject.GetComponent<Spawner>();
	}
	
	void Start(){
		Reset();
		isRunning = true;
	}
	
	void ChangePhase(Phase phase){
		currentPhase.SetInactive();
		phase.previousPhase = currentPhase;
		currentPhase = phase;
		currentPhase.SetActive();
		elapsedTime = 0.0f;
	}
	
	void Update(){		
		if (isRunning) {
			elapsedTime += Time.deltaTime;
			if(elapsedTime > currentPhase.secondsLong && currentPhase.nextPhase != null){
				Debug.Log("Changing phase to " + currentPhase.nextPhase.name);
				ChangePhase(currentPhase.nextPhase);
			}
			//Debug.Log("Running " + this.name);
			if(thePlayer.lives < 1){
				GameOver();
			}
		}
	}
	
	public void LostChild(){
		thePlayer.SendMessage("AddScore", -100.0f);
		thePlayer.SendMessage("LoseLife");
		if(currentPhase.previousPhase != null){
			ChangePhase(currentPhase.previousPhase);
		}
	}
	
	protected void GameOver(){
		Debug.Log("GAME OVER MAN");
		isRunning = false;
		Managers.Game.SetState(typeof(GameOverState));
	}
	
	public void Reset(){
		isRunning = false;
		ChangePhase(firstPhase);
	}
	
}

