using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject player;
    public Touch firstFinger;
    private int tapCount;
    private Vector2 targetPos;
    private Vector2 startPos;
    public Vector2 endPos;
    private Vector2 dir;
    public SpriteRenderer playerSprite;

    public float moveDistance;
    public Animator playerAnimator;
    void Start()
    {
        targetPos = player.transform.position;
    }
    void Update()
    {
        float speed = 2;
        var step = speed * Time.deltaTime;

        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, step);
        float dist = Vector3.Distance(player.transform.position, targetPos);
        playerAnimator.SetFloat("Speed", dist);
        
        //if(player.transform.position.x != targetPos.x) playerAnimator.SetBool("IsMoving", true);
        //else playerAnimator.SetBool("IsMoving", false);
        
        if (Input.touchCount > 0)
        {
            firstFinger = Input.GetTouch(0);
            // print(firstFinger.position);
            tapCount = firstFinger.tapCount;

            dir = (endPos - startPos).normalized;

            switch (firstFinger.phase)
            {
                case TouchPhase.Began:
                    startPos = Camera.main.ScreenToWorldPoint(firstFinger.position);
                    endPos = startPos;
                    MoveDirection();
                    
                    break;
                case TouchPhase.Moved:
                    endPos = Camera.main.ScreenToWorldPoint(firstFinger.position);
                    
                    break;
                case TouchPhase.Ended:
                    // Debug.Log("Ended");
                   // checkSwipe();


                    if (tapCount == 2)
                    {
                       // DoubleTap();
                    }

                    break;
            }




        }
    }

    void MoveDirection()
    {
        var playerPoint = Camera.main.WorldToScreenPoint(player.transform.position);
        float dist = Vector3.Distance(firstFinger.position, playerPoint);
        if(dist > 150)
        {
          
            if (firstFinger.position.x > playerPoint.x)
            {
               
                Move(moveDistance);
                playerSprite.flipX = false;
            }
            else
            {
               
                Move(-moveDistance);
                playerSprite.flipX = true;
            }
        }
        
    }
    private void Move(float offset)
    {
        targetPos = player.transform.position + new Vector3(offset, 0, 0);
       
    }

    void DoubleTap()
    {
        
        Vector2 newPos = Camera.main.ScreenToWorldPoint(firstFinger.position);
        player.transform.position = newPos;

    }
    void checkSwipe()
    {
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
               
                Move(moveDistance * 2);
            }
            else
            {
                
                Move(-moveDistance * 2);
            }
        }

    }
}
