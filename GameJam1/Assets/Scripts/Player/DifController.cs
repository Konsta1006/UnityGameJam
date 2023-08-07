using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifController : MonoBehaviour
{
    public void SetDifficulty(float lvl)
    {
        DifficultyLevel.difficulyLevel = lvl;
    }
}
