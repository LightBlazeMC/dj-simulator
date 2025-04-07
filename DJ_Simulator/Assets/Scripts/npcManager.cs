using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class npcManager : MonoBehaviour
{
    public SpawnNPC_Techno scriptTechno;
    public SpawnNPC_House scriptHouse;
    public SpawnNPC_Jungle scriptJungle;
    public techno_stats scriptTechnoStats;
    public house_stats scriptHouseStats;
    public jungle_stats scriptJungleStats;

    private bool canShowUI = false;

    public GameObject crowdResetUI;

    int a;
    int b;
    int c;

    public static string popularGenre;
    private bool routineRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(uiStart());
        crowdResetUI.SetActive(false);
        a = scriptTechno.TechnoNPC;
        b = scriptHouse.HouseNPC;
        c = scriptJungle.JungleNPC;
        findPopularGenre();
        noDuplicates();

        // Start the random NPC manipulation coroutine
        StartCoroutine(RandomNPCManipulation());
    }

    // Update is called once per frame
    void Update()
    {
        a = scriptTechno.TechnoNPC;
        b = scriptHouse.HouseNPC;
        c = scriptJungle.JungleNPC;
        findPopularGenre();
        noDuplicates();
    }

    void noDuplicates()
    {
        // Check for duplicate NPCs
        Debug.Log("Checking for duplicate NPCs...");
        if (a == b || a == c || b == c)
        {
            Debug.Log("Duplicate NPCs found.");
            scriptTechnoStats.techno_stat_text.SetText("Techno: Adjusting NPC numbers...");
            scriptHouseStats.house_stat_text.SetText("House: Adjusting NPC numbers...");
            scriptJungleStats.jungle_stat_text.SetText("Jungle: Adjusting NPC numbers...");

            GameObject[] npcs = GameObject.FindGameObjectsWithTag("npc");

            foreach (GameObject npc in npcs)
            {
                Destroy(npc);
            }

            // Clear the list of clones
            scriptTechno.TechnoNPC = 0;
            scriptHouse.HouseNPC = 0;
            scriptJungle.JungleNPC = 0;
            Debug.Log("Duplicate NPCs cleared.");
            StartCoroutine(crowdResetUIPrompt());
            scriptHouse.generateNPC();
            scriptJungle.generateNPC();
            scriptTechno.generateNPC();
        }
    }

    void findPopularGenre()
    {
        int highest = Mathf.Max(a, Mathf.Max(b, c));

        if (highest == a)
        {
            popularGenre = "Techno";
        }
        else if (highest == b)
        {
            popularGenre = "House";
        }
        else
        {
            popularGenre = "Jungle";
        }

        Debug.Log("The most popular genre right now is " + popularGenre + " with a value of: " + highest);
    }

    // Coroutine to randomly create or destroy NPCs
    IEnumerator RandomNPCManipulation()
    {
        routineRunning = true;

        while (routineRunning)
        {
            // Wait for random time between 30 and 50 seconds
            float waitTime = Random.Range(30f, 50f);
            yield return new WaitForSeconds(waitTime);

            // Decide to either create or destroy an NPC
            bool createNPC = Random.value > 0.5f;

            if (createNPC)
            {
                // Create a random NPC type
                int npcType = Random.Range(0, 3);
                switch (npcType)
                {
                    case 0:
                        scriptTechno.generateSingleNPC();
                        //scriptTechno.TechnoNPC++;
                        Debug.Log("Randomly created a Techno NPC. New count: " + scriptTechno.TechnoNPC);
                        break;
                    case 1:
                        scriptHouse.generateSingleNPC();
                        //scriptHouse.HouseNPC++;
                        Debug.Log("Randomly created a House NPC. New count: " + scriptHouse.HouseNPC);
                        break;
                    case 2:
                        scriptJungle.generateSingleNPC();
                        //scriptJungle.JungleNPC++;
                        Debug.Log("Randomly created a Jungle NPC. New count: " + scriptJungle.JungleNPC);
                        break;
                }
            }
            else
            {
                // Find all NPCs
                GameObject[] npcs = GameObject.FindGameObjectsWithTag("npc");

                if (npcs.Length > 0)
                {
                    // Choose a random NPC to destroy
                    int npcIndex = Random.Range(0, npcs.Length);
                    GameObject npcToDestroy = npcs[npcIndex];

                    // Check NPC type and update counter
                    npcAnimManager npcAnim = npcToDestroy.GetComponent<npcAnimManager>();

                    if (npcAnim != null)
                    {
                        switch (npcAnim.npcType.ToLower())
                        {
                            case "techno":
                                if (scriptTechno.TechnoNPC > 0)
                                    scriptTechno.TechnoNPC--;
                                Debug.Log("Randomly removed a Techno NPC. New count: " + scriptTechno.TechnoNPC);
                                break;
                            case "house":
                                if (scriptHouse.HouseNPC > 0)
                                    scriptHouse.HouseNPC--;
                                Debug.Log("Randomly removed a House NPC. New count: " + scriptHouse.HouseNPC);
                                break;
                            case "jungle":
                                if (scriptJungle.JungleNPC > 0)
                                    scriptJungle.JungleNPC--;
                                Debug.Log("Randomly removed a Jungle NPC. New count: " + scriptJungle.JungleNPC);
                                break;
                        }
                    }

                    // Destroy the NPC
                    Destroy(npcToDestroy);
                }
                else
                {
                    Debug.Log("No NPCs to destroy, creating one instead");
                    // Create a random NPC if there are none to destroy
                    int npcType = Random.Range(0, 3);
                    switch (npcType)
                    {
                        case 0:
                            scriptTechno.generateSingleNPC();
                            //scriptTechno.TechnoNPC++;
                            break;
                        case 1:
                            scriptHouse.generateSingleNPC();
                            //scriptHouse.HouseNPC++;
                            break;
                        case 2:
                            scriptJungle.generateSingleNPC();
                            //scriptJungle.JungleNPC++;
                            break;
                    }
                }
            }
        }
    }

    // Call this method when you want to stop the random manipulation
    public void StopRandomManipulation()
    {
        routineRunning = false;
    }

    IEnumerator uiStart()
    {
        canShowUI = false;
        yield return new WaitForSeconds(5f);
        canShowUI = true;
    }

    IEnumerator crowdResetUIPrompt()
    {
        if (canShowUI)
        {
            crowdResetUI.SetActive(true);
            yield return new WaitForSeconds(3f);
            crowdResetUI.SetActive(false);
        }
    }
}