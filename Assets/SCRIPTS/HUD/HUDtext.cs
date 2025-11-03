using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDtext : MonoBehaviour
{
    public int xCoord;
    public int zCoord;
    public int yDeg;

    public GameObject player;
    public GameObject coordinates;
    public GameObject rotation;
    public GameObject deathMsg;
    public GameObject retryPrompt;
    public GameObject lifeBar;


    public healthSystem healthSys;


    public TMP_Text coordText;
    public TMP_Text rotDeg;
    public TMP_Text deadText;
    public TMP_Text retryText;
    public TMP_Text numberofLives;

    // Start is called before the first frame update
    void Start()
    {
        healthSys = FindObjectOfType<healthSystem>();
        player = GameObject.Find("player");

        coordinates = GameObject.Find("Coord_text");
        coordText = coordinates.GetComponent<TMP_Text>();

        rotation = GameObject.Find("rotation_text");
        rotDeg = rotation.GetComponent<TMP_Text>();
        
        deathMsg = GameObject.Find("deathMsg");
        deadText = deathMsg.GetComponentInChildren<TMP_Text>();
        
        retryPrompt = GameObject.Find("InputPrompt");
        retryText = retryPrompt.GetComponentInChildren<TMP_Text>();

        lifeBar = GameObject.Find("healthDisplay");
        numberofLives = lifeBar.GetComponentInChildren<TMP_Text>();

        coordText.text = " X / Z ";

        deathMsg.SetActive(false);
        retryPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xCoord = (int) player.transform.position.x;
        zCoord = (int) player.transform.position.z;

        yDeg = (int) player.transform.rotation.eulerAngles.y;

        coordText.text = "Location : " + xCoord.ToString() + " / " + zCoord.ToString();
        rotDeg.text = "Y deg    : " + yDeg.ToString();
        numberofLives.text = "Lives   : " + healthSys.playerHealth.ToString() + " / " +healthSys.maxHealth;

        if (healthSys.deadFlag == true)
        {
            deathMsg.SetActive(true);
            deadText.text = " You are Dead !!!!!!";

            retryPrompt.SetActive(true);
            retryText.text = " Press < ENTER> To retry";

            if (Input.GetKeyDown(KeyCode.Return))
            {
                resetLevel();
            }
        }
    }

    void resetLevel()
    {
        SceneManager.LoadScene("Lab2");
    }
}
