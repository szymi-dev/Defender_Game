using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        EnemyDMG enemy = other.GetComponent<EnemyDMG>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    private void Update()
    {
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);


    }

}
