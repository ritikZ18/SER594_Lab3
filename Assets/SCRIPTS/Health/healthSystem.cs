using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using Unity.VisualScripting;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class healthSystem : MonoBehaviour
{
    public int maxHealth = 4;
    public int playerHealth;

    public playerMovementRevised move;

    public bool deadFlag = false;
    

    // Start is called before the first frame update
    void Start()
    {
        move = FindObjectOfType<playerMovementRevised>();

        playerHealth = maxHealth;
    }

    public void takeDamage(int harm)
    {
        playerHealth -= harm;

        if (playerHealth <= 0)
        {
            deadFlag = true;
            move.enabled = false;
            playerHealth = 0;
        }

    }

    public void heal(int heal)
    {
        playerHealth += heal;

        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }
    }
}
