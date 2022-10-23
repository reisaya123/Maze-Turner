using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public GameState state;
    RollDice rollDice;
    int sceneNum;
    string player1SelectedAnimal;
    string player2SelectedAnimal;
    bool readyPlayer1;
    bool readyPlayer2;

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

    // private void update()
    // {
    //     switch (state)
    //     {
    //         case GameState.RollDice:
    //             if (Input.GetKey(KeyCode.Space))
    //             {
    //                 rollDice.Rolling();

    //             }
    //             break;
    //         case GameState.PlayerTurn:
    //             break;
    //         case GameState.OtherPlayerTurn:
    //             break;
    //     }
    // }

    // public enum GameState
    // {
    //     RollDice,
    //     PlayerTurn,
    //     OtherPlayerTurn,
    // }

    private void Start()
    {
        sceneNum = 0;
        readyPlayer1 = false;
        readyPlayer2 = false;
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
            NextScene();
        }
    }

    public void ReadyPlayer2(string animalName)
    {
        player2SelectedAnimal = animalName;
        readyPlayer2 = true;
        if (readyPlayer1 && readyPlayer2)
        {
            NextScene();
        }
    }

    public void InstantiatePlayerAnimals(List<GameObject> animalModels)
    {
        foreach (var model in animalModels)
        {
            Debug.Log(model.name);
            if (model.name == ($"{player1SelectedAnimal}Model"))
            {
                GameObject player1 = Instantiate(new GameObject("Player1"));
                GameObject player1Animal = Instantiate(model);
                player1Animal.transform.parent = player1.transform;
                player1Animal.name = player1SelectedAnimal;
            }
            else if (model.name == ($"{player2SelectedAnimal}Model"))
            {
                GameObject player2Animal = Instantiate(model);
                player2Animal.name = player2SelectedAnimal;
            }
        }
    }

}
