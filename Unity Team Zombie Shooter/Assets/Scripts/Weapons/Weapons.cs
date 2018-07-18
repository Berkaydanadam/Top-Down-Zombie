using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public Transform originPoint;

    public int damage;
    public float fireRate;
    public int ammo;
    public int maxAmmo;

    float nextTimeToFire;

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
        GameObject bullet = Instantiate(GameObject.FindGameObjectWithTag("Bullet") 
            , originPoint.transform.position, originPoint.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * 10);
        bullet.GetComponent<BulletScript>().damage = damage;
    }
}
