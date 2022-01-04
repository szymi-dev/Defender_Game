using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float maxPower;
    [SerializeField]
    private float powerDecrease;
    [SerializeField]
    private float powerIncrement;

    private float currentPower;
    private bool isLaser;

    public PowerBar powerBar;
    

    private void Start()
    {
        currentPower = maxPower;
        powerBar.SetMaxPower(maxPower);
    }

    private void Update()
    {
        LaserActivation();


        if(Input.GetKey(KeyCode.Space) && currentPower >= 0)
        {
            isLaser = true;
            currentPower -= powerDecrease;
            powerBar.SetPower(currentPower);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            isLaser = false;
        }
        if(currentPower <= maxPower && currentPower >= -2)
        {
            currentPower += powerIncrement;
            powerBar.SetPower(currentPower);
        }
        if(currentPower < 1)
        {
            isLaser = false;
        }      
    }

    void LaserActivation()
    {
        if(isLaser)
        {
            laser.SetActive(true);
        }
        else
        {
            laser.SetActive(false);
        }
    }

    
    
}
