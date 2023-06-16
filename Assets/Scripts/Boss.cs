using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject smallMonster;
    private float targetTime =2 ;
    Vector2 dir;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        speed = GameManager.Instance.bossSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
        //var x = Random.Range(0, GameManager.Instance.spawnMonsterRate);
        //if(x == 6)
        //{
        //    SpawnMonster();
        //}
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            SpawnMonster();
            targetTime = Random.Range(GameManager.Instance.minSpawnMonsterRate, GameManager.Instance.maxSpawnMonsterRate);
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            speed = Random.Range(0.5f, 3.0f);
            transform.Rotate(0, 180, 0);
        }
    }
    void SpawnMonster()
    {
        Instantiate(smallMonster, transform.position, Quaternion.identity);
    }
    
}
