using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {


    public GameObject playerCamera;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1))
            {
                Bed b = hit.collider.GetComponent<Bed>();
                if (b != null)
                {
                    b.Sleep();
                }
            }


        }
	}
}
