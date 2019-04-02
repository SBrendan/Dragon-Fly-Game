using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 8f;
    public float health = 1f;
    public float damage = 1f;
    private Vector2 MoveRight;

    // Update is called once per frame
    void Update()
    {
        MoveRight = new Vector2(transform.position.x + 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, MoveRight, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().health -= damage;
            Destroy(gameObject);
            Debug.Log("OWNED!!!!!");
        } else if (collision.CompareTag("Ennemies"))
        {
            collision.GetComponent<Ennemies>().health -= damage;
            Destroy(gameObject);
        }
    }
}
