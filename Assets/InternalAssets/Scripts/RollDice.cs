using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollDice : MonoBehaviour
{
    [SerializeField] Sprite[] dices;
    Image dice;
    // Start is called before the first frame update
    void Start()
    {
        dice = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)){
  StartCoroutine(RollTheDice());
        }
      
    }

    IEnumerator RollTheDice(float count = 1f)
    {
        int randomDiceSide = 0;
        float time = 0f;
        while (true)
        {
            if(time >= count){
                yield break;
            }

            randomDiceSide = Random.Range(0,6);
            dice.sprite = dices[randomDiceSide];
            time += .1f;
            Debug.Log("Rolled Dice:" + (randomDiceSide+1).ToString());
            yield return new WaitForSeconds(.1f); 
        }

    }

}

