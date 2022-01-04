using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    private PlayerController _player;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float stoppingDistance;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float startTimeBtwAttack;

    private float timeBtwAttack;

    private void Start()
    {
        timeBtwAttack = startTimeBtwAttack;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        Vector3 LookDir = target.position - transform.position;
        Quaternion LookRotate = Quaternion.LookRotation(LookDir);
        transform.rotation = LookRotate;

        ChasePlayer();
    }


    void ChasePlayer()
    {
        if(Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, target.position) < stoppingDistance)
        {
            transform.position = this.transform.position;
            Attack();
        }
    }

    void Attack()
    {
        if(timeBtwAttack <= 0)
        {
            Debug.Log("Attacking");
            _player.ReduceHealth(damage);
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }

    
}
