using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeMonster : MonoBehaviour
{
    float speed = 2;
    Vector2 dir = Vector2.up;

   
    void Start()
    {

    }
    void FixedUpdate()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject);
            EventManager.PlayerHit();
        }
       
       
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   

}
