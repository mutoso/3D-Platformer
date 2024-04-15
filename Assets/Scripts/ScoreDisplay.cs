using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMP_Text>().text = "Final Score: " + playerStats.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
