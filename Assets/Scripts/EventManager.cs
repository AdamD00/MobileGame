using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static Action BossHitEvent;
    public static Action EndGameEvent;
    public static Action PlayerHitEvent;
    public static Action AddToScoreEvent;
    public static Action AddCoinEvent;

    public static void BossHit()
    {
        BossHitEvent?.Invoke();
    }
    public static void EndGame()
    {
        EndGameEvent?.Invoke();
    }
    public static void PlayerHit()
    {
        PlayerHitEvent?.Invoke();
    }
    public static void AddToScore()
    {
        AddToScoreEvent?.Invoke();
    }
    public static void AddCoin()
    {
        AddCoinEvent?.Invoke();
    }

    
    

    
}
    