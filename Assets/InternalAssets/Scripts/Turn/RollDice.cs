using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    [SerializeField] Sprite[] dices;
    Image dice;
    public int rolledDie;
    public bool canRoll;
    // Start is called before the first frame update
    void Start()
    {
        canRoll = false;
        dice = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RollTheDice();
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
        while (true)
        {
            if (time >= count)
            {
                rolledDie = randomDiceSide + 1;

                yield break;
            }

            randomDiceSide = Random.Range(0, 6);
            dice.sprite = dices[randomDiceSide];
            time += .1f;

            Debug.Log("Rolled Dice:" + (randomDiceSide + 1).ToString());
            yield return new WaitForSeconds(.1f);
        }

    }

    public int GetRolledDie()
    {
        return rolledDie;
    }

}

