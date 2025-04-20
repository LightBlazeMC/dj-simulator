using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void returnToMenu()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

}
