using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC_Techno : MonoBehaviour
{

    public GameObject npc;
    private int numOfClones = 0;
    public int TechnoNPC = 0;

    // Start is called before the first frame update
    void Start()
    {
        generateNPC();
    }

    // Update is called once per frame
    void Update()
    {
        //TechnoNPC = numOfClones;
    }

    public void generateNPC()
    {
        // Generate NPCs
        numOfClones = Random.Range(2, 8);
        Debug.Log(numOfClones + " Techno clones will spawn.");

        // Reset counter first
        TechnoNPC = 0;

        for (int i = 0; i < numOfClones; i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
            GameObject newNPC = Instantiate(npc, randomSpawnPos, Quaternion.identity);

            // Increment counter once per NPC
            TechnoNPC++;
        }
    }

    public void generateSingleNPC()
    {
        // Generate NPC
        Debug.Log("1 House clone will spawn.");

        Vector3 randomSpawnPos = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
        Instantiate(npc, randomSpawnPos, Quaternion.identity);
        TechnoNPC++;
    }

}
