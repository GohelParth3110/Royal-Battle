using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,ItakeDamage
{
    [SerializeField] private float flt_MaxHealth;
    [SerializeField] private float flt_CurrrentHealth;


    private void OnEnable() {
        flt_CurrrentHealth = flt_MaxHealth;
    }
    public void TakeDamage(float damage) {

        flt_CurrrentHealth -= damage;
        if (flt_CurrrentHealth <= 0) {
            Destroy(gameObject);
            PowerUpManager.instnce.SpawnPowerUp();
        }
    }
}
