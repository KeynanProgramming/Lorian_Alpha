using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lorian : MonoBehaviour
{
    public int health, maxHP, damage, sword, emblem;
    public float moveSpeed;
    /*public Transform waveRightDirection;
    public Transform waveLeftDirection;
    public Transform waveUpDirection;
    public Transform waveDownDirection;*/
    public GameObject Wave;
    public List<GameObject> hearts = new List<GameObject>();
    public Transform heartContainers;
    private Rigidbody2D myRigidBody2D;
    private Animator anim;
    Vector2 movement;
    
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        AnimationUpdate();
        //PowerDirection();
    }

    private void FixedUpdate()
    {
        myRigidBody2D.MovePosition(myRigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void AnimationUpdate()
    {
        if(movement != Vector2.zero)
        {
            anim.SetFloat("moveX", movement.x);
            anim.SetFloat("moveY", movement.y);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }

        if(Input.GetButtonDown("Fire1") && sword != 0)
        {
            anim.SetTrigger("OnAttack");
        }

        if(Input.GetButtonDown("Fire2") && emblem != 0)
        {
            anim.SetBool("OnPower", true);

            /*if(movement.x == 1)
            {
                Instantiate(Wave, waveRightDirection.position, waveRightDirection.rotation);
            }

            if (movement.x == -1)
            {
                Instantiate(Wave, waveLeftDirection.position, waveLeftDirection.rotation);
            }

            if (movement.y == 1)
            {
                Instantiate(Wave, waveUpDirection.position, waveUpDirection.rotation);
            }

            if (movement.y == -1)
            {
                Instantiate(Wave, waveDownDirection.position, waveDownDirection.rotation);
            }*/
        }
        else
        {
            anim.SetBool("OnPower", false);
        }

        if(Input.GetButton("Fire2"))
        {
            anim.SetBool("OnCharge", true);
        }
        
        if(Input.GetButtonUp("Fire2"))
        {
            anim.SetBool("OnCharge", false);
        }
    }

    /*void PowerDirection()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            waveRightDirection.right = Vector2.right;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            
            waveLeftDirection.right = Vector2.left;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            waveUpDirection.right = Vector2.up;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            waveDownDirection.right = Vector2.down;
        }
    }*/

    public void TakeSword(int num)
    {
        sword += num;
    }

    public void TakeEmblem(int num)
    {
        emblem += num;
    }

    public bool TakeDamage(int dmg)
    {
        if(health - dmg > maxHP)
        {
            return false;
        }

        anim.SetTrigger("Damage");
        health -= dmg;
        UpdateHP(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
            //anim.SetBool("OnDying", true);
        }

        return true;
    }

    /*public void Dying()
    {
        this.gameObject.SetActive(false);
    }*/

    public void UpdateHP(int newHP)
    {
        for(int i = 0; i < newHP; i++)
        {
            if(i < hearts.Count)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                GameObject newHeart = Instantiate(hearts[0], heartContainers);
                newHeart.SetActive(true);
                hearts.Add(newHeart);
            }
        }

        for(int i = newHP; i < hearts.Count; i++)
        {
            hearts[i].SetActive(false);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(Input.GetButtonDown("Fire1") && sword != 0)
            {
                enemy.TakeDamage(damage);
            }
        }
    }*/
}
