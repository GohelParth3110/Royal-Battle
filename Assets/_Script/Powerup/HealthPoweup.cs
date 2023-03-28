using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoweup : Powerup
{
   

    public override void Collect(GameObject player) {
        player.GetComponent<PlayerHealth>().SetMaxHealth();
    }
}
