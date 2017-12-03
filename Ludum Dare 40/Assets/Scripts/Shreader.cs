using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shreader : MonoBehaviour {


    public GameController gameManager;

    AudioSource aud;

    void Start(){
        aud = GetComponent<AudioSource>();
    }

    void Update(){
        aud.volume = gameManager.effectVolume;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Newspaper>() != null || collision.gameObject.GetComponent<Extinguisher>() != null){
            if (!gameManager.hasDelivered)
            {
                gameManager.deliveryTime -= 1;
            }
            gameManager.sleepTime -= 1;
            if (!aud.isPlaying)
            {
                aud.Play();
            }
            Destroy(collision.gameObject);

        }
    }
}
