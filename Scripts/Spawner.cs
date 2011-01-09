using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public Transform[] enemies;
	public bool spawning = false;
	public float timeSinceSpawn = 0.0f;
	public float frequency = 1.0f;
	public float spawnDelay = 0.2f;
	public LevelAttributes level;
	public float minSpawnDistance = 2.0f;
	public float minSpawnDistancePlayer = 5.0f;
	
	void Awake(){
		level = gameObject.GetComponent<LevelAttributes>();
	}
		
	public IEnumerator Start(){
		yield return new WaitForSeconds(3.0f);
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
			Phase phase = Managers.Mission.currentPhase;
			timeSinceSpawn += frequency;
			int minEnemies = phase.spawnMinAmount;
			float phaseTime = phase.spawnDelay;
			if(timeSinceSpawn > phaseTime || enemies.Length <= minEnemies){
				phase.Spawn();
				timeSinceSpawn = 0.0f;
			}
			yield return new  WaitForSeconds(frequency);
		}
	}
	
	public IEnumerator Spawn(Transform badguyType, int amount){		
		for(int i=0; i<amount; i++){
			Vector3 pos = new Vector3(Random.Range(-level.width/2, level.width/2), 0, Random.Range(-level.height/2, level.height/2));
			while(!isFreeSpawn(pos)){
				pos = new Vector3(Random.Range(-level.width/2, level.width/2), 0, Random.Range(-level.height/2, level.height/2));
			}
			Transform t = (Transform)Instantiate(badguyType, pos, Quaternion.identity);
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
		minSpawnDistancePlayer = Managers.Mission.thePlayer.size + 3.0f;
		if((pos - Managers.Mission.thePlayer.transform.position).magnitude < minSpawnDistancePlayer){
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

