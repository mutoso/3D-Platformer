using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMP_Text>().text = "Health: " + playerStats.health;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TMP_Text>().text = "Health: " + playerStats.health;
    }
}
