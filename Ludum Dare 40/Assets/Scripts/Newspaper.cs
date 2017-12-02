using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

	public Renderer rend;

	Color baseColor;

	bool inStack;

    GameController gameManager;

	void Start(){
		rend = GetComponent<Renderer> ();
		baseColor = rend.material.color;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>();
	}

	void OnMouseOver(){
        rend.material.color = Color.yellow;
	}
	void OnMouseExit(){
		rend.material.color = baseColor;
	}

	void FixedUpdate(){
        
	}


	public void resetPosition(){

		transform.rotation = Quaternion.identity;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Foot"){
            if (!gameManager.hasDelivered)
            {
                gameManager.deliveryTime -= 1;
            }
            gameManager.sleepTime -= 1;
            Destroy(gameObject);
        }
    }


}
