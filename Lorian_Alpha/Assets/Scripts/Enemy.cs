using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, damage;
    public float moveSpeed, timer, idleTime, moveTime;
    public float chaseRadius, attackRadius;
    public List<Transform> points;
    public Transform target;

    private int currentPoint = 0;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        IdleTimer();
        CheckDistance();
    }

    void IdleTimer()
    {
        timer += Time.deltaTime;

        if (timer > idleTime)
        {
            anim.SetBool("OnIdle", true);
        }

        if (timer > moveTime)
        {
            anim.SetBool("OnIdle", false);
            timer -= moveTime;
        }
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            myRigidbody.MovePosition(temp);
        }

        /*if(Vector2.Distance(target.position, transform.position) <= chaseRadius
            && Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 dir = target.position - transform.position;
            dir.z = 0;
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;
            anim.SetBool("OnIdle", false);

            if(Vector2.Distance(target.position, transform.position) < attackRadius)
            {
                anim.SetBool("OnRange", true);
            }
            else
            {
                anim.SetBool("OnRange", false);
            }

            if(dir.x > 0)
            {
                transform.right = Vector3.right;
            }
            else
            {
                transform.right = Vector3.left;
            }
        }
        else
        {
            if(Vector2.Distance(points[currentPoint].position, transform.position) > 0.2f)
            {
                Vector3 dir = points[currentPoint].position - transform.position;
                dir.z = 0;
                dir.Normalize();
                transform.position += dir * moveSpeed * Time.deltaTime;

                if(dir.x > 0)
                {
                    transform.right = Vector3.right;
                }
                else
                {
                    transform.right = Vector3.left;
                }
            }
            else
            {
                currentPoint++;
                if(currentPoint >= points.Count)
                {
                    currentPoint = 0;
                }
            }
        }*/
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponentInParent<Lorian>();

        if (player)
        {
            player.TakeDamage(damage);
        }
    }*/

    public void TakeDamage(int dmg)
    {
        anim.SetTrigger("Damage");
        health -= dmg;

        if(health <= 0)
        {
            anim.SetBool("OnDying", true);
        }
    }

    public void Dying()
    {
        this.gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
