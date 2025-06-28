using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    MainMenu mainmenu;
   public  GameOverHandler gameOverHandler;

   
    public  ScoreSystem scoreSystem;

    public void Start()
    {
        if (gameOverHandler == null)
        {
            gameOverHandler = FindObjectOfType<GameOverHandler>();

            if (gameOverHandler == null)
            {
                Debug.LogError("GameOverHandler is not found in the scene!");
            }
        }

    }
    public void Crash()
    {
        gameOverHandler.EndGame();

        gameObject.SetActive(false);
       



        

    }
}
