using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public float bulletVelocity = 30f;
    public float fireRate = 0.2f;

    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        StartCoroutine(FireDelay());
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * bulletVelocity);
    }

    IEnumerator FireDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
