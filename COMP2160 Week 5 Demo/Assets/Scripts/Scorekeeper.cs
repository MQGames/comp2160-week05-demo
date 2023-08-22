using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class keeps track of the score and the values for doing particular actions
 */ 
public class Scorekeeper : MonoBehaviour
{
    [SerializeField] private int scorePerKill = 10;
    private int score = 0;

    public int Score    // use a property to provide read-only access to score
    {
        get { return score; }
    }

    public void KilledEnemy() 
    {
        score += scorePerKill;
    }

}
