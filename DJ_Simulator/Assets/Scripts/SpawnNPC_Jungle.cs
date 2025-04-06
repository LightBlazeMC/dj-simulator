using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC_Jungle : MonoBehaviour
{

    public GameObject npc;
    private int numOfClones = 0;
    public int JungleNPC = 0;



    // Start is called before the first frame update
    void Start()
    {
        generateNPC();
    }

    // Update is called once per frame
    void Update()
    {
        //JungleNPC = numOfClones;
    }

    public void generateNPC()
    {
        // Generate NPCs
        numOfClones = Random.Range(2, 8);
        Debug.Log(numOfClones + " Jungle clones will spawn.");

        // Reset counter first
        JungleNPC = 0;

        for (int i = 0; i < numOfClones; i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
            GameObject newNPC = Instantiate(npc, randomSpawnPos, Quaternion.identity);

            // Increment counter once per NPC
            JungleNPC++;
        }
    }

    public void generateSingleNPC()
    {
        // Generate NPC
        Debug.Log("1 House clone will spawn.");

        Vector3 randomSpawnPos = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
        Instantiate(npc, randomSpawnPos, Quaternion.identity);
        JungleNPC++;
    }
}
