using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lorian : MonoBehaviour
{
    public int health, maxHP, sword, amulet, coolDown;
    public float heroSpeed, amuletTimer, spinningTime;
    public List<GameObject> hearts = new List<GameObject>();
    public Transform heartContainers;
    public GameObject amuletHud, fadeToBlack;
    public Slider amuletBar;
    public AudioClip sonido;
    private AudioSource audioSource;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Vector2 movement;
    public Elevator portal;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        amuletTimer += Time.deltaTime;
        AnimationUpdate();
        movement = Vector2.zero;       
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.GetSceneByBuildIndex(0);
        }
        
        UpdateMana();
    }

    private void FixedUpdate()
    {
        
        myRigidbody.MovePosition(myRigidbody.position + heroSpeed * Time.fixedDeltaTime * movement);
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        portal = collision.GetComponent<Elevator>();      
    }
   public void SpinAnim()
    {
        
        anim.SetBool("OnSpin", true);
        StartCoroutine(SpinningCo(portal));
    }

    private IEnumerator SpinningCo(Elevator portal)
    {
        if(portal)
        {
            yield return new WaitForSeconds(spinningTime);
            anim.SetBool("OnSpin", false);
        }
    }

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
        anim.SetBool("OnDying", false);
        StartCoroutine(DeathFadeCo());
    }

    private IEnumerator DeathFadeCo()
    {
        yield return new WaitForSeconds(1.5f);

        if(fadeToBlack != null)
        {
            GameObject panelToBlack = Instantiate(fadeToBlack, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(0);
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
        amuletBar.value = amuletTimer / coolDown;
    }
}
