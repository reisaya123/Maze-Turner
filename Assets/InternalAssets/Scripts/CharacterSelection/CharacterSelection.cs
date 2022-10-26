using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public string player;
    public List<GameObject> animals = new List<GameObject>();
    public CharacterSelectionUI characterSelectionUI;
    public float time;

    GameObject selectedAnimal;
    int index;

    public string Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetAllAnimals();
        int index = 0;
        selectedAnimal = animals[index];
        StartCoroutine(Selection());
        characterSelectionUI.SelectAnimalUI(transform.name, index, true);
    }

    void GetAllAnimals()
    {
        foreach (Transform child in transform)
        {
            animals.Add(child.gameObject);
        }
    }
    void Selected(string animalName)
    {
        if (time != Time.time)
        {

            if (player == "player1")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    characterSelectionUI.ReadySelectionUI(transform.name);
                    GameManager.instance.ReadyPlayer1(animalName);

                }
            }
            else if (player == "player2")
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    characterSelectionUI.ReadySelectionUI(transform.name);
                    GameManager.instance.ReadyPlayer2(animalName);

                }
            }
        }
    }

    IEnumerator Selection()
    {
        GameObject currentSelectedAnimal = selectedAnimal;
        while (true)
        {
            int prevSelectedIndex = index;

            if (player == "player1")

            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = animals.Count - 1;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    if (index < animals.Count - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
            }
            else if (player == "player2")
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = animals.Count - 1;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (index < animals.Count - 1)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
            }

            if (currentSelectedAnimal != animals[index])
            {
                selectedAnimal.SetActive(false);
                characterSelectionUI.SelectAnimalUI(transform.name, prevSelectedIndex, false);

                selectedAnimal = animals[index];
                selectedAnimal.SetActive(true);
                characterSelectionUI.SelectAnimalUI(transform.name, index, true);
            }

            Selected(selectedAnimal.name);

            currentSelectedAnimal = selectedAnimal;
            yield return null;
        }
    }
}
