using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleHealth : MonoBehaviour
{
    Obstacle obstacle;
    [SerializeField] Slider healthBar;
    public float currentHealthPoints = 0f;

    void Start()
    {
        healthBar = healthBar.GetComponent<Slider>();
        obstacle = GetComponent<Obstacle>();

        healthBar.maxValue = obstacle.MaxHealthPoints;
        currentHealthPoints = obstacle.MaxHealthPoints;
        healthBar.value = currentHealthPoints;
    }

    public float CurrentHealthPoints
    {
        get
        {
            return currentHealthPoints;
        }

        set
        {
            currentHealthPoints = value;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealthPoints -= damage;
        healthBar.value = currentHealthPoints;
    }
}
