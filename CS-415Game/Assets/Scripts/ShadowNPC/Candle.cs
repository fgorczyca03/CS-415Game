using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Candle : MonoBehaviour
{
    public float minTimeLit = 15.0f; // Minimum time the candle stays lit
    public float maxTimeLit = 30.0f; // Maximum time the candle stays lit
    public float interactionRange = 8.0f; // Range within which the player can interact

    private float timer;
    private bool isLit = false;
    private GameObject player;
    private Light candleLight;
    public int count = 1;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        candleLight = GetComponentInChildren<Light>();
        Light(); // Initializes the candles as lit

        if (candleLight == null)
        {
            Debug.LogError("No Light component found on candle.");
        }

        UpdateLight();
    }

    private void Update()
    {
        if (isLit)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Extinguish();
            }
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= interactionRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isLit)
            {
                Light();
            }
        }
    }

    private void Light()
    {
        isLit = true;
        timer = Random.Range(minTimeLit, maxTimeLit);
        UpdateLight();
        count--;
    }

    private void Extinguish()
    {
        isLit = false;
        UpdateLight();
        count++;
    }

    private void UpdateLight()
    {
        if (candleLight != null)
        {
            candleLight.enabled = isLit;
        }
    }

    public bool IsLit()
    {
        return isLit;
    }
}