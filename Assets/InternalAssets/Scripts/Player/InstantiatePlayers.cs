using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayers : MonoBehaviour
{
    public List<GameObject> animalModels;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.InstantiatePlayerAnimals(animalModels);
    }

}
