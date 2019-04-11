using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI FinalScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FinalScoreDisplay.text = Scorer.instance.GetScore().ToString();
        Debug.Log(Scorer.instance.GetScore());
    }
}
