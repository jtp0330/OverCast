using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //name of previous level
    //string baseName;
    string sceneName;
    private int lvl;
    //int[] level;

    void Start()
    {
        lvl = 1;
    }
    public void changeLevel(int l)
    {
        lvl = l;
    }

    public void resetLevel()
    {
        lvl = 1;
    }

    void Update()
    {

        if (Input.GetButtonDown("Submit"))
        {
            /*
            if (lvl == 1)
                sceneName = "Prototype";
            else if (lvl == 2)
                sceneName = "Level_2_OC";
            else if (lvl == 3)
                sceneName = "Boss_fight";
            */
            SceneManager.LoadScene("Prototype");
        }
            
    }
}
