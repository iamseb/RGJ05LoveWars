using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(InputManager))]
//[RequireComponent(typeof(ScreenManager))]
[RequireComponent(typeof(MissionManager))]
public class Managers : MonoBehaviour
{
    private static GameManager gameManager;
    public static GameManager Game
    {
        get { return gameManager; }
    }

    private static AudioManager audioManager;
    public static AudioManager Audio
    {
        get { return audioManager; }
    }

    private static InputManager inputManager;
    public static InputManager Input
    {
        get { return inputManager; }
    }

    //private static ScreenManager screenManager;
    //public static ScreenManager Screen
    //{
    //    get { return screenManager; }
    //}

	private static MissionManager missionManager;
    public static MissionManager Mission
    {
        get { return missionManager; }
    }

	// Use this for initialization
	void Awake ()
    {
        //Find the references
        gameManager = GetComponent<GameManager>();
        audioManager = GetComponent<AudioManager>();
        inputManager = GetComponent<InputManager>();
        //screenManager = GetComponent<ScreenManager>();
        missionManager = GetComponent<MissionManager>();

        //Make this game object persistant
        DontDestroyOnLoad(gameObject);
	}
}
