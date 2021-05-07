using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameManager game;
    public Health h;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            game.h.Damage();
            if(game.h.health <= 0)
                Destroy(gameObject);
        }
    }
}
