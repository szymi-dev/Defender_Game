using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethower : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyDetector;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject FireEffect;
    [SerializeField]
    private float maxFlame;
    [SerializeField]
    private float flameDecrease;
    [SerializeField]
    private float flameIncrement;

    private float currentFlame;
    private bool detecting;

    public FlameBar flameBar;

    private void Start()
    {      
        currentFlame = maxFlame;
        flameBar.SetMaxFlame(maxFlame);
    }

    private void Update()
    {

        Detecting();

        

        if(Input.GetKey(KeyCode.Space) && currentFlame >= 0)
        {
            detecting = true;        
            currentFlame -= flameDecrease;
            flameBar.SetFlame(currentFlame);

        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            detecting = false;
        }

        if(currentFlame <= maxFlame && currentFlame >= -1)
        {
            currentFlame += flameIncrement;
            flameBar.SetFlame(currentFlame);
        }
        
        if(currentFlame < 2)
        {
            detecting = false;
        }

        Debug.Log(currentFlame);
    }

    void Detecting()
    {
        if(detecting)
        {
            EnemyDetector.SetActive(true);
            Instantiate(FireEffect, firePoint.position, firePoint.rotation);
        }
        else
        {
            EnemyDetector.SetActive(false);
        }
    } 
}
