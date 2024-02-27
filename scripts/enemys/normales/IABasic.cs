using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasic : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;

    private float waitTime;

    public Transform[] movePots;
    public float startWaitTime = 2;

    private int i = 0;

    private Vector2 actualPosi;
    
    
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(CheckEnemyMoving());
        
        transform.position = Vector2.MoveTowards(
            transform.position
            ,movePots[i].transform.position,
            speed * Time.deltaTime
            );


        if (Vector2.Distance(transform.position, movePots[i].transform.position) < 0.1f)
        {
            if (waitTime <=0)
            {
                if (movePots[i] != movePots[movePots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPosi = transform.position;

        yield return new WaitForSeconds(0.5f);


        if (transform.position.x > actualPosi.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("idle",false);
        }
        else if (transform.position.x<actualPosi.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("idle",false);
        }
            else if (transform.position.x==actualPosi.x)
            {
                animator.SetBool("idle",true);
            }
    }
}
