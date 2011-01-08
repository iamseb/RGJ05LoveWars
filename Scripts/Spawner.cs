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
	public Transform[] badGuyTypes;
	
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
				timeSinceSpawn = 0.0f;
			}
			yield return new  WaitForSeconds(frequency);
		}
	}
	
	public bool Spawning {
		get { return spawning; }
		set {
			spawning = value;
			StartCoroutine(SpawnEnemies());
		}
	}
	
	
}

