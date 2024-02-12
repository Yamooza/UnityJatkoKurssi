using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShootMissile : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePoint;
    public float Power;
    bool Shoot;
    public float shootSpeed;
    public float nextFire;
    public float fireRate;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject b = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            b.GetComponent<Rigidbody>().AddForce(FirePoint.forward * Power, ForceMode.Impulse);

        }

    }

}