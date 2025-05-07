using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSpawning : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public Sprite[] spriteArray;
    public GameObject candleAccess;

    FollowPlayer followScript;
    LookAtPlayer cameraScript;
    CandleTracking spawnCondition;
    Death playerDeath;
    AudioSource audio;

    Vector3 startPos;
    public bool triggerCheck = false;

    void Start()
    {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        followScript = gameObject.GetComponent<FollowPlayer>();
        cameraScript = gameObject.GetComponent<LookAtPlayer>();
        spawnCondition = candleAccess.GetComponent<CandleTracking>();
        playerDeath = gameObject.GetComponent<Death>();
        audio = gameObject.GetComponent<AudioSource>();

        // Disables the scripts until spawned in
        followScript.enabled = false;
        cameraScript.enabled = false;
        playerDeath.enabled = false;
        audio.enabled = false;
        spriteRender.sprite = spriteArray[0]; // Hides npc
        startPos = gameObject.transform.position; // Initializes starting position
    }

    void Update()
    {
        SpawnSprite();
        DespawnSprite();
    }

    void SpawnSprite()
    {
        if(spawnCondition.spawn == true)
        {
            // Spawns npc
            spriteRender.sprite = spriteArray[1];
            playerDeath.enabled = true;
            followScript.enabled = true;
            cameraScript.enabled = true;
            audio.enabled = true;
        }
    }

    void DespawnSprite()
    {
        if(spawnCondition.spawn == false)
        {
            // Resets npc
            spriteRender.sprite = spriteArray[0];
            gameObject.transform.position = startPos;
            playerDeath.enabled = false;
            followScript.enabled = false;
            cameraScript.enabled = false;
            audio.enabled = false;
        }
    }
}
