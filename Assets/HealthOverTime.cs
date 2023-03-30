using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOverTime : Powerup {

    
    [SerializeField] private GameObject obj_DestroyVFX;
    public override void Collect(GameObject player) {

        player.GetComponent<PlayerHealth>().CollectHelathOverTime();
    }
}
