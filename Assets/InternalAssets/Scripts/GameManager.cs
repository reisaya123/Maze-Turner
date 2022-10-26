using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    int sceneNum;

    public bool canRollP1;
    public bool canRollP2;
    public string targetCam;
    string player1SelectedAnimal;
    string player2SelectedAnimal;
    bool readyPlayer1;
    bool readyPlayer2;
    float rolledDieP1;
    float rolledDieP2;


    public enum GameState
    {
        RollDice,
        PlayerTurn,
        OtherPlayerTurn,
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sceneNum = 0;
        readyPlayer1 = false;
        readyPlayer2 = false;
        rolledDieP1 = 0f;
        rolledDieP2 = 0f;
    }


    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (state)
        {
            case GameState.RollDice:
                rolledDieP1 = 0f;
                rolledDieP2 = 0f;
                canRollP1 = true;
                canRollP2 = true;
                targetCam = "TopCamera";

                break;
            case GameState.PlayerTurn:
                //get bool isTurn
                //get roll die value → convert to time
                // send player target to camera script
                break;
            case GameState.OtherPlayerTurn:
                //get bool isTurn
                //get roll die value → convert to time
                // send player target to camera script
                break;
        }
    }

    public GameState GetState()
    {
        return state;
    }

    public bool GetCanRoll(string playerDice)
    {
        bool canRoll = false;
        if (playerDice == "RollDiceP1")
        {
            canRoll = canRollP1;
        }
        else if (playerDice == "RollDiceP2")
        {
            canRoll = canRollP2;
        }
        return canRoll;

    }

    public void CompareRollDie(int diceNumber, string playerDice)
    {
        if (playerDice == "RollDiceP1")
        {
            rolledDieP1 = diceNumber;
            if (rolledDieP2 != 0f)
            {

            }

        }
        else if (playerDice == "RollDiceP2")
        {
            rolledDieP2 = diceNumber;
            if (rolledDieP1 != 0f)
            {

            }

        }
    }

    public float GetTurnDuration(int diceNumber)
    {
        int duration = diceNumber * 10;
        return duration;
    }

    public void NextScene()
    {
        sceneNum++;

        SceneManager.LoadScene(sceneNum);
    }

    public void ReadyPlayer1(string animalName)
    {
        player1SelectedAnimal = animalName;
        readyPlayer1 = true;
        if (readyPlayer1 && readyPlayer2)
        {
            UpdateGameState(GameState.RollDice);
            NextScene();
        }
    }

    public void ReadyPlayer2(string animalName)
    {
        player2SelectedAnimal = animalName;
        readyPlayer2 = true;
        if (readyPlayer1 && readyPlayer2)
        {
            UpdateGameState(GameState.RollDice);
            NextScene();
        }
    }


    public void InstantiatePlayerAndCam(List<GameObject> animalModels, GameObject mainCam)
    {
        GameObject cam = Instantiate(mainCam);

        foreach (var model in animalModels)
        {

            if (model.name.ToUpper() == ($"{player1SelectedAnimal}Model").ToUpper())
            {
                GameObject player1Animal = Instantiate(model);
                player1Animal.AddComponent<Player>();
                player1Animal.GetComponent<Player>().playerName = "Player1";
                player1Animal.name = "Player1";

                cam.GetComponent<CameraMovement>().targets.Add(player1Animal);
            }

            if (model.name.ToUpper() == ($"{player2SelectedAnimal}Model").ToUpper())
            {

                GameObject player2Animal = Instantiate(model);
                player2Animal.AddComponent<Player>();
                player2Animal.GetComponent<Player>().playerName = "Player2";
                player2Animal.name = "Player2";

                cam.GetComponent<CameraMovement>().targets.Add(player2Animal);
            }
        }
    }

}
