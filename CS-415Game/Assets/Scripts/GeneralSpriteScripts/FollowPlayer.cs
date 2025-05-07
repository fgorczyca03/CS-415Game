using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Reference to the target object's transform
    public float moveSpeed = 4f; // Movement speed of the following object

    private void Update()
    {
        // Check if the target object is still valid
        if (target != null)
        {
            // Calculate direction to the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Move towards the target
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the target object
        if (other.transform == target)
        {
            // Update the target object reference to keep tracking it
            target = other.transform;
        }
    }
}