using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public DoorMat mat;
    public GameController gameManager;

    int boxes = 1;

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
            gameManager.hasDelivered = true;
        }
    }
}
