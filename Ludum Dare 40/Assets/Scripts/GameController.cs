using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public float deliveryTime;

    public float sleepTime;

    public Text sleepText;
    public Text deliveryText;

    public bool hasDelivered;


	void Update () {
        if (!hasDelivered)
        {
            deliveryTime -= Time.deltaTime;
        }
        sleepTime -= Time.deltaTime;

        sleepText.text = sleepTime.ToString();
        deliveryText.text = deliveryTime.ToString();

        if(sleepTime < 10){
            sleepText.color = Color.red;
        }else{
            sleepText.color = Color.white;
        }
        if(deliveryTime < 10){
            deliveryText.color = Color.red;
        }else{
            deliveryText.color = Color.white;
        }


        if(deliveryTime < 0 || sleepTime < 0 ){
            print("Game Over");
        }

	}
}
