using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFireball : MonoBehaviour
{
    public float Speed = 8f;
    private Vector2 MoveRight;

    // Update is called once per frame
    void Update()
    {
        MoveRight = new Vector2(transform.position.x + 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, MoveRight, Speed * Time.deltaTime);
    }
}
