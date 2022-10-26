using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCharacter : MonoBehaviour
{
    public GameObject model;
    public string animalName;
    public float baseDamage;
    public float moveSpeed;

    public string AnimalName
    {
        get
        {
            return animalName;
        }
        set
        {
            animalName = value;
        }
    }
    public float BaseDamage
    {
        get
        {
            return baseDamage;
        }
        set
        {
            baseDamage = value;
        }
    }
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }
    

}
