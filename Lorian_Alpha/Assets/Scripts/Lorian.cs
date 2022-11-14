using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lorian : MonoBehaviour
{
    public int health, maxHP, sword, amulet, coolDown;
    public float moveSpeed, amuletTimer, spinningTime;
    /*public Transform waveRightDirection;
    public Transform waveLeftDirection;
    public Transform waveUpDirection;
    public Transform waveDownDirection;*/
    //public GameObject Wave;
    public List<GameObject> hearts = new List<GameObject>();
    public Transform heartContainers;
    public GameObject amuletHud;
    public Slider amuletBar;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    Vector2 movement;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        amuletTimer += Time.deltaTime;
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        AnimationUpdate();
        UpdateMana();
        //PowerDirection();
    }

    private void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
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

        if(Input.GetButtonDown("Fire2") && amulet != 0 && amuletTimer > coolDown)
        {
            anim.SetBool("OnPower", true);
            amuletTimer -= amuletTimer;

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
        else
        {
            anim.SetBool("OnCharge", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Elevator portal = collision.GetComponent<Elevator>();

        if(collision.CompareTag("Elevator"))
        {
            anim.SetBool("OnSpin", true);
            StartCoroutine(SpinningCo(portal));
        }
    }

    private IEnumerator SpinningCo(Elevator portal)
    {
        if(portal)
        {
            yield return new WaitForSeconds(spinningTime);
            anim.SetBool("OnSpin", false);
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

    //Borrar junto con el script de Sword? No hace falta si lo obtiene del cofre
    /*public void TakeSword(int num) 
    {
        sword += num;
    }*/

    public void TakeAmulet(int num)
    {
        amulet += num;

        if(amulet > 0)
        {
            amuletHud.SetActive(true);
        }
    }

    public void TakeHeart(int num)
    {
        health += num;
        UpdateHP(health);
    }

    public void TakeDamage(int dmg)
    {
        anim.SetTrigger("Damage");
        health -= dmg;
        UpdateHP(health);
        if(health <= 0)
        {
            anim.SetBool("OnDying", true);
        }
    }

    public void Dying()
    {
        this.gameObject.SetActive(false);
    }

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

    public void UpdateMana()
    {
        amuletBar.value = (float)amuletTimer / coolDown;
    }
}
