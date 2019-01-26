using System.Collections.Generic;
using UnityEngine;

class GameController : MonoBehaviour
{
    public GameEvent leavingHomeState;

    private void Start()
    {
        leavingHomeState.Raise();
        Debug.Log("LEAVING HOME.");
    }
}