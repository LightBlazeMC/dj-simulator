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
        numOfClones = Random.Range(2,8);
        Debug.Log(numOfClones + " Techno clones will spawn.");

        for(int i=0; i<numOfClones; i++)
            {
                Vector3 randomSpawnPos = new Vector3(Random.Range(-8, 8), 0.5f, Random.Range(-8, 8));
                Instantiate(npc, randomSpawnPos, Quaternion.identity);
            }
    }

    // Update is called once per frame
    void Update()
    {
        TechnoNPC = numOfClones;
    }
}
