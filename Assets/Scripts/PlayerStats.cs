using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int health = 100;
    public int score = 0;

    void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        health = 100;
        score = 0;
    }
}