using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public static GameManager Instance;
    public float timeToSetBallFree = 1f;
    public StateMachine stateMachine;
    public Player[] players;


    [Header("Menus")]
    public GameObject uiMainMenu;

    public bool gameRunning = false;

    private void Awake()
    {
        Instance = this; 

        players = FindObjectsOfType<Player>(); //menos otimizado. Ideal é referenciar manualmente na Unity
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        if(gameRunning)
        {
            ballBase.CanMove(true);
        }
    }

    public void startGame()
    {
        ballBase.CanMove(true);
        gameRunning = true;
    }

    public void EndGame()
    {
        ballBase.ResetBall();
        gameRunning = false;
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }

    public void ShowMainMenu()
    {
        ballBase.CanMove(false);
        uiMainMenu.SetActive(true);
    }
}
