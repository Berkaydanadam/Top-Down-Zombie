using UnityEngine.UI;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    public Transform originPoint;
    public GameObject projectile;

    public int damage = 10;
    public float fireRate = 15;
    public float ammo = 30;
    public float maxAmmo = 30;
    public float nextTimeToFire = 0f;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammo > 0) {
            Shoot();
            nextTimeToFire = Time.time + 1f / fireRate;
            ammo -= 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (ammo > maxAmmo) {
            ammo = maxAmmo;
        }
    }
    void Reload() {
        ammo = 30;
    }
    void Shoot() {
        GameObject bullet = Instantiate(projectile, 
            originPoint.transform.position, originPoint.rotation) as GameObject;
        if(bullet != null) {
            bullet.GetComponent<Rigidbody>().AddForce(-transform.forward * 10);
        }
    }
}
