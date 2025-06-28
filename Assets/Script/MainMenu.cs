using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // this script is for the maain menu button only.
    public GameObject infoPanel;
    public GameObject quitButton;
    public GameObject startButton;
    public GameObject infoButton;
    public TMP_Text GameNameText;
    private void Start()
    {

        infoPanel.gameObject.SetActive(false);// set active false fro info panel at the beggining.

    }
   


    public void quitGame()// quit game button 
    {

        // I took this function completely from chat gpt becasue application.quit didn't work.
        Debug.Log("Quitting Game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Quit play mode in Editor
#else
        Application.Quit(); // Quit application in built game
#endif
    }


    public void gameScene() // game play scene
    {

        SceneManager.LoadScene("Play");
        Debug.Log("pressed Start");
    }

    public void gameOverScene() // game play scene
    {

        SceneManager.LoadScene("GameOverScene");
        Debug.Log("pressed Start");

    }

    public void Instruction()// instruction button, activate info panel
    {
        Debug.Log("pressed Instruction");
        
        GameNameText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        infoButton.gameObject.SetActive(false);
        //GameNameText.gameObject.SetActive(true);

        infoPanel.gameObject.SetActive(true);
    }

    public void instructionExit()  // X button to exit from info panel
    {
        Debug.Log("pressed Instruction exit");
        infoPanel.gameObject.SetActive(false);
        GameNameText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        infoButton.gameObject.SetActive(true);
       // GameNameText.gameObject.SetActive(true);
    }

    /*public void mainMenu()// used in endscene and victoryscene
    {
        SceneManager.LoadScene("StartScene");

        Debug.Log("pressed mainMenu");
    }*/
}

