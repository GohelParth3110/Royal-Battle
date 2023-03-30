using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    [SerializeField] private float flt_BulletSpeed;
    [SerializeField] private float damage;
    private Vector3 dirction;
    [SerializeField] private GameObject explotion;

    public void SetBulletData(Vector3 direction,float  damage) {
        this.damage = damage;
        this.dirction = direction;
    }
    private void Start() {
        Destroy(gameObject, 5);
    }
    private void Update() {
        BulletMovement();
    }

    private void BulletMovement() {
        transform.Translate(dirction * flt_BulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.TryGetComponent<ItakeDamage>(out ItakeDamage itakeDamage)) {
            itakeDamage.TakeDamage(damage);
            Destroy(gameObject);
            Instantiate(explotion, transform.position, transform.rotation);
        }
        if (collision.gameObject.TryGetComponent<ItakeKnockBack>(out ItakeKnockBack itakeKnock)) {
            Vector3 direction = (transform.position - collision.gameObject.transform.position).normalized;
            itakeKnock.KnockbackVFX(-direction);
        }
    }
}
