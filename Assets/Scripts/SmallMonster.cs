using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMonster : MonoBehaviour
{
    Vector2 dir;
    float distance = 0.5f;
    float speed, targetTime = 5;
    public GameObject knife;
    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        speed = GameManager.Instance.smallMonsterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
        //var x = Random.Range(0, GameManager.Instance.spawnKnifeRate);
        //if (x == 6)
        //{
        //    KnifeThrow();
        //}
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            KnifeThrow();
            targetTime = Random.Range(GameManager.Instance.minSpawnKnifeRate, GameManager.Instance.maxSpawnKnifeRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.position = (transform.position + (Vector3.down*distance));
            //dir *= -1;
            transform.Rotate(0, 180, 0);
            
        }
    }

    void KnifeThrow()
    {
        Instantiate(knife, transform.position, Quaternion.Euler(180, 0, 0));
    }
}
