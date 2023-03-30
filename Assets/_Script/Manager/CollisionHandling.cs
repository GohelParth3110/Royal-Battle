using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandling : MonoBehaviour
{
    [SerializeField] private int damage;
    private Rigidbody rb;
    

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.TryGetComponent<ItakeDamage>(out ItakeDamage itakeDamage)) {
            itakeDamage.TakeDamage(damage);
          
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (collision.gameObject.TryGetComponent<ItakeKnockBack>(out ItakeKnockBack itakeKnock)) {
            Vector3 direction = (transform.position - collision.gameObject.transform.position).normalized;
            itakeKnock.KnockbackVFX(-direction);
        }
    }
}
