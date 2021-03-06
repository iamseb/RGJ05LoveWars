using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour
{
	
	public PlayerController thePlayer;
	public bool isRunning = false;
	public Phase firstPhase;
	public Phase currentPhase;
	public Phase mourning;
	public float elapsedTime = 0.0f;
	public Spawner spawner;
	public Transform level;
	public MessageGUI messageGUI;
	public ScoreGUI scoreGUI;
	
	public void DoSetup(GameRunningState state){
		firstPhase = (Phase)Instantiate(state.firstPhase);
		Debug.Log("Created firstPhase: " + firstPhase.name);
		mourning = (Phase)Instantiate(state.mourning);
		thePlayer = (PlayerController)Instantiate(state.player);
		level = (Transform)Instantiate(state.level);
		level.SendMessage("Setup");
		messageGUI = (MessageGUI)Instantiate(state.messageGUI);
		scoreGUI = (ScoreGUI)Instantiate(state.scoreGUI);
		spawner = level.GetComponent<Spawner>();
		currentPhase = firstPhase;
		ChangePhase(firstPhase);
	}
	
	public void SpawnChild(){
		Player p = thePlayer.gameObject.GetComponent<Player>();		
		if(p.children.Count < 3){
			Transform t = (Transform)Instantiate(p.childType, p.transform.position, p.transform.rotation);		
			p.children.Add(t.GetComponent<Child>());
			messageGUI.DisplayMessage("You had a child. Make sure you protect it!");
		}
	}
	
	void ChangePhase(Phase phase){
		Phase p = (Phase)Instantiate(phase);
		currentPhase.SetInactive();
		p.previousPhase = currentPhase;
		currentPhase = p;
		currentPhase.SetActive();
		elapsedTime = 0.0f;
	}
	
	void Update(){		
		if (isRunning) {
			Debug.Log("This is the MissionManager running");
			Debug.Log("The level is: " + level.name);
			elapsedTime += Time.deltaTime;
			if(elapsedTime > currentPhase.secondsLong && currentPhase.nextPhase != null){
				Debug.Log("Changing phase to " + currentPhase.nextPhase.name);
				ChangePhase(currentPhase.nextPhase);
			}
		}
	}
	
	public void LostChild(Child lost){
		thePlayer.SendMessage("AddScore", -100.0f);
		thePlayer.SendMessage("LoseLife");
		Player p = thePlayer.gameObject.GetComponent<Player>();
		p.children.Remove(lost);
		ChangePhase(mourning);
		messageGUI.DisplayMessage("You lost your child! Be more careful.");
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

