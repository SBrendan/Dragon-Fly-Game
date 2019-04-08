﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemies : MonoBehaviour
{
    public float speed = 7f;
    public float health = 3f;
    public GameObject Explosion;
    public float damage;
    public float avoid_point = 1f;
    public float destruct_point = 3f;
    private GameObject PlayerAnimator;

    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (health <= 0f)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("Scorer").GetComponent<Scorer>().Score += destruct_point;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
