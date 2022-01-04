using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerStay(Collider other)
    {
        EnemyDMG enemy = other.GetComponent<EnemyDMG>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
