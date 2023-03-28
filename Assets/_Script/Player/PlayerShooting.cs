using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float currentDamage;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform transform_BulletPostion;
    [SerializeField] private float flt_BulletFireRate;
    [SerializeField] private float flt_CurrentFireRate;
    [SerializeField] private float flt_CurrentTime;

    private void Start() {

        flt_CurrentFireRate = flt_BulletFireRate;
        currentDamage = damage;
    }

    private void Update() {

        FireBullet();
    }
    private void FireBullet() {
        flt_CurrentTime += Time.deltaTime;
        if (flt_CurrentTime > flt_CurrentFireRate) {
            flt_CurrentTime = 0;
            GameObject gameObject = Instantiate(bullet, transform_BulletPostion.position, transform_BulletPostion.rotation);
            gameObject.GetComponent<BulletMotion>().SetBulletData(-transform_BulletPostion.right, damage);
        }
    }

    public void IncresingFireRate(float flt_IncresingPersantageOfFireRate,float time) {

        float firerate = ((flt_IncresingPersantageOfFireRate / 100) * flt_BulletFireRate);
        Debug.Log(firerate);
        flt_CurrentFireRate -= firerate;
        if (flt_CurrentFireRate <0) {
            flt_CurrentFireRate = 0;
        }
        StartCoroutine(StopFireRatePowerUp(time));
    }

    private IEnumerator StopFireRatePowerUp(float time) {

        yield return new WaitForSeconds(time);
        flt_CurrentFireRate = flt_BulletFireRate;
    }
    public void IncresingDamage(float flt_IncreasingDamagePersantage, float flt_MaxTimeDamage) {

        float damage = ((flt_IncreasingDamagePersantage / 100) * this.damage);

        currentDamage += damage;
        StartCoroutine(StopDamagePowerUp(flt_MaxTimeDamage));
    }

    private IEnumerator StopDamagePowerUp(float flt_MaxTimeDamage) {
        yield return new WaitForSeconds(flt_MaxTimeDamage);
        currentDamage = damage;
    }
}
