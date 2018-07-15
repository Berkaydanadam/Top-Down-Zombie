using UnityEngine.UI;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    public GameObject originPoint;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15;
    public float ammo = 30;
    public float maxAmmo = 30;
    public float nextTimeToFire = 0f;

    //public Text ammotext;

    private void Start()
    {
    }

    void Update()
    {
        //ammotext.text = ammo.ToString();
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
    void Shoot()
    {

        RaycastHit hit;
        if (Physics.Raycast(originPoint.transform.position, -transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Vector3 forward = -transform.forward * 10;
            Debug.DrawRay(originPoint.transform.position, forward, Color.blue, 0f);
            if(hit.transform.gameObject.tag == "Zombie") {
                //Not good to access everytime!
                zombieScript zombie = hit.transform.gameObject.GetComponent<zombieScript>();
                zombie.health -= damage;
            }
            /*
            Kinda buggy need fix!
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            */
        }
    }
}
