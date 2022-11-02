using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public List<GameObject> positions = new List<GameObject>();
    [SerializeField] Transform playerModel1;
    [SerializeField] Transform playerModel2;
    int randomizeSpawnP1;
    int randomizeSpawnP2;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            positions.Add(child.gameObject);
        }

        randomizeSpawnP1 = Random.Range(0,4);
        // randomizeSpawnP2 = Random.Range(0,4);

        Debug.Log(randomizeSpawnP1);
        // Debug.Log(randomizeSpawnP2);

        Renderer positionBoxRenderer = positions[randomizeSpawnP1].GetComponent<Renderer>();
        playerModel1.position = positionBoxRenderer.bounds.center; 
    }
}
