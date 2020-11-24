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
    bool FiringGun = false, Fire = false;
    int G = 0, FG = 0, index, FireTime = 0, EnemySpawn = 0;
    void Start()
    {
        Player = GameObject.Find("Moon");
        transform.position = new Vector3(40f, -1.5f, 20f);
    }
    void Update()
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
            if (FireTime >= 700 && !Fire)
            {
                anim.SetBool("FireOn", true);
                Fire = true;
                FireTime = 0;
            }
            if (Fire)
            {
                InGulf();
            }
            if (EnemySpawn >= 150)
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
                EnemySpawn = 0;
            }
            EnemySpawn++;
            FireTime++;
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
        if (FireTime == 100)
        {
            f2 = Instantiate(FlameHurt, new Vector3(-16.6f, 0f, 20f), Quaternion.Euler(0f, 0f, 0f));
            f = Instantiate(Flames, new Vector3(-16.6f, -1.5f, 20f), Quaternion.Euler(-90f, 0f, 0f));
        }
        if (FireTime >= 1000)
        {
            anim.SetBool("FireOn", false);
            Fire = false;
            FireTime = 0;
            Destroy(f);
            Destroy(f2);
        }
    }
}
