using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

	public Renderer rend;

	Color baseColor;

	bool inStack;

	void Start(){
		rend = GetComponent<Renderer> ();
		baseColor = rend.material.color;
	}

	void OnMouseOver(){
		rend.material.color = Color.red;
	}
	void OnMouseExit(){
		rend.material.color = baseColor;
	}

	void FixedUpdate(){
        
	}


	public void resetPosition(){

		transform.rotation = Quaternion.identity;
	}
}
