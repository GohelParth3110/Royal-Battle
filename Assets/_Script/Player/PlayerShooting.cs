using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float currentDamage;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletMuzzle;
    [SerializeField] private Transform transform_BulletPostion;
    [SerializeField] private float flt_BulletFireRate;
    [SerializeField] private float flt_CurrentFireRate;
    [SerializeField] private float flt_CurrentTime;
    [SerializeField] private GameObject obj_FirerateVfx;
    [SerializeField] private GameObject obj_DamageVFx;
    private bool iscriticalDamage;
    [SerializeField] private float flt_CriticalDamageTime;
    [SerializeField]private float flt_ProbabiltyOfCriticalDamge;
    [SerializeField] private GameObject obj_CrticalDamage;

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
            if (iscriticalDamage) {
                int index = Random.Range(0, 100);
                if (index < flt_ProbabiltyOfCriticalDamge) {
                    gameObject.GetComponent<BulletMotion>().SetBulletData(-transform_BulletPostion.right, 2 * damage);
                }
                else {
                    gameObject.GetComponent<BulletMotion>().SetBulletData(-transform_BulletPostion.right, damage);
                }
                
            }
            else {
                gameObject.GetComponent<BulletMotion>().SetBulletData(-transform_BulletPostion.right, damage);
            }
            Instantiate(bulletMuzzle, transform_BulletPostion.position, bulletMuzzle.transform.rotation);
        }
    }

    public void IncresingFireRate(float flt_IncresingPersantageOfFireRate,float time) {

        obj_FirerateVfx.gameObject.SetActive(true);
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
        obj_FirerateVfx.SetActive(false);
    }
    public void IncresingDamage(float flt_IncreasingDamagePersantage, float flt_MaxTimeDamage) {

        obj_DamageVFx.gameObject.SetActive(true);
        float damage = ((flt_IncreasingDamagePersantage / 100) * this.damage);

        currentDamage += damage;
        StartCoroutine(StopDamagePowerUp(flt_MaxTimeDamage));
    }

    private IEnumerator StopDamagePowerUp(float flt_MaxTimeDamage) {
        yield return new WaitForSeconds(flt_MaxTimeDamage);
        currentDamage = damage;
        obj_DamageVFx.SetActive(false);
    }

    public void CollectedCriticalDamage() {
        iscriticalDamage = true;
        obj_CrticalDamage.gameObject.SetActive(true);
        StartCoroutine(StopCriticalDamage());
    }

    private IEnumerator StopCriticalDamage() {
        yield return new WaitForSeconds(flt_CriticalDamageTime);
        iscriticalDamage = true;
        obj_CrticalDamage.gameObject.SetActive(false);
    }
}
