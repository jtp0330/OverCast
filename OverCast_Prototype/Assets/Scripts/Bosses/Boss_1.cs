using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
/// <Boss_1>
/// Name: Jared Park
/// Description: First boss of our game.
/// First phase: walk and jump
/// Second phase: fly, bounce up down in zig zag pattern (hitting 3 times)
/// extra:3rd hit, splits boss into mini clouds
/// Inspiration: Gruz Mother from Hollow Knight
/// video for inspiration and reference: https://www.youtube.com/watch?v=n0ANVuX7ycM&t=335s
/// </Boss_1>
public class Boss_1 : MonoBehaviour
{
    //general
    //health: = 50; 25 = enrage
    public Slider healthbar;
    public int health;
    private int baseHealth;

    //win condition after death
    public GameObject g;
    //Idle/Walk stage
    [Header("Idle/Walk")]
    [SerializeField] float idleMoveSpeed;
    [SerializeField] Vector2 idleMoveDirection;

    //Jump
    int jumpNwalk;
    [SerializeField] bool jump;
    [SerializeField] bool isGrounded;
    [SerializeField] private float jumpForce = 800f;

    //Float/Enrage stage
    [Header("AttackUpNDown")]
    [SerializeField] float attackSpeed;
    [SerializeField] Vector2 attackMoveDirection;
    //shoot minion at player
    [SerializeField] Transform player;
    bool split;
    //Other
    [Header("Other")]
    [SerializeField] Transform groundCheckUP;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private bool goingUp = true;
    private bool facingLeft = true;
    private Rigidbody2D enemyRB;
    //transition to enrage mode
    private bool secondPhase = false;
    private bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        //affect angle, but not speed of movement
       
        idleMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        enemyRB = GetComponent<Rigidbody2D>();
        baseHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = health;
        //boolean checks to see if boss is touching tags
        isTouchingUp = Physics2D.OverlapCircle(groundCheckUP.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);

        //healthbar.value = health;
        if (health <= 0)
        {
            Die();
        }

        jumpNwalk = Random.Range(0, 2);
        IdleState();
    }
    //move in direction of 
    void IdleState()
    {
        //movementspeed affected by direction
        //normlized in Start()
        //second phase:
        //if touching up and going up
        if (secondPhase)
        {
            if(isTouchingUp && !goingUp)
            {
                goingUp = !goingUp;
            }
            else if(isTouchingDown && goingUp)
            {
                goingUp = !goingUp;
            }
            else if (isTouchingUp && goingUp)
            {
                ChangeFlyDirection();
            }
            else if (isTouchingDown && !goingUp)
            {
                ChangeFlyDirection();
            }
            if (isTouchingWall)
            {
                if (facingLeft)
                {
                    Flip();
                }
                else if (!facingLeft)
                {
                    Flip();
                }
            }
            enemyRB.velocity = idleMoveSpeed * idleMoveDirection;

        }//1st phase
        else
        {
            
            //if touching wall, flip direction
            if (isTouchingWall)
            {
                if (facingLeft)
                {
                    Flip();
                }
                else if (!facingLeft)
                {
                    Flip();
                }
            }
            if (jumpNwalk == 1)
                Jump();

            enemyRB.velocity = idleMoveSpeed * idleMoveDirection;
        }
    }
    //boss jump function during phase 1
    void Jump()
    {
        Vector2 jumps = new Vector2(180f, jumpForce);
        if (isTouchingDown)
        {
            enemyRB.AddForce(jumps,ForceMode2D.Impulse);
        }
        enemyRB.velocity = idleMoveSpeed * idleMoveDirection;
    }
    //attack pattern during 
    //second phase
    void AttackUpnDown()
    {
      if (isTouchingUp && goingUp)
      {
         ChangeFlyDirection();
      }
      else if (isTouchingDown && !goingUp)
      {
         ChangeFlyDirection();
      }
      //if touching wall, flip direction
      if (isTouchingWall)
      {
         if (facingLeft)
         {
            Flip();
         }
         else if (!facingLeft)
         {
            Flip();
         }
      }

        enemyRB.velocity = attackSpeed * attackMoveDirection;
    }

    //change direction for flying 2nd phase, similar to Gruz mother
    void ChangeFlyDirection()
    {
        goingUp = !goingUp;
        idleMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;

    }
    //flips boss and attack direction
    void Flip()
    {
        facingLeft = !facingLeft;
        idleMoveDirection.x *= -1;
        attackMoveDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
    //transition function:
    //1. grants flight to boss, by adding 2 to movedirection.y
    //2. animation for changing to flight mode
    //3. triggered by health bar reaching 50%
    void changePhase()
    {
        enemyRB.velocity = new Vector2(0,0);
        secondPhase = true;
        //invincible = true;
        //trigger rage mode
        GetComponent<Animator>().SetBool("secondPhase", true);
        idleMoveDirection.y = 4;
        attackMoveDirection.y = 5;
    }
    //draw colliders/wire spheres around detection points
    private void OnDrawGizmosSelected()
    {
        //draw spheres for collision detection around tags
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUP.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);
    }
    //damage functions
    public void TakeDamage(int damage)
    {
        //checks if in 2nd phase, then adds move direciton y-values
        if (health <= (baseHealth / 2))
            changePhase();

        if (!invincible)
            loseHealth(damage);
    }

    private void loseHealth(int points)
    {
        health -= points;

    }
    void Die()
    {
        //enemy deatheffect, will create death effect and destroy enemy
        //Instantiate(deathEffect, transform.position, );
        Destroy(gameObject);
        g.active = true;
    }

}
