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
    int rolledDieP1;
    int rolledDieP2;
    string playerTurn;
    string otherPlayerTurn;


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
        rolledDieP1 = 0;
        rolledDieP2 = 0;
    }


    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (state)
        {
            case GameState.RollDice:
                rolledDieP1 = 0;
                rolledDieP2 = 0;
                canRollP1 = true;
                canRollP2 = true;
                playerTurn = "";
                targetCam = "TopCamera";

                break;
            case GameState.PlayerTurn:
                targetCam = playerTurn;
                break;
            case GameState.OtherPlayerTurn:
                targetCam = otherPlayerTurn;
                break;
        }
    }

    public GameState GetState()
    {
        return state;
    }

    public string ChangeCameraTarget()
    {
        return targetCam;
    }

    public bool CheckTurn(string playerName)
    {
        if ((playerTurn == playerName && state == GameState.PlayerTurn) ||
        (otherPlayerTurn == playerName && state == GameState.OtherPlayerTurn))
        {
            return true;
        }
        else
        {
            return false;
        }
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
        }
        else if (playerDice == "RollDiceP2")
        {
            rolledDieP2 = diceNumber;
        }

        if (rolledDieP2 != 0f && rolledDieP1 != 0f)
        {
            if (rolledDieP1 > rolledDieP2)
            {
                playerTurn = "Player1";
                otherPlayerTurn = "Player2";
            }
            else
            {
                playerTurn = "Player2";
                otherPlayerTurn = "Player1";
            }
            UpdateGameState(GameState.PlayerTurn);
        }
    }

    public int GetTurnDuration(string playerName)
    {
        int duration = 0;
        if (playerName == "Player1")
        {
            duration = rolledDieP1 * 15;

        }
        else if (playerName == "Player2")
        {
            duration = rolledDieP2 * 15;
        }
        Debug.Log(duration);
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
