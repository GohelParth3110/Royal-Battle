using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : Powerup
{
    [SerializeField][Range(0,100)] private float flt_IncresingPersantageOfFireRate;
    [SerializeField] private float flt_MaxTimeToPowerup;

    public override void Collect(GameObject player) {
        player.GetComponent<PlayerShooting>().IncresingFireRate(flt_IncresingPersantageOfFireRate, 
                        flt_MaxTimeToPowerup);
    }
}
