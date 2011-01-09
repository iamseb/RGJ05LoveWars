using UnityEngine;
using System.Collections;

public class Phase : MonoBehaviour
{
	public float secondsLong;
	public int[] musicTracks;
	public Transform[] baddies;
	public int[] spawnAmounts;
	public float spawnDelay;
	public bool isActive = false;
	public Phase nextPhase;
	public Phase previousPhase;
	public int spawnMinAmount = 0;
	public int scoreMultiplier = 100;
	
	public void SetInactive(){
		isActive = false;
	}
	
	public void SetActive(){
		isActive = true;
		Managers.Audio.SetActive(musicTracks);
	}
	
	public void Spawn(){
		for(int i=0; i<spawnAmounts.Length; i++){
			StartCoroutine(Managers.Mission.spawner.Spawn(baddies[i], spawnAmounts[i]));
		}
	}

}

