using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndConditionTracker : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.score >= 5)
        {
            SceneManager.LoadScene("Victory");
        }
        else if (playerStats.health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
