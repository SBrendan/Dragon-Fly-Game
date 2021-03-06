﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 8f;
    public float health = 1f;
    public float damage = 1f;
    private Vector2 MoveRight;
    public GameObject Explosion;
    public GameObject Particles;

    // Update is called once per frame
    void Update()
    {
        MoveRight = new Vector2(transform.position.x + 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, MoveRight, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            Debug.Log("Fireball hit an enemy!");
            collision.GetComponent<Enemies>().health -= damage;
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Instantiate(Particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
