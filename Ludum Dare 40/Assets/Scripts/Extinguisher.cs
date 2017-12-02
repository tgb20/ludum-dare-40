using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour {

    Renderer rend;

    Color baseColor;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        rend.material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        rend.material.color = baseColor;
    }

    public void resetPosition()
    {

        transform.rotation = Quaternion.identity;
    }


}
