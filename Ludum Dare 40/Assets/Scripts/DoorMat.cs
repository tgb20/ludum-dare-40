using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMat : MonoBehaviour {


    GameObject gameManager;


    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	


    public void SpawnNewDay(int count){


        for (int i = 0; i < count; i++)
        {
            Instantiate(Resources.Load("Newspaper"), new Vector3(transform.position.x, transform.position.y + 2 + count/2, transform.position.z), Quaternion.identity);
        }
    }




}
