using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreader : MonoBehaviour {


    public GameController gameManager;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Newspaper>() != null || collision.gameObject.GetComponent<Extinguisher>() != null){
            if (!gameManager.hasDelivered)
            {
                gameManager.deliveryTime -= 1;
            }
            gameManager.sleepTime -= 1;
            Destroy(collision.gameObject);

        }
    }
}
