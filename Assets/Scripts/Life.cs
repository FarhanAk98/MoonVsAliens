using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Renderer rn;
    public GameObject Explode;
    public int Health;
    int Emit = 0;
    void FixedUpdate()
    {
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
            Die();
        }
    }
    public void Die()
    {
        GameObject clone = Instantiate(Explode, transform.position, transform.rotation);
        Destroy(clone, 1.0f);
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().li++;
        Destroy(this.gameObject);
    }
}
