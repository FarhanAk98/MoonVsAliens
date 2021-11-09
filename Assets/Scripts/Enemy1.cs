using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    GameObject Player;
    public float speed;
    public int Damage;
    void Start()
    {
        Player = GameObject.Find("Moon");
    }
    void FixedUpdate()
    {
        if (Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y, 20f), speed * Time.deltaTime);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.transform.GetComponent<Moon>().Hit(Damage);
        }
    }
}
