using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject heartObj;
    public GameObject heartParent;
    public GameObject CoinObj;
    public GameObject CoinParent;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public TextMeshProUGUI scoreText;

    private GameObject[] hearts;
    private int i;
    public static bool half = false;

    public GameObject endPanel;

    private void OnEnable()
    {
        EventManager.BossHitEvent += DisableHearts;
        EventManager.EndGameEvent += EndGame;
        EventManager.AddToScoreEvent += ScoreUpdate;
        EventManager.AddCoinEvent += AddCoin;
    }

    private void OnDisable()
    {
        EventManager.BossHitEvent -= DisableHearts;
        EventManager.EndGameEvent -= EndGame;
        EventManager.AddToScoreEvent -= ScoreUpdate;
        EventManager.AddCoinEvent -= AddCoin;
    }



    void Start()
    {
        int heartsCount = (GameManager.Instance.bossLife)/2;
        for (int i =1; i < heartsCount; i++)
        {
            Instantiate(heartObj, heartParent.transform);
          
        }
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        i = hearts.Length - 1;

    }
    void DisableHearts()
    {
        if(half)
        {
            hearts[i].GetComponent<Image>().sprite = emptyHeart;
            i--;
            half = false;
        }
        else
        {
            hearts[i].GetComponent<Image>().sprite = halfHeart;
            half = true;
        }
       
    }
    void AddCoin()
    {
        if(GameManager.Instance.coins<3)
        {
            Instantiate(CoinObj, CoinParent.transform);
            GameManager.Instance.coins++;
        }
        
    }
    void EndGame() => endPanel.SetActive(true); 
    private void ScoreUpdate() => scoreText.text = "Score: " + GameManager.Instance.count.ToString();


}
