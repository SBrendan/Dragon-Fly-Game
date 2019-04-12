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
    public GameObject GameOver;
    public GameObject Scorer;
    public Vector2 FireballOffset = new Vector2(1.3f, -0.3f);
    public static PlayerController instance;

    // Moving stuff
    //private Vector2 targetPos;
    private Vector2 targetPosYUp;
    private Vector2 targetPosYDown;
    private Vector2 targetPosXRight;
    private Vector2 targetPosXLeft;
    public float Yincrement;
    public float Xincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public float maxX;
    public float minX;
    public bool IsDead = false; 

    // Misc
    public float health = 3f;
    private CamShake shaker;

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

    void Start()
    {
        shaker = GameObject.FindGameObjectWithTag("ShakeManager").GetComponent<CamShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead != true)
        {
            //////////////// SMOOTH AS HELL ////////////////
            targetPosYUp = new Vector2(transform.position.x, transform.position.y + Yincrement);
            targetPosYDown = new Vector2(transform.position.x, transform.position.y - Yincrement);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (targetPosYUp.y > maxHeight)
                {
                    targetPosYUp = new Vector2(transform.position.x, maxHeight);
                }
                transform.position = Vector2.MoveTowards(transform.position, targetPosYUp, speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (targetPosYDown.y < minHeight)
                {
                    targetPosYDown = new Vector2(transform.position.x, minHeight);
                }
                transform.position = Vector2.MoveTowards(transform.position, targetPosYDown, speed * Time.deltaTime);
            }

            targetPosXRight = new Vector2(transform.position.x + Xincrement, transform.position.y);
            targetPosXLeft = new Vector2(transform.position.x - Xincrement, transform.position.y);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (targetPosXRight.x > maxX)
                {
                    targetPosXRight = new Vector2(maxX, transform.position.y);
                }
                transform.position = Vector2.MoveTowards(transform.position, targetPosXRight, speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (targetPosXLeft.x < minX)
                {
                    targetPosXLeft = new Vector2(minX, transform.position.y);
                }
                transform.position = Vector2.MoveTowards(transform.position, targetPosXLeft, speed * Time.deltaTime);
            }

            //////////////// Firing ////////////////
            FireTimer -= Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && FireTimer <= 0f)
            {
                animator.SetBool("IsShooting", true);
                Debug.Log("Fireball shoot!");
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
        if (collision.CompareTag("Enemies"))
        {
            shaker.Shake();
            health -= collision.GetComponent<Enemies>().damage;
            if (health > 0f)
            {
                animator.SetTrigger("TakeDamage");
            }
            else
            {
                animator.SetTrigger("IsDead");
                IsDead = true;
                Destroy(this.Scorer);
                Debug.Log("PAN T MOR");
                Invoke("RenderGameOver", 4);
                Destroy(gameObject, 4f);
            }
        }
    }

    private void RenderGameOver()
    {
        GameOver.SetActive(true);
    }
}