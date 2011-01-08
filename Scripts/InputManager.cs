using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public ArrayList handledKeys = new ArrayList();
	private ArrayList registeredHandlers = new ArrayList();
	
	void Start() {
	}

	void Update() {
		foreach (KeyCode key in handledKeys) {
        	if (Input.GetKeyDown(key)) {
            	SendKeyDown(key);
			}
            if (Input.GetKeyUp(key)) {
            	SendKeyUp(key);
			}
		}
		if (Input.GetKey(KeyCode.Escape)) {
			Managers.Game.SetState(typeof(MainMenuState));
		}
	}
	
	void SendKeyDown(KeyCode key) {
		foreach (GameObject handler in registeredHandlers) {
			if(handler){
				handler.SendMessage("KeyDown", key);
			}
		}		
	}

	void SendKeyUp(KeyCode key) {
		foreach (GameObject handler in registeredHandlers) {
			if(handler){
				handler.SendMessage("KeyUp", key);
			}
		}		
	}
	
	public void RegisterHandler(GameObject handled, ArrayList keys) {
		handledKeys.AddRange(keys);
		registeredHandlers.Add(handled);
	}
	
	public void UnregisterHandler(GameObject handled, ArrayList keys) {
		for(int i=0; i<keys.Count; i++) {
			handledKeys.Remove(keys[i]);
		}
		registeredHandlers.Remove(handled);
	}
	
	
}

