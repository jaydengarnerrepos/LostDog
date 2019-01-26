using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using UnityEngine;

class DogMovement : MonoBehaviour
{
    private Player Playerinput;
    private Camera mainCamera;
    private float cameraYAngle;
    public float movmentSpeed = 0.3f;
    public float playerRotainAngle;
    [Range(1, 10)] public float turnSmoothing = 2;

    public Animator animator;

    public Stack<GameObject> FollowingDogs;

    public GameObject MarkerObject;

    void Start()
    {
        mainCamera = Camera.main;
        cameraYAngle = mainCamera.transform.eulerAngles.y;
        Playerinput = Rewired.ReInput.players.GetPlayer(RewiredConsts.Player.System);
        FollowingDogs = new Stack<GameObject>();
    }

    void Update()
    {
        Vector2 rawPlayerAxisInput = Playerinput.GetAxis2DRaw("Horizontal", "Vertical");
        if (rawPlayerAxisInput.magnitude > 0)
        {
            Vector2 playerAxisInput = rawPlayerAxisInput.normalized * movmentSpeed;
            playerRotainAngle = Vector3.SignedAngle(Vector3.up, playerAxisInput, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, playerRotainAngle),
                1 / turnSmoothing);
            transform.position += new Vector3(playerAxisInput.x, playerAxisInput.y, 0);
        }

        animator.SetBool("Moving", rawPlayerAxisInput.magnitude > 0);

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
    }
}