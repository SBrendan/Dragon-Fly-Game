using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstacle;
    public float TimeBetweenSpawn = 1f;
    public float StartTime = 1f;
    float increment;
    float[] possible_values = new float[3];

    void Start()
    {
        increment = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Yincrement;
        possible_values[0] = increment * -1;
        possible_values[1] = 0f;
        possible_values[2] = increment;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeBetweenSpawn <= 0f)
        {
            Debug.Log("Spawnage");
            int rand = Random.Range(0, possible_values.Length);
            Instantiate(obstacle, new Vector2(transform.position.x, transform.position.y + possible_values[rand]), Quaternion.identity);
            //Instantiate(obstacle);
            TimeBetweenSpawn = StartTime;
        } else
        {
            TimeBetweenSpawn -= Time.deltaTime;
        }
    }
}
