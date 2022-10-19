using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    AnimalCharacter animal;

    // Start is called before the first frame update
    void Start()
    {
        animal.baseDamage = 100f;
        animal.moveSpeed = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
