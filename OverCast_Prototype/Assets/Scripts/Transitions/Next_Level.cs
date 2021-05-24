using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private Restart r;
    private int next = 1;

    private void Start()
    {
        //update lvl
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (next == 1)
            {
                
                //next++;
                sceneName = "Level_2_OC";
            }
            else
            {
                r.resetLevel();
                sceneName = "Welcome";
            }
            SceneManager.LoadScene(sceneName);
        }
           
    }
}
