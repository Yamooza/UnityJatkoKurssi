using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float force;
    public float radius;
    public float upModifier;
    public float timeToBlowUp;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", timeToBlowUp);
    }
    void explode()
    {
        Collider[] collidersHit = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in collidersHit)
        {
            hit.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius, upModifier);
        }
        Destroy(gameObject);
    }
}
