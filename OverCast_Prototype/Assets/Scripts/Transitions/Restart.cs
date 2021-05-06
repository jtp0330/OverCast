using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //name of previous level
    string baseName;
    string sceneName;

    void Update()
    {

        if (baseName.Equals("Prototype"))
            sceneName = baseName;
        else if (baseName.Equals("Level_2_OC"))
            sceneName = baseName;

        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(sceneName);
    }
}
