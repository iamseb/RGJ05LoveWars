using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour
{
	public bool showing = false;
	
	void OnGUI () {
		if(showing){
			
			// Make a group on the center of the screen
			GUILayout.BeginArea(new Rect(Screen.width/2-50, Screen.height/2-50, 100, 100));
			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.
		
			// We'll make a box so you can see where the group is on-screen.
			GUILayout.Box("Game Over");
		
			// End the group we started above. This is very important to remember!
			GUILayout.EndArea();
		}
	}
}
