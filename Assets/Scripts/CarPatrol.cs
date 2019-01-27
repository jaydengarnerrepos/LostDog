using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPatrol : MonoBehaviour
{

    public GameObject PartrolPointsGO;
    public float maxspeed;
    public float acceration;
    public float turnSpeed;



    private List<Vector3> PartrolPoints;
    private int currentPoint;
    public float currentRation;
    // Use this for initialization
    void Start ()
    {
        PartrolPoints = new List<Vector3>();
        // PartrolPoints.Add(transform.position);
        var transforms = PartrolPointsGO.GetComponentsInChildren<Transform>();
        foreach (var point in transforms)
        {
            PartrolPoints.Add(point.position);
        }

        currentPoint = 1;

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position == PartrolPoints[currentPoint])
        {
            if (currentPoint >= PartrolPoints.Count - 1)
            {
                currentPoint = 0;
            }
            else
            {
                currentPoint++;
            }
            currentRation = Vector3.SignedAngle(Vector3.up, PartrolPoints[currentPoint] - transform.position, Vector3.forward);
        }

        transform.position = Vector3.MoveTowards(transform.position, PartrolPoints[currentPoint], maxspeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, currentRation), turnSpeed);
    }
}
