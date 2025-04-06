using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcManager : MonoBehaviour
{
    public SpawnNPC_Techno scriptTechno;
    public SpawnNPC_House scriptHouse;
    public SpawnNPC_Jungle scriptJungle;
    public techno_stats scriptTechnoStats;
    public house_stats scriptHouseStats;
    public jungle_stats scriptJungleStats;

    int a;
    int b;
    int c;

    public static string popularGenre;
    private bool routineRunning = false;

    public Transform despawnPoint; // Assign this in the Inspector to the position NPCs should walk to

    // Lists to track NPCs walking to despawn
    private List<GameObject> npcsWalkingToDespawn = new List<GameObject>();

    // Reference to all NPCs in the scene
    private List<GameObject> allNPCs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
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

        // Check for NPCs that have reached the despawn point
        CheckForDespawningNPCs();
    }

    // Called by NPC spawner scripts to register new NPCs
    public void RegisterNPC(GameObject npc)
    {
        if (!allNPCs.Contains(npc))
        {
            allNPCs.Add(npc);
        }
    }

    // Called when an NPC is destroyed to remove it from tracking
    public void UnregisterNPC(GameObject npc)
    {
        if (allNPCs.Contains(npc))
        {
            allNPCs.Remove(npc);
        }
    }

    void noDuplicates()
    {
        // Check for duplicate NPCs
        if (a == b || a == c || b == c)
        {
            Debug.Log("Duplicate NPCs found.");
            scriptTechnoStats.techno_stat_text.SetText("Techno: Adjusting NPC numbers...");
            scriptHouseStats.house_stat_text.SetText("House: Adjusting NPC numbers...");
            scriptJungleStats.jungle_stat_text.SetText("Jungle: Adjusting NPC numbers...");

            // Instead of using tags, use our tracked list of NPCs
            foreach (GameObject npc in new List<GameObject>(allNPCs))
            {
                // Check NPC type and update counter
                npcAnimManager npcAnim = npc.GetComponent<npcAnimManager>();

                if (npcAnim != null)
                {
                    // Add to list of NPCs walking to despawn
                    npcsWalkingToDespawn.Add(npc);

                    // Tell the NPC to walk to the despawn point
                    npcAnim.WalkToPositionAndDespawn(despawnPoint.position);
                }
                else
                {
                    // If there's no animator, just destroy it immediately
                    DestroyNPC(npc);
                }
            }

            // Clear the list of clones
            scriptTechno.TechnoNPC = 0;
            scriptHouse.HouseNPC = 0;
            scriptJungle.JungleNPC = 0;
            Debug.Log("Duplicate NPCs cleared.");
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
    }

    // Coroutine to randomly create or destroy NPCs
    IEnumerator RandomNPCManipulation()
    {
        routineRunning = true;

        while (routineRunning)
        {
            // Wait for random time between 30 and 90 seconds
            float waitTime = Random.Range(3f, 9f);
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
                        Debug.Log("Randomly created a Techno NPC. New count: " + scriptTechno.TechnoNPC);
                        break;
                    case 1:
                        scriptHouse.generateSingleNPC();
                        Debug.Log("Randomly created a House NPC. New count: " + scriptHouse.HouseNPC);
                        break;
                    case 2:
                        scriptJungle.generateSingleNPC();
                        Debug.Log("Randomly created a Jungle NPC. New count: " + scriptJungle.JungleNPC);
                        break;
                }
            }
            else
            {
                // Use our tracked list instead of FindGameObjectsWithTag
                if (allNPCs.Count > 0)
                {
                    // Choose a random NPC to destroy
                    int npcIndex = Random.Range(0, allNPCs.Count);
                    GameObject npcToDestroy = allNPCs[npcIndex];

                    // Check NPC type and update counter
                    npcAnimManager npcAnim = npcToDestroy.GetComponent<npcAnimManager>();

                    if (npcAnim != null)
                    {
                        // Add to list of NPCs walking to despawn
                        npcsWalkingToDespawn.Add(npcToDestroy);

                        // Tell the NPC to walk to the despawn point
                        npcAnim.WalkToPositionAndDespawn(despawnPoint.position);

                        Debug.Log("NPC is walking to despawn point: " + npcAnim.npcType);
                    }
                    else
                    {
                        // If there's no animator, just destroy it immediately
                        DestroyNPC(npcToDestroy);
                    }
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
                            break;
                        case 1:
                            scriptHouse.generateSingleNPC();
                            break;
                        case 2:
                            scriptJungle.generateSingleNPC();
                            break;
                    }
                }
            }
        }
    }

    private void CheckForDespawningNPCs()
    {
        // Check for NPCs that have reached the despawn point
        List<GameObject> npcsToRemove = new List<GameObject>();

        foreach (var npc in npcsWalkingToDespawn)
        {
            if (npc == null)
            {
                npcsToRemove.Add(npc);
                continue;
            }

            // Check if the NPC has reached the despawn point
            float distanceToDespawn = Vector3.Distance(npc.transform.position, despawnPoint.position);
            if (distanceToDespawn < 0.5f)
            {
                DestroyNPC(npc);
                npcsToRemove.Add(npc);
            }
        }

        // Remove entries for NPCs that have been destroyed
        foreach (var npc in npcsToRemove)
        {
            if (npcsWalkingToDespawn.Contains(npc))
            {
                npcsWalkingToDespawn.Remove(npc);
            }
        }
    }

    // Called when an NPC reaches the despawn point
    public void OnReachedDespawnPoint(GameObject npc)
    {
        Debug.Log("NPC reached despawn point: " + npc.name);

        if (npcsWalkingToDespawn.Contains(npc))
        {
            DestroyNPC(npc);
            npcsWalkingToDespawn.Remove(npc);
        }
        else
        {
            // Even if it's not in our list, destroy it anyway
            DestroyNPC(npc);
        }
    }

    private void DestroyNPC(GameObject npc)
    {
        // Get the NPC type before destroying
        npcAnimManager npcAnim = npc.GetComponent<npcAnimManager>();
        string npcType = null;

        if (npcAnim != null)
        {
            npcType = npcAnim.npcType.ToLower();
        }

        // Update counters based on NPC type
        if (npcType != null)
        {
            switch (npcType)
            {
                case "techno":
                    if (scriptTechno.TechnoNPC > 0)
                        scriptTechno.TechnoNPC--;
                    Debug.Log("Destroyed a Techno NPC. New count: " + scriptTechno.TechnoNPC);
                    break;
                case "house":
                    if (scriptHouse.HouseNPC > 0)
                        scriptHouse.HouseNPC--;
                    Debug.Log("Destroyed a House NPC. New count: " + scriptHouse.HouseNPC);
                    break;
                case "jungle":
                    if (scriptJungle.JungleNPC > 0)
                        scriptJungle.JungleNPC--;
                    Debug.Log("Destroyed a Jungle NPC. New count: " + scriptJungle.JungleNPC);
                    break;
            }
        }

        // Remove from our tracking list
        if (allNPCs.Contains(npc))
        {
            allNPCs.Remove(npc);
        }

        // Destroy the NPC
        Destroy(npc);
    }

    // Call this method when you want to stop the random manipulation
    public void StopRandomManipulation()
    {
        routineRunning = false;
    }
}