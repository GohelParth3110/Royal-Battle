using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : MonoBehaviour,ItakeKnockBack
{
    [SerializeField] private bool isEnemyCharged;
    [SerializeField] private float flt_ChargingTime;
    [SerializeField] private float flt_CurrentTime;
    private Vector3 targetDirection;
    [SerializeField]private float flt_speedOfEnemy;
    [SerializeField] private float flt_Boundry;
    [SerializeField] private Transform body;
    [SerializeField] private GameObject obj_ChargingVFX;
    [SerializeField] private Rigidbody rb;
    [SerializeField]private float flt_KnockBackForce;

    private void Start() {
        isEnemyCharged = true;
        FindTarget();
    }

    private void Update() {
        if (!GameManager.instance.isPlayerLive) {
            return;
         }
        if (isEnemyCharged) {
                transform.Translate(new Vector3(targetDirection.x, 0, targetDirection.z) * flt_speedOfEnemy * Time.deltaTime);

                CheckTouchBoundry();

        }
        else {

             flt_CurrentTime += Time.deltaTime;
            if (flt_CurrentTime > flt_ChargingTime) {
                    isEnemyCharged = true;
                    obj_ChargingVFX.gameObject.SetActive(false);
                    flt_CurrentTime = 0;
                    FindTarget();
            }
        }
        
        
    }

    private void CheckTouchBoundry() {
       
        if (transform.position.x<LevelManager.instance.flt_BoundryX) {
            isEnemyCharged = false;
            transform.position = new Vector3(LevelManager.instance.flt_BoundryX, transform.position.y, 
                    transform.position.z);
            obj_ChargingVFX.gameObject.SetActive(true);
            return;
        }
        else if (transform.position.z < LevelManager.instance.flt_BoundryZ) {
            isEnemyCharged = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 
                                                LevelManager.instance.flt_BoundryZ);
            obj_ChargingVFX.gameObject.SetActive(true);
            return;
        }
        else if (transform.position.x > LevelManager.instance.flt_Boundry) {
            isEnemyCharged = false;
            transform.position = new Vector3(LevelManager.instance.flt_Boundry, transform.position.y,
                   transform.position.z);
            obj_ChargingVFX.gameObject.SetActive(true);
            return;
        }
        else if (transform.position.z > LevelManager.instance.flt_Boundry) {
            isEnemyCharged = false;
            transform.position = new Vector3(transform.position.x, transform.position.y,
                                              LevelManager.instance.flt_Boundry);
            obj_ChargingVFX.gameObject.SetActive(true);
            return;
        }else {
            return;
        }
    }

    private void FindTarget() {
        if (PlayerManager.instance.Player== null) {
            return;
        }
        targetDirection = (PlayerManager.instance.Player.transform.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(targetDirection.z, -targetDirection.x) * Mathf.Rad2Deg;
        body.localEulerAngles = new Vector3(0, targetAngle, 0);
    }
    public void KnockbackVFX(Vector3 dirction) {
        rb.AddForce(dirction * flt_KnockBackForce, ForceMode.Impulse);
        StartCoroutine(SetHitBySomething());
    }

    private IEnumerator SetHitBySomething() {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
} 
