using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManagerHard : MonoBehaviour
{
    public List<GameObject> cutscenes; // List of cutscenes
    private int currentCutsceneIndex = 0; // Index of the current cutscene

    // Start is called before the first frame update
    void Start()
    {
        // Ensure only the first cutscene is active at the start
        for (int i = 0; i < cutscenes.Count; i++)
        {
            cutscenes[i].SetActive(i == currentCutsceneIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detect mouse click anywhere
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            GoToNextCutscene();
        }
    }

    private void GoToNextCutscene()
    {
        // Deactivate the current cutscene
        cutscenes[currentCutsceneIndex].SetActive(false);

        // Increment the index to go to the next cutscene
        currentCutsceneIndex++;

        // If we've reached the end of the cutscenes, stop
        if (currentCutsceneIndex >= cutscenes.Count)
        {
            Debug.Log("All cutscenes finished.");
            UnityEngine.SceneManagement.SceneManager.LoadScene("ClubKuboid_Hard");
        }

        // Activate the next cutscene
        cutscenes[currentCutsceneIndex].SetActive(true);
    }
}