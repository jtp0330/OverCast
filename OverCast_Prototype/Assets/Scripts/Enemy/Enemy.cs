using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //health if wanted or state represented in boolean
    public int health = 10;
    //deatheffect for extra
    //public GameObject deathEffect;
    //public float speed;
   // public bool moveRight;
    [HideInInspector]
    public bool mustPatrol =true;
    private bool moveLeft;
    public Rigidbody2D rb;
    public float walkspeed;
    public float distance;
    //transforms to check the ground position 
    //and wall positions
    public Transform groudcheckpos;
    public Transform wallcheckpos;
    //check for walls
    //public Transform wallcheckpos;
    public LayerMask groundlayer;
    public Collider2D bodycollide;

    //updates enemy movement
    //if move right is true, move enemy right
    //else, move enemy left
    void Update()
    {
        transform.Translate(Vector2.left * walkspeed * Time.deltaTime);
        //1st raycast to check if falls off platform
        //:modify for falling in general(ex. falling down stairs)
        RaycastHit2D groundInfo = Physics2D.Raycast(groudcheckpos.position, Vector2.down * Vector2.left, distance);
        //2nd raycast to check if hits a wall
        //RaycastHit2D wallInfo = Physics2D.Raycast(wallcheckpos.position, Vector2.left, 1);
        //RaycastHit2D wallInfo = Physics2D.Raycast(wallcheckpos.position, Vector2.left, distance);

        if (!groundInfo)
        {
            if(!moveLeft)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveLeft = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = false;
            }
        }
}
    public void TakeDamage(int damage)
    {
        loseHealth(damage);
    }

    private void loseHealth(int points)
    {
        health -= points;

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

    //practice script for possible Enemy patrol replacement


}
