
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //lives and score
    public Health h;
    //public Restart r;
   
    // private int score = 0;

    public Transform spawnPos;

    public Transform playertrans;

    public GameObject Player;
    //strings to load the GameOver screen and reload previous scene
    [SerializeField] private string sceneName;
    [SerializeField] private string nextScene;

    private void Update()
    {
        //if (h.health <= 0)
        // {
        //    Destroy(Player);
        //    GameOver();
        // }
        if (playertrans.position != null)
        {
            if (playertrans.position.y < -150)
            {
                playertrans.position = spawnPos.position;
                h.Damage();
            }
        }
        //*Instantly restart level script
        //*first need to incorporate a switch to play again
        //Application.LoadLevel(Application.loadedlevel);
    }
    public void GameOver()
    {
        Debug.Log("GAME OVER");

       
       SceneManager.LoadScene(sceneName);

        if (Input.GetButtonDown("Submit"))
            SceneManager.LoadScene(nextScene);
    }
}
