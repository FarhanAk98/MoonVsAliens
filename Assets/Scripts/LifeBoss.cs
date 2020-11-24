using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBoss : MonoBehaviour
{
    public GameObject Explode, Explode2;
    public Renderer rn;
    public int Health;
    int d = 0, Emit = 0;
    [HideInInspector]
    public bool Dying = false;
    void Update()
    {
        if (Dying)
        {
            Die();
            d++;
        }
        if (Emit > 0)
        {
            Emit--;
        }
        Material mat = rn.material;
        mat.SetColor("_EmissiveColor", new Color(1.0f, 1.0f, 1.0f) * Emit * 10f);
    }
    public void Hit()
    {
        Health--;
        Emit = 10;
        if (Health <= 0)
        {
            Dying = true;
        }
    }
    void Die()
    {
        if (d == 1)
        {
            Instantiate(Explode, new Vector3(transform.position.x - 4f, transform.position.y + 10f, transform.position.z - 4f), transform.rotation);
        }
        if (d == 50)
        {
            Instantiate(Explode, new Vector3(transform.position.x - 4f, transform.position.y, transform.position.z - 4f), transform.rotation);
        }
        if (d == 100)
        {
            Instantiate(Explode, new Vector3(transform.position.x - 4f, transform.position.y - 10f, transform.position.z - 4f), transform.rotation);
        }
        if (d >= 150)
        {
            Instantiate(Explode2, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z - 0.5f), transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
