using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public float deliveryTime;

    public float sleepTime;

    public Text sleepText;
    public Text deliveryText;
    public Text gameOverText;

    public bool hasDelivered;

    public int numDays = 1;

    public GameObject gameOver;
    public GameObject retry;
    public GameObject quit;



	void Update () {
        if (!hasDelivered)
        {
            deliveryTime -= Time.deltaTime;
        }
        sleepTime -= Time.deltaTime;

        sleepText.text = Mathf.RoundToInt(sleepTime).ToString();
        deliveryText.text = Mathf.RoundToInt(deliveryTime).ToString();

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
            gameOver.SetActive(true);
            retry.SetActive(true);
            quit.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            gameOverText.text = "You survived " + numDays + " days!";
        }

	}


    public void Retry()
    {
        SceneManager.LoadSceneAsync("Main");
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Quit()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
