using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_darkcloud : MonoBehaviour
{

    //health if wanted or state represented in boolean
    public int health = 10;
    //public int speed = 5;
    public Rigidbody2D rb;
    public Collider2D bodycollide;
    //deatheffect for extra
    //public GameObject deathEffect;
    //public float speed;
    public bool moveRight;
    [HideInInspector]
    
    int changedirect = 5;
    

    // Update is called once per frame
    void Update()
    {
     /*   if(!moveRight)
        {
            while (!moveRight)
            {
                if (Time.time % changedirect == 0)
                {
                    moveRight = true;
                }
                else
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        else
        {
            while(moveRight)
            {
                if(Time.time % changedirect == 0)
                    moveRight = false;
                else
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }*/   
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //enemy deatheffect, will create death effect and destroy enemy
        //Instantiate(deathEffect, transform.position, );
        Destroy(gameObject);
    }
}
