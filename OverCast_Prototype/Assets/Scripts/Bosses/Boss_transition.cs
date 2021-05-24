using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boss_transition : MonoBehaviour
{
    [SerializeField] private Restart r;
    public string bossfight = "Boss_fight";
    private int lastStage = 3;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            r.changeLevel(lastStage);
            SceneManager.LoadScene(bossfight);
        }
    }
}
