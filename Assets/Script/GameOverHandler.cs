using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverHandler : MonoBehaviour
{
    public GameObject gameOverPanel;
    public AstreoidSpawner spawner;
    public ScoreSystem scoreSystem;
   // public GameObject adManager;
   
    //public GameObject quitButton;
    public GameObject startButton;
    public GameObject MainMenuButton;
    public TMP_Text GameNameText;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject player;

    [SerializeField] TMP_Text gameOverText;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    

    public void EndGame()
    {
         int finalScore= scoreSystem.EndTimer();
        gameOverText.text= $"Your Score : {finalScore}";
        spawner.enabled = false;
        scoreSystem.enabled = false;
        gameOverPanel.gameObject.SetActive(true);
    }


    /*public void quitGame()// quit game button 
    {

        // I took this function completely from chat gpt becasue application.quit didn't work.
        Debug.Log("Quitting Game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Quit play mode in Editor
#else
        Application.Quit(); // Quit application in built game
#endif
    }
*/

    public void gameScene() // game play scene
    {

        SceneManager.LoadScene("Play");
        Debug.Log("pressed Start");
    }

    public void ContinueButton()
    {
        if (continueButton == null)
        {
            Debug.LogError("Continue Button is not assigned!");
            return;
        }

        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
       
    }

   

    public void mainMenu()// used in endscene and victoryscene
    {
        SceneManager.LoadScene("MainMenu");

        Debug.Log("pressed mainMenu");
    }


    public void ContinueGame()
    {
        scoreSystem.enabled = true;
        scoreSystem.StartTimer();
        
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        spawner.enabled = true;

        gameOverPanel.gameObject.SetActive(false);

    }

   
}
