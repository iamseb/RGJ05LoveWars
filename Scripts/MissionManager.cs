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
	
	void Awake(){
		spawner = level.GetComponent<Spawner>();
		currentPhase = firstPhase;
	}
	
	public void SpawnChild(){
		Player p = thePlayer.gameObject.GetComponent<Player>();		
		if(p.children.Count < 3){
			Transform t = (Transform)Instantiate(p.childType, p.transform.position, p.transform.rotation);		
			p.children.Add(t.GetComponent<Child>());
			messageGUI.DisplayMessage("You had a child. Make sure you protect it!");
		}
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

