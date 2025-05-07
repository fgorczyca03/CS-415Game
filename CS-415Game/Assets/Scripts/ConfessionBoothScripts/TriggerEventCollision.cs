using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;
public class TriggerEventCollision : MonoBehaviour
{
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public AllowEnter enter;
    public GameObject curtain;

    public string[] dialogText;
    public int chosenDialog;
    public TextMeshProUGUI textMeshProUGUI;
    public GameObject canvas;
    public Transform player;
    public Vector3 tpLocation;
    public GameObject confessionSprite;
    public GameObject doorObject;

    private void OnTriggerEnter(Collider other)
    {
        enter = curtain.GetComponent<AllowEnter>();
        enter.enemyTimer = 30;
        enter.soundTimer = 45;
        enter.audioPlayed = false;

        chosenDialog = UnityEngine.Random.Range(0, 6);
        playerMovement = other.GetComponentInParent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>(); // Get Rigidbody from the collider's GameObject
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            textMeshProUGUI.text = dialogText[chosenDialog];
            canvas.SetActive(true);
        }
    }

    public void ForgiveButton()
    {
        playerMovement.enabled = true;
        canvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(chosenDialog < 3)
        {
        }
        else{
            SpawnEnemy();
        }
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>(); // Get Rigidbody from the collider's GameObject
        // Disable physics briefly to avoid issues during teleportation
        playerRigidbody.isKinematic = true;

        // Teleport the player
        player.position = tpLocation;

        // Re-enable physics
        playerRigidbody.isKinematic = false;
    }
    public void RebukeButton()
    {
        playerMovement.enabled = true;
        canvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>(); // Get Rigidbody from the collider's GameObject
        // Disable physics briefly to avoid issues during teleportation
        playerRigidbody.isKinematic = true;

        // Teleport the player
        player.position = tpLocation;

        // Re-enable physics
        playerRigidbody.isKinematic = false;
    }
    public void SpawnEnemy()
    {
        if (confessionSprite == null)
        {
            Debug.LogError("confessionSprite GameObject reference is not assigned in the Inspector!");
            return;
        }
        confessionSprite.SetActive(true);
    }
}





