using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : Powerup
{
    [SerializeField][Range(0,100)] private float flt_IncresingPersantageOfFireRate;
    [SerializeField] private float flt_MaxTimeToPowerup;
    [SerializeField] private GameObject obj_FireRateVfx;

    public override void Collect(GameObject player) {
        player.GetComponent<PlayerShooting>().IncresingFireRate(flt_IncresingPersantageOfFireRate, 
                        flt_MaxTimeToPowerup);
        Instantiate(obj_FireRateVfx, transform.position, transform.rotation);
    }
}
