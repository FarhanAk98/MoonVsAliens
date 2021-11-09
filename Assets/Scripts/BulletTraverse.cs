using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTraverse : MonoBehaviour
{
    [HideInInspector]
    public Vector3 Vel;
    Rigidbody rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity=Vel;
        if(transform.position.x >= 40 || transform.position.x <= -40 || transform.position.y >= 20 || transform.position.y <= -20)
        {
            Destroy(transform.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Barrier"))
        {
            Destroy(transform.gameObject);
        }
        if (other.transform.tag.Equals("Enemy"))
        {
            if (other.GetComponent<Life>() != null)
            {
                other.GetComponent<Life>().Hit();
            }
            else if (other.GetComponent<Life4>() != null)
            {
                other.GetComponent<Life4>().Hit();
            }
            else if (other.GetComponent<LifeBoss>() != null)
            {
                other.GetComponent<LifeBoss>().Hit();
            }
            Destroy(transform.gameObject);
        }
    }
}
