using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemy : MonoBehaviour
{
    [SerializeField] private bool isEnemyCharged;
    [SerializeField] private float flt_ChargingTime;
    [SerializeField] private float flt_CurrentTime;
    private Vector3 dirction;
    [SerializeField]private float flt_speedOfEnemy;
    [SerializeField] private float flt_Boundry;
    [SerializeField] private Transform body;
 
    private void Start() {
        isEnemyCharged = true;
        FindTarget();
    }

    private void Update() {
        if (isEnemyCharged) {
            transform.Translate(new Vector3(dirction.x, 0, dirction.z) * flt_speedOfEnemy * Time.deltaTime);
            if (MathF.Abs(transform.position.x)>flt_Boundry || MathF.Abs(transform.position.z)>flt_Boundry) {
                isEnemyCharged = false;
            }
        }
        else {
            flt_CurrentTime += Time.deltaTime;
            if (flt_CurrentTime>flt_ChargingTime) {
                isEnemyCharged = true;
                flt_CurrentTime = 0;
                FindTarget();
            }
        }
    }

    private void FindTarget() {
        dirction = (PlayerManager.instance.Player.transform.position - transform.position).normalized;
        float targetAngle = Mathf.Atan2(dirction.z, -dirction.x) * Mathf.Rad2Deg;
        body.localEulerAngles = new Vector3(0, targetAngle, 0);
    }
} 
