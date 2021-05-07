using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //name of previous level
    //string baseName;
    public string sceneName;
    //int[] level;

    void Start()
    {
    //    level = new int[5];
    }

    void Update()
    {
        /*
        if (baseName.Equals("Prototype"))
            sceneName = "Prototype";
        else if (baseName.Equals("Level_2_OC"))
            sceneName = "Level_2_OC";
         */
        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(sceneName);
    }
}
