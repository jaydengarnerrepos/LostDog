using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GameController : MonoBehaviour
{
    public GameEvent startState;

    private void Start()
    {
        startState.Raise();
        //Debug.Log("LEAVING HOME.");
    }
}