using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_darkcloud : MonoBehaviour
{

    //health if wanted or state represented in boolean
    public int health = 10;
    public int speed = 5;
    public Rigidbody2D rb;
    public Collider2D bodycollide;
    //deatheffect for extra
    //public GameObject deathEffect;
    //public float speed;
    public bool moveRight;
    [HideInInspector]
    int moveTimer = 20;
    int i = 0;

    // Update is called once per frame
    void Update()
    {
        i = 0;
        if (!moveRight)
        {
            while (i < moveTimer)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                i++;
            }
            moveRight = true;
            //i = 0;
        }
        else
        {
            while(i < moveTimer)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                i++;
            }
            moveRight = false;
            //i = 0;
        }
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
