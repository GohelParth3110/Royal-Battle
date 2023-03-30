using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyMotion : MonoBehaviour,ItakeKnockBack
{

    
    Transform target;

    [SerializeField]
    float initialAngle;
    Rigidbody rigid;

    [SerializeField] private float flt_RangeofSpeherCast;
    private string tag_Player = "Player";

     private bool isfindRayCast = true;
    [SerializeField] private float flt_Delay;
    [SerializeField]private float flt_knockBackForce;

    void Start() {
        rigid = GetComponent<Rigidbody>();

       
        // Alternative way:
        // rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
    }

    private void Update() {
        SphereCast();
    }

    private void Jump() {

        Vector3 p = target.position;

        float gravity = Physics.gravity.magnitude;
    // Selected angle in radians
    float angle = initialAngle * Mathf.Deg2Rad;

    // Positions of this object and the target on the same plane
    Vector3 planarTarget = new Vector3(p.x, 0, p.z);
    Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);
       
        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
    // Distance along the y axis between objects
    float yOffset = transform.position.y - p.y;

    float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / 
                                                (distance * Mathf.Tan(angle) + yOffset));

    Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

    // Rotate our velocity to match the direction between the two objects
    float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);
        if (planarTarget.x - planarPostion.x<0) {
            angleBetweenObjects = -angleBetweenObjects;
        }
       
        
     Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        // Fire!
        rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
        StartCoroutine(Dealy());
    }



   


  

    private void SphereCast() {
        if (!isfindRayCast) {
            return;
        }

        Collider[] all_Collider;
        all_Collider = Physics.OverlapSphere(transform.position, flt_RangeofSpeherCast);

        for (int i = 0; i < all_Collider.Length; i++) {
            if (all_Collider[i].CompareTag(tag_Player)) {

                Vector3 targetDirection = (all_Collider[i].transform.position - transform.position).normalized;
                isfindRayCast = false;
                target = all_Collider[i].transform;
                Jump();

            }
        }
    }

    private IEnumerator Dealy() {
        yield return new WaitForSeconds(2);
        isfindRayCast = true;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, flt_RangeofSpeherCast);
    }

    public void KnockbackVFX(Vector3 dirction) {
        rigid.AddForce(dirction * flt_knockBackForce, ForceMode.Impulse);
        StartCoroutine(SetHitBySomething());
    }

    private IEnumerator SetHitBySomething() {
        yield return new WaitForSeconds(0.2f);

        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }


}
