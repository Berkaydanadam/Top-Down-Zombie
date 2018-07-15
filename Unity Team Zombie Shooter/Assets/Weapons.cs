using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public GameObject originPoint;
    public GameObject projectile;

    public float damage;
    public float impactForce;
    public float fireRate;
    public float ammo;
    public float maxAmmo;
    public float nextTimeToFire;

    private void Start() {
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammo > 0) {
            Shoot();
            nextTimeToFire = Time.time + 1f / fireRate;
            ammo -= 1;
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
        if (ammo > maxAmmo) {
            ammo = maxAmmo;
        }
    }
    void Reload() {
        ammo = maxAmmo;
    }
    void Shoot() {
        GameObject bullet = Instantiate(projectile, originPoint.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * 1000);
    }
}
