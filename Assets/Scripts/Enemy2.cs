using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    GameObject Player;
    public Animator anim;
    Vector3 direction, Steady;
    public float speed;
    public int Damage;
    bool Attacking = false;
    int time = 0;
    void Start()
    {
        Player = GameObject.Find("Moon");
    }
    void FixedUpdate()
    {
        if (Player != null)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) <= 10)
            {
                Attacking = true;
            }
            if (!Attacking)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y, 20f), speed * Time.deltaTime);
                Steady = transform.position;
            }
            else
            {
                Attack();
            }
        }
    }
    void Attack()
    {
        anim.speed = 0;
        if (time <= 40)
        {
            transform.position = Steady;
            direction = (transform.position - Player.transform.position).normalized;
        }
        else
        {
            Steady = transform.position;
        }
        if (time >= 50)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - direction, 1.525f);
        }
        if (time >= 75)
        {
            Attacking = false;
            anim.speed = 1;
            time = 0;
        }
        time++;
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.transform.GetComponent<Moon>().Hit(Damage);
        }
    }
}
