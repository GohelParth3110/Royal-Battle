using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantEnemy : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.TryGetComponent<ItakeDamage>(out ItakeDamage itakeDamage)) {
            itakeDamage.TakeDamage(damage);
        }
        if (collision.gameObject.TryGetComponent<ItakeKnockBack>(out ItakeKnockBack itakeKnockBack)) {
            Vector3 dirction = (collision.transform.position - transform.position).normalized;
            itakeKnockBack.KnockbackVFX(dirction);
        }
    }
}
