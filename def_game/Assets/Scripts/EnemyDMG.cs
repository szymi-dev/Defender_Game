using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG : MonoBehaviour
{
    public float health;
    public event System.Action OnDeath;


    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
            ScoreManager.instance.UpdateScore();
        }
    }

    private void Update()
    {
        Debug.Log("Enemy HP " + health);
    }

    public void Die()
    {
        if(OnDeath != null)
        {
            OnDeath();
        }
        Destroy(gameObject);
    }
}
