using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]private int damage;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform transform_BulletPostion;
    [SerializeField] private float flt_BulletFireRate;
    [SerializeField] private float flt_CurrentTime;

    

    private void Update() {

        FireBullet();
    }

    private void FireBullet() {
        flt_CurrentTime += Time.deltaTime;
        if (flt_CurrentTime>flt_BulletFireRate) {
            flt_CurrentTime = 0;
            GameObject gameObject =    Instantiate(bullet, transform_BulletPostion.position, transform_BulletPostion.rotation);
            gameObject.GetComponent<BulletMotion>().SetBulletData(transform_BulletPostion.right, damage);
           
        }
    }
  
}
