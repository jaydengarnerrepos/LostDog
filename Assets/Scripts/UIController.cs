using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class UIController : MonoBehaviour
{
    public GameEvent ReturnedHome;
    public DogMovement PlayerDog;
    public Image blackFadeImage;

    public Text Friends;

    // Use this for initialization
    void Start()
    {
        if (Friends == null)
        {
            Friends = GetComponent<Text>();
        }

        ReturnedHome.Raised += EnableEndUi;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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

    void EnableEndUi()
    {
        gameObject.SetActive(true);
        StartCoroutine(EnablingEndUi());
    }

    IEnumerator EnablingEndUi()
    {
        blackFadeImage.color = new Color(blackFadeImage.color.r, blackFadeImage.color.g, blackFadeImage.color.b, 0f);
        Friends.text = "";
        blackFadeImage.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);
        Friends.text = "You made " + PlayerDog.FollowingDogs.Count + " Extra Friends";
        yield return new WaitForSeconds(3f);
        Friends.text = "";
        blackFadeImage.DOFade(1f, 1f);
        yield return new WaitForSeconds(1f);
        PlayerDog.enabled = false;
        SceneManager.LoadScene("CreditsScreen");
    }
}