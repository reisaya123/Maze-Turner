using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  [SerializeField] float maxHealthPoints = 3000;

    public float MaxHealthPoints
    {
        get
        {
            return maxHealthPoints;
        }

        set
        {
            maxHealthPoints = value;
        }
    }
}
