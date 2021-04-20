using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressPlay : MonoBehaviour
{
    [SerializeField] private string sceneName;

    // Update is called once per frame
    void Begin()
    {
        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(sceneName);
    }
}
