using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(sceneName);
    }
}
