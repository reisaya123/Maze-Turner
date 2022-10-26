using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayerAndCam : MonoBehaviour
{
    public List<GameObject> animalModels;
    public GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.InstantiatePlayerAndCam(animalModels,mainCam);
    }

}
