using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, damage;
    public float moveSpeed, timer, idleTime, moveTime;
    public float detectionRange, attackRange;
    public List<Transform> points;
    public Transform target, homePosition;

    private int currentPoint = 0;
    private Animator anim;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckDistance();
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
        if(Vector2.Distance(target.position, transform.position) < detectionRange)
        {
            Vector3 dir = target.position - transform.position;
            dir.z = 0;
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;
            anim.SetBool("OnIdle", false);

            if(Vector2.Distance(target.position, transform.position) < attackRange)
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Lorian player = collision.gameObject.GetComponent<Lorian>();

        if (player)
        {
            player.TakeDamage(damage);
        }
    }

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
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
