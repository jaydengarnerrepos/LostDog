using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Rewired.ReInput.players.GetPlayer(RewiredConsts.Player.System).GetButton(RewiredConsts.Action.GamePlay.Start))
        {
            loadScene();
        }
        if (Rewired.ReInput.players.GetPlayer(RewiredConsts.Player.System).GetButton(RewiredConsts.Action.GamePlay.Quit))
        {
            Application.Quit();
        }

    }

    public void loadScene()
    {
            SceneManager.LoadScene("Main");
    }
}
