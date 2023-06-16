using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
   // float speed = 2;
    Vector2 dir = Vector2.up;

   
    void Start()
    {

    }
    void FixedUpdate()
    {
        //var knifePoint = Camera.main.WorldToScreenPoint(transform.position);
        transform.Translate(dir * Time.deltaTime * GameManager.Instance.playerKnifeSpeed);
      //  if (knifePoint.y > Screen.height) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.count += 10;
            EventManager.AddToScore();
            EventManager.AddCoin();
            
        }
        else if(collision.CompareTag("Boss"))
        {
            Destroy(gameObject);
            EventManager.BossHit();
            GameManager.Instance.count += 50;
            EventManager.AddToScore();


        }
       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



}
