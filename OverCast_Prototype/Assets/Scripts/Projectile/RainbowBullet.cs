using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int damage = 10;
    public GameObject impactEffect;
    public double bulletTraveltime = 0.0;

    //Layermask used to account for collision with ground layer and non other non "Enemy" objects
    //public LayerMask<Ground> ground;
    //bullet launches from shootPoint across screen from left to right
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    void Update()
    {

        if (bulletTraveltime > 5.0)
            Destroy(gameObject);
        else
            //rb.velocity = transform.right * speed;
            bulletTraveltime+=0.1;

    }
    //script for bullet damage mechanic
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //print what bullet hit to screen
        //Debug.Log(hitInfo.name);
       Enemy enemy = hitInfo.GetComponent<Enemy>();
       if(enemy != null)
        {
            enemy.TakeDamage(damage);
        } 

       //fix this
        Instantiate(impactEffect, transform.position, transform.rotation);
        
        Destroy(impactEffect);

        if (hitInfo.gameObject.CompareTag("Ground"))
            Destroy(gameObject);

       Destroy(gameObject);
    }
    
}