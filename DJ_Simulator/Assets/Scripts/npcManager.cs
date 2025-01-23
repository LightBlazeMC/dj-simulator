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

    int a;
    int b;
    int c;

    public static string popularGenre;

    // Start is called before the first frame update
    void Start()
    {
        a = scriptTechno.TechnoNPC;
        b = scriptHouse.HouseNPC;
        c = scriptJungle.JungleNPC;
        findPopularGenre();
        noDuplicates();
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
}
