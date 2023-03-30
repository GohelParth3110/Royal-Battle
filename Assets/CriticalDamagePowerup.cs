using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalDamagePowerup : Powerup
{
    [SerializeField] private GameObject obj_Destroy;
    public override void Collect(GameObject player) {
        player.GetComponent<PlayerShooting>().CollectedCriticalDamage();
    }
}
