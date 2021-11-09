using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletTraverse : MonoBehaviour
{
    public int Damage;
    [HideInInspector]
    public Vector3 Vel;
    Rigidbody rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = Vel;
        if (transform.position.x >= 40 || transform.position.x <= -40 || transform.position.y >= 20 || transform.position.y <= -20)
        {
            Destroy(transform.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Barrier"))
        {
            Destroy(transform.gameObject);
        }
        if (other.transform.tag.Equals("Player"))
        {
            other.GetComponent<Moon>().Hit(Damage);
            Destroy(transform.gameObject);
        }
    }
}
