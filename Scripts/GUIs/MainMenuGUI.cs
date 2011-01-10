using UnityEngine;
using System.Collections;


public class MainMenuGUI : MonoBehaviour
{
	
	private Rect MiddleBox(int left, int top, int width, int height) {
		Rect r = new Rect( (Screen.width/2) - (width/2) + left, (Screen.height/2) - (height/2) + top, width, height);
		return r;
	}
	
	void OnGUI() {
		GUI.Label(MiddleBox(0, 90, 200, 150), "You need to collect hearts to be loved. Try to avoid arguments. As you grow you will have children. Use the right joystick to move them and protect them from collision. If they're lost, you'll be unable to do anything for some time.");
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button(MiddleBox(0, -5, 80, 20), "Play Game")) {
			Managers.Game.SetState(typeof(GameRunningState));
		}
	
	}
}
