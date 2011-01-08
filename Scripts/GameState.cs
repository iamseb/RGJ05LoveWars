using UnityEngine;
using System.Collections;

public abstract class GameState : MonoBehaviour
{
    public abstract void OnActivate();
    public abstract void OnDeactivate();
    public abstract void OnUpdate();
}
