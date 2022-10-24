using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectionUI : MonoBehaviour
{
    public Sprite pressToPlayBorder;
    public Sprite characterSelectionBorder;
    public GameObject[] characterSelection;
    Image player1Border;
    TextMeshProUGUI player1BorderText;
    Image player2Border;
    TextMeshProUGUI player2BorderText;
    GameObject player1AnimalsUI;
    GameObject player2AnimalsUI;
    bool player1Pressed = false;
    bool player2Pressed = false;


    void Start()
    {
        player1AnimalsUI = transform.Find("Player1UI").Find("Characters").gameObject;
        player2AnimalsUI = transform.Find("Player2UI").Find("Characters").gameObject;
        player1Border = transform.Find("Player1UI").Find("Player1Border").GetComponent<Image>();
        player2Border = transform.Find("Player2UI").Find("Player2Border").GetComponent<Image>();
        player1BorderText = transform.Find("Player1UI").Find("PressToJoinText").GetComponent<TextMeshProUGUI>();
        player2BorderText = transform.Find("Player2UI").Find("PressToJoinText").GetComponent<TextMeshProUGUI>();
        player1Border.sprite = pressToPlayBorder;
        player2Border.sprite = pressToPlayBorder;
        player1BorderText.enabled = true;
        player2BorderText.enabled = true;
        player1Pressed = false;
        player2Pressed = false;

        StartCoroutine(PressToPlay());
    }

    IEnumerator PressToPlay()
    {
        while (true)
        {
            if (player1Pressed && player2Pressed)
            {
                yield break;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !player1Pressed)
            {
                player1Border.sprite = characterSelectionBorder;
                player1BorderText.enabled = false;

                GameObject player1Selection = Instantiate(characterSelection[0]);
                player1Selection.name = "Player1Selection";
                player1Selection.SetActive(true);

                player1Selection.AddComponent<CharacterSelection>();
                player1Selection.GetComponent<CharacterSelection>().player = "player1";
                player1Selection.GetComponent<CharacterSelection>().characterSelectionUI = transform.GetComponent<CharacterSelectionUI>();
                player1Selection.GetComponent<CharacterSelection>().time = Time.time;
                player1Pressed = true;
            }

            if (Input.GetKeyDown(KeyCode.RightShift) && !player2Pressed)
            {
                player2Border.sprite = characterSelectionBorder;
                player2BorderText.enabled = false;

                GameObject player2Selection = Instantiate(characterSelection[1]);
                player2Selection.name = "Player2Selection";
                player2Selection.SetActive(true);

                player2Selection.AddComponent<CharacterSelection>();
                player2Selection.GetComponent<CharacterSelection>().player = "player2";
                player2Selection.GetComponent<CharacterSelection>().characterSelectionUI = transform.GetComponent<CharacterSelectionUI>();
                player2Selection.GetComponent<CharacterSelection>().time = Time.time;
                player2Pressed = true;
            }
            yield return null;
        }

    }
    public void ReadySelectionUI(string player)
    {
        if (player == "Player1Selection")
        {
            transform.Find("Player1UI").Find("Ready").Find("ReadyButton").GetComponent<Image>().color = new Color32(116, 116, 116, 255);
        }
        else if (player == "Player2Selection")
        {
            transform.Find("Player2UI").Find("Ready").Find("ReadyButton").GetComponent<Image>().color = new Color32(116, 116, 116, 255);
        }
    }

    public void SelectAnimalUI(string player, int index, bool isSelect)
    {

        if (player == "Player1Selection")
        {
            if (isSelect)
            {
                player1AnimalsUI.transform.GetChild(index).GetComponent<Image>().color = new Color32(123, 123, 123, 255);
            }
            else
            {
                player1AnimalsUI.transform.GetChild(index).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }

        }
        else if (player == "Player2Selection")
        {
            if (isSelect)
            {
                player2AnimalsUI.transform.GetChild(index).GetComponent<Image>().color = new Color32(123, 123, 123, 255);
            }
            else
            {
                player2AnimalsUI.transform.GetChild(index).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
