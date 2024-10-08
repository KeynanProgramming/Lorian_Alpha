using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, damage;
    public float moveSpeed,  timer, idleTime, moveTime, chaseRadius, attackRadius, limitRadius;
    public string enemyDamageSFX, enemyAttackSFX, enemyStunedSFX;
    public List<Transform> points;
    public Transform target;

    private int currentPoint = 0;
    private Animator anim;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        GameManager.instance.enemies.Add(this);
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
        if(Vector2.Distance(target.position, transform.position) <= chaseRadius)
        {
            Vector3 dir = target.position - transform.position;
            dir.z = 0;
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;
            anim.SetBool("OnIdle", false);

            if(Vector2.Distance(target.position, transform.position) < attackRadius)
            {
                anim.SetTrigger("OnRange");
            }

            if (dir.x > 0)
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

    void EnemyAttackSFX()
    {
        AudioManager.instance.PlaySound(enemyAttackSFX);
    }

    public void TakeDamage(int dmg)
    {
        AudioManager.instance.PlaySound(enemyDamageSFX);
        anim.SetTrigger("Damage");
        health -= dmg;

        if(health <= 0)
        {
            anim.SetBool("OnDying", true);
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "Enemy" && collision.CompareTag("Statue"))
        {
            anim.SetTrigger("Stuned"); 
            AudioManager.instance.PlaySound(enemyStunedSFX);
        }

        if(this.gameObject.tag == "Bat" && collision.CompareTag("Statue"))
        {
            TakeDamage(1);
        }
    }

    public void Dying()
    {
        AudioManager.instance.PlaySound(enemyDamageSFX);
        StartCoroutine(DyingCo());
    }

    private IEnumerator DyingCo()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.enemies.Remove(this);
        GameManager.instance.ActivateMural();
        this.gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.DrawWireSphere(transform.position, limitRadius);

    }
}
