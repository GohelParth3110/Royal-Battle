using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour,ItakeKnockBack
{
    [SerializeField] private float flt_SpeedOfEnemy;
    [SerializeField] private Transform body;
    [SerializeField] private float flt_SpeedOfHitTimeEnemy;
    [SerializeField] private bool isHitBySomething;

    private Rigidbody rb;
    private Vector3 dirction;

    private void Start() {

        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        EnemyMotion();
      
    }
   
    
    private void EnemyMotion() {

        if (isHitBySomething) {
            transform.Translate(new Vector3(dirction.x, 0, dirction.z) * flt_SpeedOfHitTimeEnemy * Time.deltaTime);
        }
        else {
             dirction = (PlayerManager.instance.Player.transform.position - transform.position).normalized;
            float targetAngle = Mathf.Atan2(dirction.z, -dirction.x) * Mathf.Rad2Deg;
            body.localEulerAngles = new Vector3(0, targetAngle, 0);
            transform.Translate(new Vector3(dirction.x, 0, dirction.z) * flt_SpeedOfEnemy * Time.deltaTime);

        }

    }

    public void KnockbackVFX(Vector3 dirction) {
        isHitBySomething = true;
        this.dirction = dirction;
        StartCoroutine(SetHitBySomething());
    }

    private IEnumerator SetHitBySomething() {
        yield return new WaitForSeconds(0.2f);
        isHitBySomething = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
