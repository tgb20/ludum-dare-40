using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

	public Renderer rend;

	Color baseColor;

	bool inStack;

	GameObject stackPaper;

	GameObject gameManager;

	void Start(){
		rend = GetComponent<Renderer> ();
		baseColor = rend.material.color;
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
	}

	void OnMouseOver(){
		rend.material.color = Color.red;
	}
	void OnMouseExit(){
		rend.material.color = baseColor;
	}

	void Update(){
		if (stackPaper != null) {
			if (Mathf.Abs(stackPaper.transform.rotation.z) > 10 || Mathf.Abs(stackPaper.transform.rotation.x) > 10) {
				inStack = false;
				gameManager.GetComponent<ScoreController> ().score -= 1;
				print ("Left Stack");
			}
		}
	}


	public void resetPosition(){

		transform.rotation = Quaternion.identity;
	}

	void OnCollisionEnter(Collision collision){

		Newspaper p = collision.gameObject.GetComponent<Newspaper> ();
		if (p != null) {
			if (collision.gameObject.transform.position.y > transform.position.y) {
				print ("In Stack");
				inStack = true;
				stackPaper = collision.gameObject;
				gameManager.GetComponent<ScoreController> ().score += 1;
			}
		}


	}
	void OnCollisionExit(Collision collision){
		if (inStack) {
			if (collision.gameObject == stackPaper) {
				inStack = false;
				gameManager.GetComponent<ScoreController> ().score -= 1;
				print ("Left Stack");
			}
		}
	}




}
