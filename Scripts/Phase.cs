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
	public int numChildren = 0;
	public float growMultiplier = 1.5f;
	
	public void SetInactive(){
		isActive = false;
		//Managers.Mission.thePlayer.Size *= 1.0f / growMultiplier;
		Destroy(gameObject, 3.0f);
	}
	
	public void SetActive(){
		isActive = true;
		Managers.Mission.thePlayer.Size *= growMultiplier;
		if(Managers.Mission.thePlayer.player.children.Count < numChildren){
			Managers.Mission.SpawnChild();
		}
		Debug.Log("Setting audio active for tracks:" + musicTracks[0]);
		Managers.Audio.SetActive(musicTracks);
	}
	
	public void Spawn(){
		Spawner spawner = Managers.Mission.spawner;
		for(int i=0; i<spawnAmounts.Length; i++){
			Transform baddie = baddies[i];
			int amount = spawnAmounts[i];
			StartCoroutine(spawner.Spawn(baddie, amount));
		}
	}

}

