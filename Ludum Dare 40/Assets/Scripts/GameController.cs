using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public float deliveryTime;

    public CharacterMove player;
    public Door door;
    public GameObject playerCamera;
    public GameObject mainCamera;

    public float sleepTime;

    public Text sleepText;
    public Text deliveryText;
    public Text gameOverText;

    public Slider musicVolumeSlider;
    public Slider effectVolumeSlider;
    public Slider mouseSpeed;

    public bool hasDelivered;

    public int numDays = 1;

    public GameObject gameOver;
    public GameObject retry;
    public GameObject quit;


    public GameObject sleep;
    public GameObject delivery;
    public GameObject startGameButton;
    public GameObject quitButton;
    public GameObject titleText;
    public GameObject howTotext;
    public GameObject cursor;
    public GameObject musicSlider;
    public GameObject effectSlider;
    public GameObject mouseSlider;
    public GameObject credits;
    

    public GameObject[] papers;


    public float musicVolume;
    public float effectVolume;
    public float mouseSensitivity = 10;

    public bool gameStarted;


    void DestroyPapers(){
        papers = GameObject.FindGameObjectsWithTag("Paper");
        for (int i = 0; i < papers.Length; i++)
        {
            Destroy(papers[i]);
        }
    }

	void Update () {

        if (musicSlider.activeSelf)
        {
            musicVolume = musicVolumeSlider.value;
            effectVolume = effectVolumeSlider.value;
            mouseSensitivity = mouseSpeed.value;
        }

        GetComponent<AudioSource>().volume = musicVolume;

        if (gameStarted)
        {

            if(Input.GetKey(KeyCode.Escape)){
                toggleMenu(true);

            }


            if (!hasDelivered)
            {
                deliveryTime -= Time.deltaTime;
            }
            sleepTime -= Time.deltaTime;

            sleepText.text = "Sleep By: " + Mathf.RoundToInt(sleepTime);
            deliveryText.text = "Mail By: " + Mathf.RoundToInt(deliveryTime);


            if(Mathf.RoundToInt(deliveryTime) % 5 == 0 && !door.hasRecieved){
                door.GetComponent<AudioSource>().volume = effectVolume;
                if (!door.GetComponent<AudioSource>().isPlaying)
                {
                    door.GetComponent<AudioSource>().Play();
                }
            }


            if (sleepTime <= 10)
            {
                sleepText.color = Color.red;
            }
            else
            {
                sleepText.color = Color.white;
            }
            if (deliveryTime <= 10)
            {
                deliveryText.color = Color.red;
            }
            else
            {
                deliveryText.color = Color.white;
            }


            if (deliveryTime <= 0 || sleepTime <= 0)
            {
                print("Game Over");
                toggleMenu(true);
                Cursor.lockState = CursorLockMode.None;
                gameOverText.text = "You survived " + numDays + " days!";
            }
        }

	}


    void toggleMenu(bool toggle){
        gameOver.SetActive(toggle);
        retry.SetActive(toggle);
        quit.SetActive(toggle);
        player.GetComponent<MouseLook>().enabled = !toggle;
        player.GetComponent<CharacterMove>().enabled = !toggle;
        playerCamera.GetComponent<MouseLook>().enabled = !toggle;
        cursor.SetActive(!toggle);
        if (toggle){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }else{
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void toggleGame(bool toggle){
        gameOver.SetActive(false);
        retry.SetActive(false);
        quit.SetActive(false);
        cursor.SetActive(toggle);
        DestroyPapers();
        sleep.SetActive(toggle);
        delivery.SetActive(toggle);
        playerCamera.SetActive(toggle);
        player.GetComponent<MouseLook>().enabled = toggle;
        player.GetComponent<CharacterMove>().enabled = toggle;
        playerCamera.GetComponent<MouseLook>().enabled = toggle;
        mainCamera.SetActive(!toggle);
        startGameButton.SetActive(!toggle);
        quitButton.SetActive(!toggle);
        titleText.SetActive(!toggle);
        howTotext.SetActive(!toggle);
        musicSlider.SetActive(!toggle);
        effectSlider.SetActive(!toggle);
        credits.SetActive(!toggle);
        mouseSlider.SetActive(!toggle);
        gameStarted = toggle;
        if(toggle){
            Retry();
        }
    }


    public void Retry()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player.resetPostion();
        deliveryTime = 30;
        numDays = 1;
        sleepTime = 60;
        door.boxes = 1;
        hasDelivered = false;
        door.hasRecieved = false;
        DestroyPapers();
        toggleMenu(false);

    }

    public void Quit()
    {
        toggleGame(false);
    }

    public void StartGame(){
        toggleGame(true);
    }

    public void QuitGame(){
        Application.Quit();
    }


}
