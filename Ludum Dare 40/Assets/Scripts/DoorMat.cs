using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMat : MonoBehaviour {
	


    public void SpawnNewDay(int count){


        for (int i = 0; i < count; i++)
        {
            GameObject paper =Instantiate(Resources.Load("Newspaper"), new Vector3(transform.position.x, transform.position.y + 2 + i, transform.position.z), Quaternion.identity) as GameObject;
            paper.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }




}
