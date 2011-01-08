using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private GameState currentState;
    public GameState State
    {
        get { return currentState; }
    }

	//Changes the current game state
	public void SetState(System.Type newStateType)
    {
        if (currentState != null)
        {
            currentState.OnDeactivate();
        }

        currentState = GetComponentInChildren(newStateType) as GameState;
        if (currentState != null)
        {
            currentState.OnActivate();
        }
	}

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    void Start()
    {
        SetState(typeof(MainMenuState));
    }
}
