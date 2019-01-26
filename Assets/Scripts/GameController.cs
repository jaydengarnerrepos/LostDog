using System.Collections.Generic;
using UnityEngine;

class GameController : MonoBehaviour
{
    public GameEvent startState;

    private void Start()
    {
        startState.Raise();
        //Debug.Log("LEAVING HOME.");
    }
}