using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class Scorer : MonoBehaviour
{
    public float Score = 0f;
    public TextMeshProUGUI  ScoreDisplay;
    public static Scorer instance;
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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemies"))
        {
            Score += collision.GetComponent<Ennemies>().avoid_point;
        // Debug.Log("Score : " + Score.ToString());
        }
    }

    public float GetScore()
    {
        return Score;
    }
}
