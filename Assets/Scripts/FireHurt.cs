using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHurt : MonoBehaviour
{
    public int Damage;
    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            other.transform.GetComponent<Moon>().Hit(Damage);
        }
        if (other.transform.tag.Equals("Enemy"))
        {
            other.GetComponent<Life>().Die();
        }
    }
}
