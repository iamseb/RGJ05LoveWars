using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour
{
	
	public Player player;
	
	void Start(){
		player = Managers.Mission.thePlayer.GetComponent<Player>();
	}
	
	void OnGUI() {
		float health = player.health;
		float lives = player.lives;
		int score = player.score;
		// GUILayout.BeginArea(new Rect(Screen.width-300, Screen.height-100, Screen.width, Screen.height));
		GUILayout.BeginArea(new Rect(Screen.width-200, 0, 200, 50));
		GUILayout.Label("Lives: " + lives + ", Health: " + health);
		GUILayout.Label("Score: " + score);
		GUILayout.EndArea();
	}
}

