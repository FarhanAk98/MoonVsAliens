using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject  Bullet, Flames, FlameHurt, Minion;
    public float speed;
    public Transform Spawn1, Spawn2;
    public List<Transform> Guns;
    public Animator anim;
    public LifeBoss Die;
    GameObject Player, f, f2;
    bool FiringGun = false, Fire = false, Ignited = false;
    int G = 0, FG = 0, index, FireTime = 700, EnemySpawn = 150;
    void Start()
    {
        Player = GameObject.Find("Moon");
        transform.position = new Vector3(40f, -1.5f, 20f);
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(40f, -1.5f, 20f);
        if (!Die.Dying && Player != null)
        {
            if (G > 150)
            {
                FiringGun = true;
                index = 2;
                G = 0;
            }
            if (FiringGun)
            {
                FireGun();
            }
            if (FireTime <= 0 && !Fire)
            {
                anim.SetBool("FireOn", true);
                Fire = true;
                FireTime = 2000;
            }
            if (Fire)
            {
                InGulf();
            }
            if (EnemySpawn <= 0)
            {
                int ch = Random.Range(0, 2);
                if (ch == 1)
                {
                    Instantiate(Minion, Spawn1.position, transform.rotation);
                }
                else
                {
                    Instantiate(Minion, Spawn2.position, transform.rotation);
                }
                EnemySpawn = 150;
            }
            EnemySpawn = (int)Mathf.Lerp(EnemySpawn, -1, 0.125f * Time.deltaTime); 
            FireTime = (int)Mathf.Lerp(FireTime, -1, 0.125f * Time.deltaTime);
            G++;
        }
    }
    void FireGun()
    {
        if (FG >= 25)
        {
            GameObject b = Instantiate(Bullet, Guns[index].position, transform.rotation);
            b.GetComponent<BossBulletTraverse>().Vel = (Player.transform.position - Guns[index].position).normalized * speed * Time.deltaTime;
            index--;
            FG = 0;
        }
        if (index < 0)
        {
            FiringGun = false;
        }
        FG++;
    }
    void InGulf()
    {
        if (FireTime <= 1500 && !Ignited)
        {
            f2 = Instantiate(FlameHurt, new Vector3(-16.6f, 0f, 20f), Quaternion.Euler(0f, 0f, 0f));
            f = Instantiate(Flames, new Vector3(-16.6f, -1.5f, 20f), Quaternion.Euler(-90f, 0f, 0f));
            Ignited = true;
        }
        if (FireTime <= 0)
        {
            anim.SetBool("FireOn", false);
            Fire = false;
            Ignited = false;
            FireTime = 800;
            Destroy(f);
            Destroy(f2);
        }
    }
}
