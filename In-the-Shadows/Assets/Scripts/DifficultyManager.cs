using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    public int difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        difficulty = 0;
    }

    public void ChangeDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
    }
}
