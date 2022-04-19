using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 1.0f;

    private float waitTime;

    public float startWaitTime = 1;
    
    private int i = 0;

    private Vector2 actualPos;

    public Transform[] moveSpots;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;    
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckenemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (waitTime <= 0)
        {
            if (moveSpots[i]!= moveSpots[moveSpots.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }

            waitTime = startWaitTime;
        } else
        {
            waitTime -= Time.deltaTime;
        }

    }

    IEnumerator CheckenemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
        } 
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
