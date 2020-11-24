using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moon : MonoBehaviour
{
    public AudioSource audio;
    public TMP_Text text;
    public Animator anim;
    public GameObject bullet, Explode;
    public Renderer rn;
    public Transform ShootingPoint1, ShootingPoint2;
    public float speed;
    public int Health;
    Vector3 SteadyPosition, ShPoint;
    int Reloading = 0, Sh = 1, Heal=0;
    Rigidbody rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        ShPoint = ShootingPoint1.position;
        anim.SetBool("Open", true);
        SteadyPosition = new Vector3(0f, 0f, 20f);
        transform.position = new Vector3(0f, 0f, 20f);
    }
    void FixedUpdate()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Input.GetMouseButton(0) && Reloading <= 0 && anim.GetBool("Open"))
        {
            Fire();
            Reloading = 10;
            Sh = -Sh;
        }
        Move();
        if (Reloading >= 0)
        {
            Reloading--;
        }
        if (Heal >= 0)
        {
            Heal--;
        }
        text.text = "Health: " + Health.ToString();
        Material mat = rn.material;
        mat.SetColor("_EmissiveColor", new Color(1.0f, 0.0f, 0.0f) * Heal * 100f);
    }
    void Move()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(hor*speed, ver*speed, 0f)*Time.deltaTime;
        if(hor==0 && ver == 0)
        {
            transform.position = new Vector3(SteadyPosition.x, SteadyPosition.y, 20f);
        }
        else
        {
            SteadyPosition = transform.position;
        }
    }
    void Fire()
    {
        audio.Play();
        if (Sh == 1)
        {
            ShPoint = ShootingPoint1.position;
        }
        else if (Sh == -1)
        {
            ShPoint = ShootingPoint2.position;
        }
        GameObject b = Instantiate(bullet, ShPoint, transform.rotation);
        b.GetComponent<BulletTraverse>().Vel = b.transform.right * 10000 * Time.deltaTime;
    }
    public void Hit(int Damage)
    {
        if (Heal <= 0)
        {
            Health -= Damage;
            if (Health <= 0)
            {
                Die();
            }
            Heal = 50;
        }
    }
    void Die()
    {
        Instantiate(Explode, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
