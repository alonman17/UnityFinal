using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    public static string difficulty = "easy";
    public static float currentHealth = 100;
    public static float maxHealth = 100;

    //create a map between the difficulty and the max health
    public static Dictionary<string, float> difficultyHealthMap = new Dictionary<string, float>()
    {
        {"easy", 100},
        {"medium", 200},
        {"hard", 300}
    };

    public static void SetDifficulty(string difficulty)
    {
        PlayerState.difficulty = difficulty;
    }

    public static float getDifficultyHealth()
    {
        return difficultyHealthMap[difficulty];
    }

}
