using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;

class DogMovement : MonoBehaviour
{
    [HideInInspector] public Player Playerinput;
    private Camera mainCamera;
    private float cameraYAngle;
    public float movmentSpeed = 0.3f;
    public float playerRotainAngle;
    [Range(1, 10)] public float turnSmoothing = 2;

    public Animator animator;
    public Rigidbody rigidbody;

    public Stack<GameObject> FollowingDogs;

    public float PeeTime = 0.5f;
    public GameObject MarkerObject;
    public AudioSource hopSource;
    public GameEvent leavingHome, returningHome, returnedHome;
    private bool isPlayerControlled;

    private void OnEnable()
    {
        leavingHome.Raised += OnLeavingHome;
        returningHome.Raised += OnReturningHome;
        returnedHome.Raised += OnReturnedHome;
    }

    private void OnDisable()
    {
        leavingHome.Raised -= OnLeavingHome;
        returningHome.Raised -= OnReturningHome;
        returnedHome.Raised -= OnReturnedHome;
    }

    private void OnLeavingHome()
    {
        isPlayerControlled = false;
    }

    private void OnReturningHome()
    {
        isPlayerControlled = true;
    }

    private void OnReturnedHome()
    {
        isPlayerControlled = false;
    }

    void Start()
    {
        mainCamera = Camera.main;
        cameraYAngle = mainCamera.transform.eulerAngles.y;
        Playerinput = Rewired.ReInput.players.GetPlayer(RewiredConsts.Player.System);
        FollowingDogs = new Stack<GameObject>();
    }

    void Update()
    {
        if (!isPlayerControlled) return;
        Vector2 rawPlayerAxisInput = Playerinput.GetAxis2DRaw("Horizontal", "Vertical");
        if (rawPlayerAxisInput.magnitude > 0)
        {
            Vector2 playerAxisInput = rawPlayerAxisInput.normalized * movmentSpeed;
            playerRotainAngle = Vector3.SignedAngle(Vector3.up, playerAxisInput, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, playerRotainAngle),
                1 / turnSmoothing);
            rigidbody.MovePosition(rigidbody.position + new Vector3(playerAxisInput.x, playerAxisInput.y, 0));
        }

        animator.SetBool("Moving", rawPlayerAxisInput.magnitude > 0);
        if (rawPlayerAxisInput.magnitude > 0)
        {
            if (!hopSource.isPlaying)
            {
                hopSource.Play();
            }
        }
        else
        {
            hopSource.Stop();
        }

        if (Playerinput.GetButtonDown("Action0"))
        {
            MarkTerritory();
        }
    }

    public GameObject FollowDog(GameObject newFollowingDog)
    {
        if (FollowingDogs.Count == 0)
        {
            FollowingDogs.Push(newFollowingDog);
            return this.gameObject;
        }
        else
        {
            var dogToFollow = FollowingDogs.Peek();
            FollowingDogs.Push(newFollowingDog);
            return dogToFollow;
        }
    }

    public void MarkTerritory()
    {
        GameObject marker = Instantiate(MarkerObject, transform);
        marker.transform.parent = transform.parent;
        isPlayerControlled = false;
        StartCoroutine(PausePlayermovment());
    }

    IEnumerator PausePlayermovment()
    {
        yield return new WaitForSeconds(PeeTime);
        isPlayerControlled = true;
    }
}