using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public int[] phaseAmounts;
	public float[] phaseTimers;
	public Transform[] enemies;
	public bool spawning = false;
	public float timeSinceSpawn = 0.0f;
	public float frequency = 1.0f;
	public float spawnDelay = 0.2f;
	public Transform[] badGuyTypes;
	
	void Awake(){
	}
		
	void Start(){
		Spawning = true;
	}

	public IEnumerator SpawnEnemies(){
		while(spawning){
			timeSinceSpawn += frequency;
			int phaseNum = Managers.Mission.currentPhaseNum;
			int phaseAmount = phaseAmounts[phaseNum];
			float phaseTime = phaseTimers[phaseNum];
			int minEnemies = phaseAmount / 4;
			if(timeSinceSpawn > phaseTime || enemies.Length <= minEnemies){
				Debug.Log("Spawning " + phaseAmount + " enemies.");
				StartCoroutine(Spawn(phaseAmount, phaseNum));
				timeSinceSpawn = 0.0f;
			}
			yield return new  WaitForSeconds(frequency);
		}
	}
	
	public IEnumerator Spawn(int amount, int phase){
		int currentLen = enemies.Length;
		int nextLen = enemies.Length + amount;
		Transform[] newEnemies = new Transform[nextLen];
		
		for(int i=0; i<currentLen; i++){
			newEnemies[i] = enemies[i];
		}
		
		for(int i=0; i<amount; i++){
			Transform t = (Transform)Instantiate(badGuyTypes[phase]);
			newEnemies[currentLen+i] = t;
			yield return new WaitForSeconds(spawnDelay);
		}
		
		enemies = newEnemies;
	}
	
	public bool Spawning {
		get { return spawning; }
		set {
			spawning = value;
			StartCoroutine(SpawnEnemies());
		}
	}
	
	
}

