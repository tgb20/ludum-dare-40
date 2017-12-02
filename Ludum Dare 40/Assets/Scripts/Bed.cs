using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {



    public Door door;
    public CharacterMove player;
    public GameController gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Sleep(){
        door.hasRecieved = false;
        player.resetPostion();
        gameManager.sleepTime = 60;
        gameManager.deliveryTime = 30;
        gameManager.hasDelivered = false;
        gameManager.numDays += 1;
    }


}
