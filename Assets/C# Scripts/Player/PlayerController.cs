using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Shooting stuff
    public Animator animator;
    public float FireDelay = 0.6f;
    float FireTimer;
    public GameObject Fireball;
    public Vector2 FireballOffset = new Vector2(1.3f, -0.3f);
    public static PlayerController instance;

    // Moving stuff
    private Vector2 targetPos;
    public float Yincrement;
    public float Xincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public bool IsDead = false; 

    // Misc
    public float health = 3f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (IsDead != true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
            }

            FireTimer -= Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && FireTimer <= 0f)
            {
                animator.SetBool("IsShooting", true);
                Debug.Log("BIM!");
                Instantiate(Fireball, new Vector2(transform.position.x + FireballOffset.x, transform.position.y + FireballOffset.y), Quaternion.identity);
                FireTimer = FireDelay;
            }
            else
            {
                animator.SetBool("IsShooting", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemies"))
        {
            health -= collision.GetComponent<Ennemies>().damage;
            if (health > 0f)
            {
                animator.SetTrigger("TakeDamage");
            }
            else
            {
                animator.SetTrigger("IsDead");
                IsDead = true;
                Debug.Log("PAN T MOR");
                Destroy(gameObject, 4f);
            }
        }
    }
}
