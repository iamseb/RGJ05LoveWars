using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour
{

	void OnGUI() {
		int score = 0;
		// GUILayout.BeginArea(new Rect(Screen.width-300, Screen.height-100, Screen.width, Screen.height));
		GUILayout.BeginArea(new Rect(Screen.width-300, 0, 300, 200));
		GUILayout.Box("score: " + score);
		GUILayout.EndArea();
	}
}

