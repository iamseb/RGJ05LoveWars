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
	public LevelAttributes level;
	public float minSpawnDistance = 2.0f;
	
	void Awake(){
		level = gameObject.GetComponent<LevelAttributes>();
	}
		
	void Start(){
		Spawning = true;
	}
	
	public void DeleteEnemy(Transform dead){
		Transform[] newEnemies = new Transform[enemies.Length - 1];
		int j = 0;
		for(int i=0; i<enemies.Length; i++){
			Transform t = enemies[i];
			if(t.GetInstanceID() != dead.GetInstanceID()){
				newEnemies[j] = enemies[i];
				j++;
			}
		}
		enemies = newEnemies;
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
		for(int i=0; i<amount; i++){
			Vector3 pos = new Vector3(Random.Range(-level.width/2, level.width/2), 0, Random.Range(-level.height/2, level.height/2));
			while(!isFreeSpawn(pos)){
				pos = new Vector3(Random.Range(-level.width/2, level.width/2), 0, Random.Range(-level.height/2, level.height/2));
			}
			Transform t = (Transform)Instantiate(badGuyTypes[phase], pos, Quaternion.identity);
			t.gameObject.GetComponent<BadGuy>().spawner = this;
			Transform[] newEnemies = new Transform[enemies.Length + 1];			
			for(int j=0; j<enemies.Length; j++){
				newEnemies[j] = enemies[j];
			}
			newEnemies[enemies.Length] = t;
			enemies = newEnemies;
			yield return new WaitForSeconds(spawnDelay);
		}
	}
	
	public bool Spawning {
		get { return spawning; }
		set {
			spawning = value;
			StartCoroutine(SpawnEnemies());
		}
	}
	
	public bool isFreeSpawn(Vector3 pos){
		if((pos - Managers.Mission.thePlayer.transform.position).magnitude < minSpawnDistance){
			return false;
		}
		foreach(Transform t in enemies){
			if((pos - t.position).magnitude < minSpawnDistance){
				return false;
			}
		}
		return true;
	}
	
	
}

