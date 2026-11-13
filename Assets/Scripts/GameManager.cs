using System.Data.SqlTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum State
    {
        WaitingToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waitingToStartTimer = 2f;
    private float gamePlayingTimer = 100f;

    private void Awake()
    {
        state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f) state = State.GamePlaying;
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f) state = State.GameOver;
                break;
            case State.GameOver:
                break;
            
        }
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
}
