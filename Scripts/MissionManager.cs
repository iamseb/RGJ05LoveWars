using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour
{
	
	public PlayerController thePlayer;
	public bool isRunning = false;
	public AudioClip[] music;
	private ArrayList audios;
	public string[] phases;
	public float[] phaseTimes;
	public int currentPhaseNum = 0;
	public string currentPhase;
	public float elapsedTime = 0.0f;
	
	void Awake(){
	}
	
	void Start(){
		audios = new ArrayList();
		int counter = 0;
		foreach(AudioClip c in music){
			AudioSource s = Managers.Audio.AddAndPlay(c, phases[counter], true);
			s.volume = 0;
			audios.Add(s);
			counter ++;
		}
		Reset();
		isRunning = true;
	}
	
	void ChangePhase(int phase){
		currentPhaseNum = phase;
		currentPhase = phases[phase];
		foreach(AudioSource s in audios){
			Debug.Log("Called with phase: " + phase + ", checking index:" +  audios.IndexOf(s));
			float targetVolume = 0.0f;
			if(audios.IndexOf(s) <= phase){
				targetVolume = 1.0f;
			}
			Debug.Log("Calling SetTargetVolume");
			StartCoroutine(Managers.Audio.SetTargetVolume(phases[audios.IndexOf(s)], targetVolume, 2.0f));
		}
	}
	
	void Update(){		
		if (isRunning) {
			elapsedTime += Time.deltaTime;
			if(elapsedTime > phaseTimes[currentPhaseNum] && currentPhaseNum < phases.Length - 1){
				Debug.Log("Changing phase to " + currentPhaseNum + 1);
				ChangePhase(currentPhaseNum+1);
			}
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
		ChangePhase(0);
	}
	
}

