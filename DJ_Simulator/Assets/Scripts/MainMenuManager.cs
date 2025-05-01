using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.ResetScore();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        // Load the game scene
        ScoreManager.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cinematic");
    }

    public void StartHardGame()
    {
        // Load the game scene
        ScoreManager.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cinematic_Hard");
    }

    public void StartFreeplay()
    {
        // Load the game scene
        ScoreManager.ResetScore();
        UnityEngine.SceneManagement.SceneManager.LoadScene("ClubKuboid_FP");
    }

    public void ShowOptions()
    {
        // Show options menu
        Debug.Log("Options menu is not implemented yet.");

    }

    public void StartTutorial()
    {
        // Load the tutorial scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame()
    {
        // Exit the game
        Application.Quit();
    }
}
