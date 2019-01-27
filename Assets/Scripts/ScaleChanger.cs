using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour {

    public float StartScale =0;
    public float EndScale= 1;
    public float SizeRate= 0.01f;

    private Vector3 EndScaleVector;
    // Use this for initialization
    void Start()
    {
        transform.localScale = new Vector3(StartScale, StartScale, StartScale);
        EndScaleVector = new Vector3(EndScale, EndScale, EndScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale != EndScaleVector )
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, EndScaleVector, SizeRate);
        }
        else
        {
            this.enabled = false;
        }
    }
}
