using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.PlayerLoop;

public class followDog : MonoBehaviour
{
    public Transform TargetDog;

    public Transform PatrolTarget;
    private Vector3 startingPostion;
    public float followSpeed = 1;
    public float PartolSpeed = 1;
    private SphereCollider followTigger;
    public bool isFollowing;
    private bool patrolBack;
    public float followDistance = 1;
    public float turnSmoothing = 3;
    public AudioSource pantingSource;

    private Vector3 targetVector3;

    private Random rand;

    // Use this for initialization
    void Start()
    {
        isFollowing = false;
        startingPostion = transform.position;
        targetVector3 = new Vector3();
    }

    void OnTriggerEnter(Collider col)
    {
        DogMovement PlayerDog = col.GetComponent<DogMovement>();
        if (PlayerDog && !isFollowing)
        {
            TargetDog = PlayerDog.FollowDog(this.gameObject).transform;
            isFollowing = true;
        }
    }

    void Update()
    {
        var pos = transform.position;
        if (isFollowing)
        {
            Follow();
        }
        else
        {
            Patrol();
        }

        RotateDog();
        //Handles.DrawLine(pos, targetVector3);
    }

    private void RotateDog()
    {
        //TODO fix This up
        float RotainAngle = Vector3.SignedAngle(Vector3.up, targetVector3, Vector3.forward);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, RotainAngle), 1 / turnSmoothing);
        transform.rotation = Quaternion.Euler(0, 0, RotainAngle);
    }

    private void Follow()
    {
        targetVector3 = TargetDog.position +
                        followDistance * (transform.position - TargetDog.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetVector3, 0.1f * followSpeed);
        if (!pantingSource.isPlaying)
        {
            pantingSource.Play();
        }
    }

    private void Patrol()
    {
        if (!patrolBack)
        {
            targetVector3 = PatrolTarget.position;
        }
        else
        {
            targetVector3 = startingPostion;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetVector3, PartolSpeed);

        if (transform.position == PatrolTarget.position)
        {
            patrolBack = true;
        }
        else if (transform.position == startingPostion)
        {
            patrolBack = false;
        }

        if (!pantingSource.isPlaying)
        {
            pantingSource.Play();
        }
    }
}