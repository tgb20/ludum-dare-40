using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

	public Renderer rend;

	Color baseColor;

	bool inStack;


    public GameObject heatBit;


    public float heat;

    bool heatUp;


    GameController gameManager;

	void Start(){
		rend = GetComponent<Renderer> ();
		baseColor = rend.material.color;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>();
        rend.material.SetColor("_EMISSION", Color.red);
	}

	void OnMouseOver(){
        rend.material.color = Color.yellow;
	}
	void OnMouseExit(){
		rend.material.color = baseColor;
	}

	void Update(){
        if (heatUp)
        {
            heat += Time.deltaTime * 2;
        }
        else if(heat > 0){
            heat -= Time.deltaTime * 2;
        }

        rend.material.SetColor("_EmissionColor", new Vector4(heat/100,0,0,heat/100));


        if(heat > 20){
            heatBit.SetActive(true);
        }else{
            heatBit.SetActive(false);
        }


        if(heat > 100){
            if (!gameManager.hasDelivered)
            {
                gameManager.deliveryTime -= 1;
            }
            gameManager.sleepTime -= 1;
            Destroy(gameObject);
        }


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
        if(other.gameObject.tag == "Heater"){
            heatUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Heater"){
            heatUp = false;
        }
    }


}
