using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MachineGun : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    private GameObject fireEffect;
    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private float startTimeBtwShoot;
    [SerializeField]
    private float force;
    [SerializeField]
    private int magazineSize;
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private GameObject reloadText;
    


    private int currentAmmo;
    private bool isReloading = false;
    private float timeBtwShoot;

    private void Start()
    {
        ammoText.text = currentAmmo.ToString() + " / " + magazineSize;   
        timeBtwShoot = startTimeBtwShoot;
        currentAmmo = maxAmmo;
        reloadText.SetActive(false);
    }

    private void OnEnable()
    {
        reloadText.SetActive(false);
        isReloading = false;
    }

    private void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            Debug.Log("reloading");
            return;
        }

        if(currentAmmo == 0 && magazineSize == 0)
        {
            return;
        }

        if(Input.GetKey(KeyCode.Space) && timeBtwShoot <= 0)
        {
            Instantiate(fireEffect, firePoint.position, Quaternion.identity);
            Shoot();
            Debug.Log(currentAmmo);
            timeBtwShoot = startTimeBtwShoot;
        }
        else
        {
            timeBtwShoot -= Time.deltaTime;
        }

        ammoText.text = currentAmmo.ToString() + " / " + magazineSize;
    }

    void Shoot()
    {
        currentAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.up * force, ForceMode.Impulse);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadText.SetActive(true);
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
        reloadText.SetActive(false);
        if(magazineSize >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
    }
}
