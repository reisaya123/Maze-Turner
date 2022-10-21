using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    public List<GameObject> chestPositions = new List<GameObject>();
    [SerializeField] Transform chestModel;
    int randomizeSpawning;
    int randomizeChestType;
    int count = 0;

    void Start() {

    // foreach (Transform chest in transform)
    // {
    //     chestPositions.Add(chest.gameObject);
    // }

    // int currentRandomizeSpawning = randomizeSpawning
    // while (true)
    // {
    //     if(count == 3){
    //         return;
    //     }
    //             randomizeSpawning = Random.Range(0, 13);
    //     if(currentRandomizeSpawning != randomizeSpawning){
    //     GameObject chest =    Instantiate(chestModel)
    //     Renderer positionBoxRenderer = chestPositions[randomizeSpawning].GetComponent<Renderer>();
    // chest.position = positionBoxRenderer.bounds.center; 
    // count++;
    //     }
    // }
    // for(count=0; count < 3; count++){[


    // ]}

            
    }

}
