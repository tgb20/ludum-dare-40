using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour {

    public Renderer rend;

    Color[] baseColor = new Color[] { Color.blue, Color.blue, Color.blue };

	bool inStack;



    public GameObject heatBit;

    public Texture[] newsPaperHeaders;


    public float heat;

    bool heatUp;


    public float lightVal;

    bool lightUp;


    GameController gameManager;

	void Start(){
        for (int i = 0; i < 3; i++)
        {
            baseColor[i] = rend.materials[i].color;
        }
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>();

        rend.materials[1].mainTexture = newsPaperHeaders[Random.Range(0, newsPaperHeaders.Length)];

        rend.material.SetColor("_EMISSION", Color.red);
	}

    void OnMouseOver()
    {
        for (int i = 0; i < 3; i++)
        {
            rend.materials[i].color = Color.yellow;
        }
    }
    void OnMouseExit()
    {
        for (int i = 0; i < 3; i++)
        {
            rend.materials[i].color = baseColor[i];
        }
    }

	void Update(){
        if (heatUp)
        {
            heat += Time.deltaTime * 8;
        }
        else if(heat > 0){
            heat -= Time.deltaTime * 8;
        }

        if(lightUp){
            lightVal += Time.deltaTime * 2;
        }
        else if(lightVal > 0){
            lightVal -= Time.deltaTime * 2;
        }
        if(lightVal > 0){
            rend.material.SetColor("_EmissionColor", new Vector4(lightVal / 100, lightVal / 100, 0, lightVal / 100));
        }else if(heat > 0){
            rend.material.SetColor("_EmissionColor", new Vector4(heat / 100, 0, 0, heat / 100));
        }


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

        if(lightVal > 100){
            if (!gameManager.hasDelivered)
            {
                gameManager.deliveryTime -= 1;
            }
            gameManager.sleepTime -= 1;
            Destroy(gameObject);
        }



	}


	public void resetPosition(){

        transform.rotation = new Quaternion(0,180,0,0);
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
        else if(other.gameObject.tag == "Heater"){
            heatUp = true;
        }
        else if(other.gameObject.tag == "Spray"){
            heat = 0;
            heatBit.SetActive(false);
        }
        else if (other.gameObject.tag == "Sunlight")
        {
            lightUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Heater"){
            heatUp = false;
        }
        if (other.gameObject.tag == "Sunlight")
        {
            lightUp = false;
        }
    }


}
