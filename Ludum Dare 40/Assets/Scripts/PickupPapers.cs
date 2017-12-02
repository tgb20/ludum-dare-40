using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPapers : MonoBehaviour {


    public GameObject playerCamera;
    bool carrying;
    public float distance;
    public float smooth;

    GameObject carriedPaper;

    public GameObject spray;

	// Use this for initialization
	void Start () {
        spray.transform.position = spray.transform.position + playerCamera.transform.forward * distance;
        spray.transform.parent = playerCamera.transform;
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

            Ray ray = playerCamera.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                Newspaper p = hit.collider.GetComponent<Newspaper>();
                Extinguisher e = hit.collider.GetComponent<Extinguisher>();
                if(p != null){
                    carrying = true;
                    carriedPaper = p.gameObject;
                    p.GetComponent<Rigidbody>().isKinematic = true;
                    p.transform.parent = playerCamera.transform;
                    p.transform.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
                    p.resetPosition();
                }
                if(e != null){
                    carrying = true;
                    carriedPaper = e.gameObject;
                    e.GetComponent<Rigidbody>().isKinematic = true;
                    e.transform.parent = playerCamera.transform;
                    e.transform.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
                }
            }


        }
    }


    void checkDrop(){
        if(Input.GetMouseButtonDown(0)){
            dropPaper();
        }
        if(Input.GetMouseButton(1) && carrying == true){
            if (carriedPaper.GetComponent<Extinguisher>() != null)
            {
                spray.SetActive(true);
            }
        }else{
            spray.SetActive(false);
        }
    }

    void dropPaper(){
        carrying = false;
        carriedPaper.GetComponent<Rigidbody>().isKinematic = false;
        carriedPaper.transform.parent = null;
        carriedPaper = null;
    }



}
