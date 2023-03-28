using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : Powerup
{
    [SerializeField] private float flt_IncreasingDamagePersantage;
    [SerializeField] private float flt_MaxTimeDamage;
    public override void Collect(GameObject player) {
        player.GetComponent<PlayerShooting>().IncresingDamage(flt_IncreasingDamagePersantage,flt_MaxTimeDamage);
    }
}
