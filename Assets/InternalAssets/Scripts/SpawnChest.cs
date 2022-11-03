using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    public List<GameObject> chestPositions = new List<GameObject>();
    public List<GameObject> spawnChests = new List<GameObject>();
    [SerializeField] GameObject chestModel;
    int randomizeSpawning;
    int randomizeChestType;
    int count = 0;

    void Start() {

    foreach (Transform chest in transform)
    {
        chestPositions.Add(chest.gameObject);
    }

    while (true)
    {

        if(count == 3){
            return;
        }
        randomizeSpawning = Random.Range(0, chestPositions.Count-1);
        Debug.Log(randomizeSpawning);
        Debug.Log(chestPositions.Count);

        if (!spawnChests.Contains(chestPositions[randomizeSpawning]) )
        {
            spawnChests.Add(chestPositions[randomizeSpawning]);
            Renderer positionBoxRenderer = chestPositions[randomizeSpawning].GetComponent<Renderer>();
            
            GameObject chest = Instantiate(chestModel, positionBoxRenderer.bounds.center, Quaternion.identity);
            count++;
        }
        // Destroy(transform.Find(chestPositions[randomizeSpawning].name).gameObject);
    }
    }

}
