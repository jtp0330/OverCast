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
    void Update()
    {
        if (health > numHearts)
            numHearts = health;

        if (health <= 0)
            Die();


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
        if (health <= 0 || numHearts <= 0)
            Die();
        else
            hearts[health--].sprite = emptyheart;
            //numHearts--;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
