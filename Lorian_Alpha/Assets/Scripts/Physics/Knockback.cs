using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public int damage;
    public float thrust, knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();

            if(hit != null)
            {
                if(collision.gameObject.CompareTag("Enemy"))
                {
                    hit.isKinematic = false;
                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);
                    hit.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                    StartCoroutine(EnemyKnockCo(hit));
                }

                if(collision.gameObject.CompareTag("Player"))
                {
                    Vector2 difference = hit.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    hit.AddForce(difference, ForceMode2D.Impulse);
                    hit.gameObject.GetComponent<Lorian>().TakeDamage(damage);
                    StartCoroutine(PlayerKnockCo(hit));
                }
            }
        }
    }

    private IEnumerator EnemyKnockCo(Rigidbody2D hit)
    {
        if(hit != null)
        {
            yield return new WaitForSeconds(knockTime);
            hit.velocity = Vector2.zero;
            hit.isKinematic = true;
        }
    }

    private IEnumerator PlayerKnockCo(Rigidbody2D hit)
    {
        if(hit != null)
        {
            yield return new WaitForSeconds(knockTime);
            hit.velocity = Vector2.zero;
        }
    }
}
