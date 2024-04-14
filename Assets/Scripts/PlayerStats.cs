using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int health = 100;
    public int score = 0;
}
