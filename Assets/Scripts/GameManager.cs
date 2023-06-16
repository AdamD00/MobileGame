using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float smallMonsterSpeed = 2f;
    public float bossSpeed = 2f;
    public int playerKnifeSpeed = 5;
   

    public int minSpawnMonsterRate = 2;
    public int maxSpawnMonsterRate = 6;

    public int minSpawnKnifeRate = 5;
    public int maxSpawnKnifeRate = 10;

    public int maxKnifeOnScreen = 1;
    public int count = 0;
    public int coins = 0;
    public int bossLife = 6;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    void BossCondition()
    {
       
            bossLife--;
            if (bossLife == 0)
            {
            GameManager.Instance.count += 1000;
            EventManager.AddToScore();
            EventManager.EndGame();
            Time.timeScale = 0;
            }
        }
      
       

    
    void PlayerCondition()
    {
        EventManager.EndGame();
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        EventManager.BossHitEvent += BossCondition;
        EventManager.PlayerHitEvent += PlayerCondition;
    }

    private void OnDisable()
    {
        EventManager.BossHitEvent -= BossCondition;
        EventManager.PlayerHitEvent -= PlayerCondition;
    }
    public void RestarGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    




}
