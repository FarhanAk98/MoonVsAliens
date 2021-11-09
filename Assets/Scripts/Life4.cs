using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life4 : MonoBehaviour
{
    public Renderer rn;
    public GameObject Explode;
    public int Health;
    public int Phase=2;
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
            Split();
        }
    }
    void Split()
    {
        if (Phase <= 0)
        {
            Die();
        }
        else
        {
            GameObject b1 = Instantiate(gameObject, new Vector3(transform.position.x + 3f, transform.position.y, 20f), transform.rotation);
            GameObject b2 = Instantiate(gameObject, new Vector3(transform.position.x - 3f, transform.position.y, 20f), transform.rotation);
            b1.GetComponent<Life4>().Phase = Phase - 1;
            b2.GetComponent<Life4>().Phase = Phase - 1;
            b1.GetComponent<Life4>().Health = 4;
            b2.GetComponent<Life4>().Health = 4;
            b1.transform.localScale = transform.localScale * 0.75f;
            b2.transform.localScale = transform.localScale * 0.75f;
            Destroy(this.gameObject);
        }
    }
    void Die()
    {
        GameObject clone=Instantiate(Explode, transform.position, transform.rotation);
        Destroy(clone, 1.0f);
        Destroy(this.gameObject);
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().li++;
    }
}
