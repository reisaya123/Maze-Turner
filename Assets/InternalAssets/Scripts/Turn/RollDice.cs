using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    [SerializeField] Sprite[] dices;
    Player player;
    Image dice;
    public int rolledDie;
    public bool canRoll;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        dice = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        canRoll = GameManager.instance.GetCanRoll(transform.parent.name);
        if (canRoll)
        {
            if ((Input.GetKeyDown(KeyCode.Space) && transform.parent.name == "RollDiceP1") ||
            (Input.GetKeyDown(KeyCode.RightShift) && transform.parent.name == "RollDiceP2"))
            {
                RollTheDice();
            }
        }
    }

    public void RollTheDice()
    {
        StartCoroutine(Rolling());
    }

    public IEnumerator Rolling(float count = 1f)
    {
        int randomDiceSide = 0;
        float time = 0f;
        canRoll = false;
        while (true)
        {
            if (time >= count)
            {
                rolledDie = randomDiceSide + 1;
                GameManager.instance.UpdateGameState(GameManager.GameState.PlayerTurn);
                yield break;
            }

            randomDiceSide = Random.Range(0, 6);
            dice.sprite = dices[randomDiceSide];
            time += .1f;

            Debug.Log("Rolled Dice:" + (randomDiceSide + 1).ToString());
            yield return new WaitForSeconds(.1f);
        }

    }

    public float ConvertDiceValueToTime()
    {
        return GameManager.instance.GetTurnDuration(rolledDie);
    }

}

