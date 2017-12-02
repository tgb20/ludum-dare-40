using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public DoorMat mat;

    int boxes;

    public bool hasRecieved;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Recieve()
    {
        if (!hasRecieved)
        {
            boxes += 1;
            hasRecieved = true;
            mat.SpawnNewDay(boxes);
        }
    }
}
