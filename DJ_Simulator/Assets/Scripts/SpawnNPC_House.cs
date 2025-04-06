using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPC_House : MonoBehaviour
{

    public GameObject npc;
    private int numOfClones = 0;
    public int HouseNPC = 0;
    Vector3 spawnPos = new Vector3(-13, 0.5f, 17);
    Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);

    // Start is called before the first frame update
    void Start()
    {
        generateNPC();
    }

    // Update is called once per frame
    void Update()
    {
        //HouseNPC = numOfClones;
    }

    public void generateNPC()
    {
        // Generate NPCs
        numOfClones = Random.Range(2, 8);
        Debug.Log(numOfClones + " House clones will spawn.");

        // Reset counter first
        HouseNPC = 0;

        for (int i = 0; i < numOfClones; i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
            GameObject newNPC = Instantiate(npc, spawnPos, spawnRotation);

            // Increment counter once per NPC
            HouseNPC++;
        }
    }

    public void generateSingleNPC()
    {
        // Generate NPC
        Debug.Log("1 House clone will spawn.");

        Vector3 randomSpawnPos = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
        Instantiate(npc, spawnPos, spawnRotation);
        HouseNPC++;
    }


}
