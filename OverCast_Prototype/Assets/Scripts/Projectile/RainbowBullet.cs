using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 10;
    public GameObject impactEffect;
    public float bulletlifetime;

    //Layermask used to account for collision with ground layer and non other non "Enemy" objects
    //public LayerMask<Ground> ground;
    //bullet launches from shootPoint across screen from left to right
    private void Start()
    {
       Invoke("DestroyProjectile",bulletlifetime);
    }

    void Update()
    {

        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", bulletlifetime);

    }
    //script for bullet damage mechanic
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //print what bullet hit to screen
        //Debug.Log(hitInfo.name);
       Enemy enemy = hitInfo.GetComponent<Enemy>();
       Enemy2_darkcloud enemy2 = hitInfo.GetComponent<Enemy2_darkcloud>();
       Boss_1 bs1 = hitInfo.GetComponent<Boss_1>();
       //checks if hits enemy, then deals damage
       if(enemy != null)
        {
            //if collide with enemy or ground
            if (hitInfo.gameObject.CompareTag("Ground") || hitInfo.gameObject.CompareTag("Enemy"))
                DestroyProjectile();
            enemy.TakeDamage(damage);
            //DestroyProjectile();
        } 
       else if(enemy2 != null)
        {
            //if collide with enemy or ground
            if (hitInfo.gameObject.CompareTag("Ground") || hitInfo.gameObject.CompareTag("Enemy"))
                DestroyProjectile();
            enemy2.TakeDamage(damage);
            //DestroyProjectile();
        }
       else if(bs1 != null)
        {
            //if collide with enemy or ground
            if (hitInfo.gameObject.CompareTag("Ground") || hitInfo.gameObject.CompareTag("Enemy"))
                DestroyProjectile();
            bs1.TakeDamage(damage);
        }

       //if collide with enemy or ground
        if (hitInfo.gameObject.CompareTag("Ground") || hitInfo.gameObject.CompareTag("Enemy"))
            DestroyProjectile();

       
    }

    void DestroyProjectile()
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
