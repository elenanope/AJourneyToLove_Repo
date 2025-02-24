using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) Debug.Log("GameManager is missing!");
            return instance;
        }
    }

    public int chocolate;
    public int memories;
    public enum GameState { gameOver, gameStarted, gamePaused, gameCompleted }
    public GameState currentGameState = GameState.gameStarted;
    //poner variable pickUp coleccionable y aparte chocolate


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

}
