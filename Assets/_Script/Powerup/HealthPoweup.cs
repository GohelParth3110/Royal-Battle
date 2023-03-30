using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoweup : Powerup
{
    [SerializeField] private GameObject obj_HealthVfx;

    public override void Collect(GameObject player) {
        player.GetComponent<PlayerHealth>().SetMaxHealth();
        Instantiate(obj_HealthVfx, transform.position, transform.rotation);
    }
}
