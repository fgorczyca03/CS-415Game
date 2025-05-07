using System.Collections;
using UnityEngine;

public class AllowEnter : MonoBehaviour
{
    public GameObject curtain;         // Assign in Inspector
    public BoxCollider boxCollider;    // Assigned in Start()
    public AudioSource churchBells;   // Assigned in Inspector
    public float soundTimer = 45f;    // Initial sound timer value
    public float enemyTimer = 30f;
    public bool audioPlayed = false;

    public TriggerEventCollision trigger;
    public GameObject boothCollider;

    void Start()
    {
        // Get the BoxCollider component from the curtain GameObject
        boxCollider = curtain.GetComponent<BoxCollider>();
        trigger = boothCollider.GetComponent<TriggerEventCollision>();

        // Check if boxCollider is found and assigned
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider component not found on curtain GameObject!");
        }
        else
        {
            // Enable the BoxCollider component
            boxCollider.enabled = true;
        }
    }

    void Update()
    {
        // Countdown the sound timer
        if (soundTimer > 0)
        {
            soundTimer -= Time.deltaTime;
        }
        else if (soundTimer <= 0)
        {
            // When timer reaches zero, play church bells
            PlaySound();
            // Disable the BoxCollider until the next interval
            boxCollider.enabled = false;
            ResponseTimer();
        }
    }
    private void ResponseTimer()
    {
        if (enemyTimer > 0)
        {
            enemyTimer -= Time.deltaTime;
        } else
        {
            trigger.SpawnEnemy();
        }
    }

    void PlaySound()
    {
        // Checks if NPC is spawned and sound has already been played
        if (!audioPlayed)
        {
            churchBells.Play();
            audioPlayed = true;
        }
    }
}
