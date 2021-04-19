using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    [SerializeField] private string sceneName;

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(sceneName);
    }
}
