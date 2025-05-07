using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class DoorNPCSpawning : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public Sprite[] spriteArray;
    public bool npcSpawn = false;
    public GameObject enemy;
    public GameObject enemyCollider;
    public AudioSource backgroundMusic;

    public GameObject dialogCanvas;
    public TextMeshProUGUI dialogTmp;
    public string[] dialogText;
    public int chosenDialog;

    public GameObject completedCanvas;
    public TextMeshProUGUI completedTmp;
    public GameObject inventoryCanvas;

    InventoryManager inventory;
    string foundItem;
    string requestedItem;
    bool itemCheck = false;
    bool choice = false;

    AudioSource doorAudio;
    public AudioClip sound;
    bool audioPlayed = false;

    public float spawnTimer = 30; // Timer until NPC spawns at the door-- current time is for testing
    public float enemyTimer = 30;
    public float timer = 2F;
    int count = 0; // Counter until enemy spawns
    bool spawnCheck = false;

    void Start()
    {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        spriteRender.sprite = spriteArray[0];
        doorAudio = GetComponent<AudioSource>();
        inventory = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    void Update()
    {
        SpawnSprite();

        if(itemCheck == true)
        {
            CompleteTask();
        }

        if(npcSpawn == true)
        {
            ResponseTimer();
        }
    }

    private void ResponseTimer()
    {
        if(enemyTimer > 0)
        {
            enemyTimer -= Time.deltaTime;
        } else
        {
            EnemyAccepted();
        }
    }

    void PlaySound()
    {
        // Checks if NPC is spawned and sound has already been played
        if (!audioPlayed && npcSpawn == true)
        {
            doorAudio.Play();
            audioPlayed = true;
        }
    }

    public void SpawnSprite()
    {
        // Spawns the NPC at the door after the time is up
        if (spawnTimer > 0 && count <= 5)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            PlaySound();
            npcSpawn = true;
            LoadSprite();
            // Spawns sprite when key is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                Dialog();
            }
        }

        if(spawnTimer < 0 && spawnCheck == false)
        {
            count++;
            spawnCheck = true;
        }
    }

    public void DespawnSprite()
    {
        npcSpawn = false;
        audioPlayed = false;
        spriteRender.sprite = spriteArray[0];  // Unloads NPC
    }

    void LoadSprite()
    {
        // Spawns enemy NPC after certain amount of friendly spawns
        if (count == 3)
        {
            spriteRender.sprite = spriteArray[2];  // Spawns enemy
        } else
        {
            spriteRender.sprite = spriteArray[1];  // Spawns friendly
        }
    }
    
    void RespawnCountdown()
    {
        spawnTimer = 30;
        enemyTimer = 30;
        timer = 2;
        choice = false;
    }

    void Dialog()
    {
        chosenDialog = UnityEngine.Random.Range(0, 4);
        switch (chosenDialog)
        {
            case 0:
                {
                    requestedItem = "TOMATO SOUP";
                    break;
                }
            case 1:
                {
                    requestedItem = "MINISTRONE";
                    break;
                }
            case 2:
                {
                    requestedItem = "PEA STEW";
                    break;
                }
            case 3:
                {
                    requestedItem = "CEREAL";
                    break;
                }
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        dialogTmp.text = dialogText[chosenDialog];
        dialogCanvas.SetActive(true);
    }

    public void AcceptButton()
    {
        choice = true;
        dialogCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        if(count == 3)
        {
            EnemyAccepted();
        }
    }

    public void RejectButton()
    {
        choice = false;
        itemCheck = true;
        dialogCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(npcSpawn == true && choice == true)
        {
            for (int i = 0; i < 20; i++)
            {
                foundItem = inventory.itemSlot[i].itemName;
                if(requestedItem.Equals(foundItem))
                {
                    Debug.Log(foundItem);
                    itemCheck = true;
                }
            }
        }
    }

    private void CompleteTask()
    {
        if (choice == true)
        {
            completedCanvas.SetActive(true);
            completedTmp.text = "Thank you!";
            Debug.Log("Choice check");
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            completedCanvas.SetActive(false);
            itemCheck = false;
            DespawnSprite();
            RespawnCountdown();
        }
    }

    private void EnemyAccepted()
    {
        DespawnSprite();
        RespawnCountdown();
        enemy.SetActive(true);
        enemyCollider.SetActive(true);
        backgroundMusic.enabled = false;
    }
}