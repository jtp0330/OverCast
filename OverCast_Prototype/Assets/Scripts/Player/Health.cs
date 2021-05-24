using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int numHearts;
    public Collider2D damage;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    public GameManager game;


    // Update is called once per frame

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            
            if (health <= 1)
                Die();
            else
                Damage();
        }
    }

    void Update()
    {
        //if (health > numHearts)
        //    numHearts = health;


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullheart;
            else
                hearts[i].sprite = emptyheart;

            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
                hearts[i].enabled = false;
        }
    }

    public void Damage()
    {
        if (health <= 1)
        {
            hearts[0].sprite = emptyheart;
            health--;
            Die();
        }
        else
        {
            if (health == 0)
                Die();
            else
            {
                health--;
                hearts[health].sprite = emptyheart;
            }
        } 
            //numHearts--;
    }

    public void Die()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        game.GameOver();
    }
}
