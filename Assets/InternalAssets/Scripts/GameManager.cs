using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
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

    private void update()
    {
        switch (state)
        {
            case GameState.RollDice:
                if (Input.GetKey(KeyCode.Space))
                {
                    rollDice.Rolling();
                }
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.OtherPlayerTurn:
                break;
        }
    }

    public enum GameState
    {
        RollDice,
        PlayerTurn,
        OtherPlayerTurn,
    }

    public float GetTurnDuration(int diceNumber){
        int duration = diceNumber * 10;
        return duration;
    }

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

            if (model.name.ToUpper() == ($"{player1SelectedAnimal}Model").ToUpper())
            {
                GameObject player1Animal = Instantiate(model);
                player1Animal.AddComponent<Player>();
                player1Animal.GetComponent<Player>().playerName = "Player1";
                player1Animal.name = "Player1";
            }

            if (model.name.ToUpper() == ($"{player2SelectedAnimal}Model").ToUpper())
            {

                GameObject player2Animal = Instantiate(model);
                player2Animal.AddComponent<Player>();
                player2Animal.GetComponent<Player>().playerName = "Player2";
                player2Animal.name = "Player2";
            }
        }
    }

}
