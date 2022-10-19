using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AnimalCharacter animalSelected;
    public int rolledDice;
    public List<string> buffs = new List<string>(); //if player turn is finished, reset buffs

    public AnimalCharacter AnimalSelected
    {
        get
        {
            return animalSelected;
        }
        set
        {
            animalSelected = value;
        }
    }

    public void SelectAnimal(AnimalCharacter animalCharacter)
    {
        animalSelected = animalCharacter;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
