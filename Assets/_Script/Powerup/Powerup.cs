using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
        // tag 

    private string tag_Player = "Player";
    public abstract void Collect(GameObject player); // Abstract method to be implemented by each power-up

    public void OnCollisionEnter(Collision collision) {
       
        if (collision.gameObject.CompareTag(tag_Player)) {
            Collect(collision.gameObject); // Call the Collect method for the specific power-up
            Destroy(gameObject); // Destroy the power-up game object
        }
    }

}
