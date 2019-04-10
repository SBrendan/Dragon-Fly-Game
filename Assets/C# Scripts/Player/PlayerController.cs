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
            /* //////////////// OLD MOVEMENT ////////////////
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            var keyAlreadyPressed = false;
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < maxHeight && keyAlreadyPressed != true)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                keyAlreadyPressed = true;
                Debug.Log(keyAlreadyPressed);
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
            */

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