using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Collider2D myCollider;
    
    public TouchInput myTouch;
    public GameObject knife;
    public Touch firstFinger;
    private int tapCount;

    private GameObject[] coins;



    void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

  
    void Update()
    {
        if(Input.touchCount>0)
        {
            firstFinger = Input.GetTouch(0);
            tapCount = firstFinger.tapCount;
            if (myCollider == Physics2D.OverlapPoint(myTouch.endPos) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (GameObject.FindGameObjectsWithTag("Knife").Length < GameManager.Instance.maxKnifeOnScreen)
                    KnifeThrow();
            }
            switch (firstFinger.phase)
            {
                case TouchPhase.Began:
                    

                    break;
                case TouchPhase.Moved:
                    

                    break;
                case TouchPhase.Ended:
                   


                    if (tapCount == 2)
                    {
                        if(GameManager.Instance.coins == 3)
                         DoubleTap();
                    }

                    break;
            }
           
        }
     
    }
    
    void KnifeThrow()
    {
            Instantiate(knife, transform.position+ new Vector3(0, 0.8f, 0), Quaternion.Euler(0, 0, 0));
    }
    void DoubleTap()
    {
        var playerPoint = Camera.main.WorldToScreenPoint(transform.position);
        float dist = Vector3.Distance(firstFinger.position, playerPoint);
        if(dist<150)
        {
            for (int i = -2; i < 3; i++)
            {
                Instantiate(knife, transform.position + new Vector3(i * 0.5f, 0.8f, 0), Quaternion.Euler(0, 0, 0));
            }

            GameManager.Instance.coins = 0;
            coins = GameObject.FindGameObjectsWithTag("Coin");
            foreach (GameObject coin in coins) GameObject.Destroy(coin);
        }

       

    }


}
