using UnityEngine;
using System.Collections;


public class MainMenuGUI : MonoBehaviour
{
	
/* Example level loader */

	private Rect MiddleBox(int left, int top, int width, int height) {
		Rect r = new Rect( (Screen.width/2) - (width/2) + left, (Screen.height/2) - (height/2) + top, width, height);
		return r;
	}
	
	void OnGUI() {
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button(MiddleBox(0, -5, 80, 20), "Play Game")) {
			Managers.Game.SetState(typeof(GameRunningState));
		}
	
	}
}
