using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class UIController : MonoBehaviour
{
    public GameEvent ReturnedHome;
    public DogMovement PlayerDog;
    public Text Friends;
	// Use this for initialization
	void Start ()
    {
        if (Friends == null)
        {
            Friends = GetComponent<Text>();
        }

        ReturnedHome.Raised += EnableEndUI;
        gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerDog.Playerinput.GetButtonDown("Action0"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (PlayerDog.Playerinput.GetButtonDown(RewiredConsts.Action.GamePlay.Quit))
        {
            Application.Quit();
        }

    }

    void EnableEndUI()
    {
        gameObject.SetActive(true);
        Friends.text = "You made "+ PlayerDog.FollowingDogs.Count +" Extra Friends";
        PlayerDog.enabled = false;
    }

}
