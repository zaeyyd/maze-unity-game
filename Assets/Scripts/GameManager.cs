using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float elapsedRunningTime = 0f;
    private float startTime = 0f;
    private int timeInt;

    public TextMeshProUGUI playeNameText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI keysText;
    private string keyString;
    public GameObject player;

    private PlayerController playerScript;
    public GameObject gameEndMenu;
    public TextMeshProUGUI finalScore;
    void Start()
    {
        playeNameText.text = PlayerPrefs.GetString("playerName");
        playerScript = player.GetComponent<PlayerController>();
        elapsedRunningTime = Time.time;
        startTime = Time.time;
        gameEndMenu.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        elapsedRunningTime = Time.time - startTime;
        timeInt = (int)elapsedRunningTime;
        timerText.text = timeInt.ToString();

        keyString = "";

        if (playerScript.hasBlueKey){
            keyString = keyString + "[ blue key ] ";
        }
        if (playerScript.hasRedKey){
            keyString = keyString + "[ red key ] ";
        }
        if (playerScript.hasGreenKey){
            keyString = keyString + "[ green key ] ";
        }
        keysText.text = keyString;

        if (playerScript.atEnd){
            playerScript.speed = 0;
            playerScript.turnSpeed = 0;

            playerScript.atEnd = false;
            
            gameEndMenu.SetActive(true);
            finalScore.text = timeInt.ToString();
        }

    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
