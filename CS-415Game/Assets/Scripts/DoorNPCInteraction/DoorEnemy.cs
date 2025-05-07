using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnemy : MonoBehaviour
{
    public GameObject enemy;
    public FollowPlayer follow;

    private void OnTriggerEnter(Collider other)
    {
        follow = enemy.GetComponent<FollowPlayer>();
        follow.enabled = true;
        Debug.Log("Box Trigger");
    }
}
