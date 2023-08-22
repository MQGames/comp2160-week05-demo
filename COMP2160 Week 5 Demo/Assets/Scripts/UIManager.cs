using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * This class displays & updates the UI based on the game state
 *
 */
public class UIManager : MonoBehaviour
{
    [SerializeField] private string scoreFormat = "Score: {0}";
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Scorekeeper scorekeeper;

    void Update()
    {
        // for simplicity, we are polling the scorekeeper on every frame
        // we could alternatively set up an event-based approach to update
        // the scoreText only when the score changes

        scoreText.text = string.Format(scoreFormat, scorekeeper.Score);
    }
}
