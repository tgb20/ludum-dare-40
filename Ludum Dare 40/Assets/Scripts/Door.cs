﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public DoorMat mat;
    public GameController gameManager;
    public CharacterMove player;

    public int boxes = 1;

    public bool hasRecieved;

    public AnimationCurve boxCurve;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        gameManager.atDoor = true;
    }
    private void OnMouseExit()
    {
        gameManager.atDoor = false;
    }


    public void Recieve()
    {
        if (!hasRecieved)
        {
            boxes += 1;
            hasRecieved = true;
            player.resetPostion();
            mat.SpawnNewDay(Mathf.RoundToInt(boxCurve.Evaluate(boxes)));
            gameManager.hasDelivered = true;
        }
    }
}
