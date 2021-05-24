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
    //public bool moveRight;

    //patrol system 
    public List<Transform> points;
    //the int value for the next point index
    public int nextID;
    //value of that applies to ID for changing
    int idChangeValue = 1;

    private void Reset()
    {
        Init();
    }
    void Init()
    {
       // GetComponent<BoxCollider2D>().isTrigger = true;
        //init current position of cloud
        GameObject root = new GameObject("Flying_Waypoint_root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);
        GameObject waypoints = new GameObject("Waypoints");
        //transform of the way points is set to transform of cloud
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = Vector3.zero;
        waypoints.transform.position = root.transform.position;
        //
        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = Vector3.zero;
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = Vector3.zero;

        //Init point list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);


    }


    // Update is called once per frame
   
    void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];

        if(goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        //gives interloping position between one point to another
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //check if we are at the end of the line (make change -1)
            //2 points (0,1) next == points.count(2)-1
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //check if we are at the start of the line (make change +1)
            if (nextID == 0)
                idChangeValue = 1;
            
            //apply the change on the nextID
            nextID += idChangeValue;
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
}
