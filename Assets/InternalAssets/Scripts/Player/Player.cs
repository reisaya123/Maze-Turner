using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public int rolledDice;
    public int turnDuration;
    public bool myTurn;
    public AnimalCharacter animalCharacter;
    public float currentMoveSpeed;
    public float currentDamage;
    public List<string> buffs = new List<string>(); //if player turn is finished, reset buffs

    public string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        myTurn = false;
        animalCharacter = transform.GetComponent<AnimalCharacter>();
        currentMoveSpeed = animalCharacter.moveSpeed;
        currentDamage = animalCharacter.baseDamage;
        StartCoroutine(CheckIfTurn());
    }

    // Update is called once per frame
    void Update()
    {
        myTurn = GameManager.instance.CheckTurn(playerName);
        // Debug.Log("TURN DURATION:" + turnDuration.ToString());
    }

    bool MyTurn()
    {
        if (myTurn)
        {
            turnDuration = GameManager.instance.GetTurnDuration(playerName);
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator CheckIfTurn()
    {
        yield return new WaitUntil(MyTurn);

        currentMoveSpeed = animalCharacter.moveSpeed;
        currentDamage = animalCharacter.baseDamage;
    }
}
