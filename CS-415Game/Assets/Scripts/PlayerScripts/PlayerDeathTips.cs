using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDeathTips : MonoBehaviour
{
    public string[] spriteTips;
    public static string chosenTip;

    private void OnTriggerEnter(Collider other)
    {
        // Checks for which sprite killed the player
        if (other.CompareTag("NPC_shadow"))
        {
            Debug.Log("shadow");
            chosenTip = spriteTips[0];
        }
        else if (other.CompareTag("NPC_door"))
        {
            chosenTip = spriteTips[1];
            Debug.Log("door npc");
        }
        else if (other.CompareTag("NPC_confession"))
        {
            Debug.Log("confession npc");
            chosenTip = spriteTips[2];
        }
    }
}