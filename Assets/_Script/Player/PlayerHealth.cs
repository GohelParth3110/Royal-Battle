using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,ItakeDamage
{
    [SerializeField] private float flt_MaxHealth;
    [SerializeField] private float flt_CurrrentHealth;

    [Header("HealthOverTime")]
    [SerializeField] private GameObject obj_HealthOverTime;
    [SerializeField]private bool isHeathOverTimeCollected;
    [SerializeField]private float flt_MaxTimeToHealthOverTime;
    [SerializeField] private float flt_CurrentTimeToHealthOverTime;
    [SerializeField]private float flt_CurrentTime;
    [SerializeField]private float flt_IncreasingHealthTime;
    [SerializeField]private float flt_IncresedHealth;

    private void OnEnable() {
        flt_CurrrentHealth = flt_MaxHealth;
        UIManager.instance.screen_UIGamePlayScreen.slider_Health.maxValue = flt_MaxHealth;
        UIManager.instance.screen_UIGamePlayScreen.slider_Health.value = flt_CurrrentHealth;

       
    }


    private void Update() {
        HandlingHealthOverTime();
    }

    public void TakeDamage(float damage) {

       
        flt_CurrrentHealth -= damage;
        UIManager.instance.screen_UIGamePlayScreen.slider_Health.value = flt_CurrrentHealth;
        if (flt_CurrrentHealth <= 0) {
           
            Destroy(gameObject);
            GameManager.instance.isPlayerLive = false;
            UIManager.instance.screen_UIGamePlayScreen.gameObject.SetActive(false);
            UIManager.instance.screen_UIGameOverScreen.gameObject.SetActive(true);
            
        }
    }

   
    public void SetMaxHealth() {
        StartCoroutine(SetMaxValue(flt_CurrrentHealth));
        flt_CurrrentHealth = flt_MaxHealth;
    }

    private IEnumerator SetMaxValue(float fltCurrentHelath) {

        float currentValue = flt_CurrrentHealth;
        float storeValue = currentValue;
        float elapsedTime = 0.0f;
        float flt_MaxTime = 2;

        while (elapsedTime < flt_MaxTime) {
            currentValue = Mathf.Lerp(storeValue, flt_MaxHealth, (elapsedTime / flt_MaxTime));
          
            elapsedTime += Time.deltaTime;
            UIManager.instance.screen_UIGamePlayScreen.slider_Health.value = currentValue;
            yield return null;
        }

        UIManager.instance.screen_UIGamePlayScreen.slider_Health.value = flt_CurrrentHealth;
    }

    public  void CollectHelathOverTime() {
        isHeathOverTimeCollected = true;
        flt_MaxTimeToHealthOverTime = 5f;
        flt_CurrentTimeToHealthOverTime = 0;
        obj_HealthOverTime.gameObject.SetActive(true);
    }

    private void HandlingHealthOverTime() {
        if (!isHeathOverTimeCollected) {
            return;
        }
        flt_CurrentTimeToHealthOverTime += Time.deltaTime;
        flt_CurrentTime += Time.deltaTime;
            
        if (flt_CurrentTime>flt_IncreasingHealthTime) {
            flt_CurrentTime = 0;
            flt_CurrrentHealth += flt_IncresedHealth;
            if (flt_CurrrentHealth>100) {
                flt_CurrrentHealth = 100;
                isHeathOverTimeCollected = false;
            }
            UIManager.instance.screen_UIGamePlayScreen.slider_Health.value = flt_CurrrentHealth;
        }
        if (flt_CurrentTimeToHealthOverTime>flt_MaxTimeToHealthOverTime) {
            isHeathOverTimeCollected = false;
            obj_HealthOverTime.gameObject.SetActive(false);
        }

    }
}
