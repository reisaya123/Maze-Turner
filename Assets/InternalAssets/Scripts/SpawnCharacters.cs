using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{
    [SerializedField] GameObject[] position;
    [SerializedField] Transform playerModel1;
    [SerializedField] Transform playerModel2;

    // Start is called before the first frame update
    void Start()
    {
        float randomizeSpawnP1 = Random.Range(0,4);
        Debug.Log(randomizeSpawnP1);

        // Renderer positionBoxRenderer = position[0].GetComponent<Renderer>();
        // characterModel.position = positionBoxRenderer.bounds.center;
    }
}
