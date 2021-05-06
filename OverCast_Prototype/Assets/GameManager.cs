
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //lives and score
    public int hearts = 1;
    // private int score = 0;

    public Transform spawnPos;

    public Transform playertrans;

    public GameObject Player;
    //strings to load the GameOver screen and reload previous scene
    [SerializeField] private string sceneName;
    [SerializeField] private string nextScene;

    public void Start()
    {
      
    }

    private void Update()
    {
        if (hearts <= 0)
        {
            Destroy(Player);
            GameOver();
        }
        else if (playertrans.position.y < -180)
        {
            playertrans.position = spawnPos.position;
            hearts--;
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
