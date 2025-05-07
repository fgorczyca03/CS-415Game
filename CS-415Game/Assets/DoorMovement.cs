using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public GameObject doorNPC;
    public DoorNPCSpawning doorSpawn;
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        doorSpawn = doorNPC.GetComponent<DoorNPCSpawning>();
    }

    void Update()
    {
        if(doorSpawn.npcSpawn == true)
        {
            Open();
        } else
        {
            Close();
        }
    }

    private void Open()
    {
        anim.Play("DoorOpen");
    }

    private void Close()
    {
        anim.Play("DoorClose");
    }
}