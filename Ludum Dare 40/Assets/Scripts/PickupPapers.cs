using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPapers : MonoBehaviour {


    public GameObject playerCamera;
    bool carrying;
    public float distance;
    public float smooth;

    GameObject carriedPaper;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(carrying){
            checkDrop();
        } else{
            pickup();
        }
	}

    void pickup(){
        if(Input.GetMouseButtonDown(0)){
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                Newspaper p = hit.collider.GetComponent<Newspaper>();
                if(p != null){
                    carrying = true;
                    carriedPaper = p.gameObject;
                    p.GetComponent<Rigidbody>().isKinematic = true;
                    p.transform.parent = playerCamera.transform;
                    p.transform.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
                    p.resetPosition();
                }
            }


        }
    }


    void checkDrop(){
        if(Input.GetMouseButtonDown(0)){
            dropPaper();
        }
    }

    void dropPaper(){
        carrying = false;
        carriedPaper.GetComponent<Rigidbody>().isKinematic = false;
        carriedPaper.transform.parent = null;
        carriedPaper = null;
    }



}
