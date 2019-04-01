using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float FireDelay = 0.6f;
    float FireTimer;
    public GameObject Fireball;
    public Vector2 FireballOffset = new Vector2(1.3f, -0.3f);
    private Vector2 targetPos;
    public float Yincrement;
    public float Xincrement;

    private void Start()
    {
        MainMenuController mainMenu = GameObject.Find("GameMenu").GetComponent<MainMenuController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPos = new Vector2(transform.position.x + Xincrement, transform.position.y);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            targetPos = new Vector2(transform.position.x - Xincrement, transform.position.y - Yincrement);
            transform.position = targetPos;
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
