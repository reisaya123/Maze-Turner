using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{

    Player player;
    AnimalCharacter animalCharacter;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.root.GetComponent<Player>();
        animalCharacter = GetComponent<AnimalCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (player.playerName == "Player 1" && Input.GetKeyDown(KeyCode.Space) ||
        player.playerName == "Player 2" && Input.GetKeyDown(KeyCode.RightShift))
        {
            transform.GetComponent<Animator>().SetTrigger("Attack");
            DamageObstacles();
            Debug.Log("Attack!");
        }
    }

    void DamageObstacles()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.75f);
        foreach(Collider obstacle in colliders){
            if(obstacle.GetComponent<ObstacleHealth>()){
                ObstacleHealth obstacleHealth = obstacle.GetComponent<ObstacleHealth>();
                obstacleHealth.TakeDamage(animalCharacter.baseDamage);
            }
        }
    }
}
