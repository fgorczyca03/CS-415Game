using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleTracking : MonoBehaviour
{
    public Candle candleInfo;
    private GameObject mainCandle;
    private GameObject hallwayCandle;
    private GameObject bedroomCandle;
    private GameObject kitchenCandle;

    public int total = 0;
    public int[] status;
    public bool spawn = false;

    void Start()
    {
        // Declares the game objects
        mainCandle = GameObject.Find("MainRoomCandle");
        hallwayCandle = GameObject.Find("HallwayCandle");
        bedroomCandle = GameObject.Find("BedroomCandle");
        kitchenCandle = GameObject.Find("KitchenCandle");
    }

    void Update()
    {
        CandleStatus();
        SpawnTracking();
    }

    void CandleStatus()
    {
        // Tracks each candle's value
        status[0] = mainCandle.GetComponent<Candle>().count;
        status[1] = hallwayCandle.GetComponent<Candle>().count;
        status[2] = bedroomCandle.GetComponent<Candle>().count;
        status[3] = kitchenCandle.GetComponent<Candle>().count;

        // Tracks the amount of candles extinguished
        total = status[0] + status[1] + status[2] + status[3];
    }

    void SpawnTracking()
    {
        // Spawns enemy if all candles are out and despawns if all candles are on
        if(total == 4)
        {
            spawn = true;
        }
        if(total == 0)
        {
            spawn = false;
        }
    }
}
