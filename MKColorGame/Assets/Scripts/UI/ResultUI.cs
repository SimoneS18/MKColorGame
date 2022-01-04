using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Following script it used to display if the player got the correct answer, and output the time it 
/// took to answer that question
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class ResultUI : MonoBehaviour
{
    private bool _result;
    private float _time;

    // following init sets the private result and time 
    internal void Init(bool result, float time)
    {
        _result = result;
        _time = time;

        UpdateDisplay();
    }

    // following init is used if the player doesnt answer quick enough
    internal void Init()
    {
        // Get the gameObjects TMP_Text
        TMP_Text text = gameObject.GetComponent<TMP_Text>();

        // set the text color and words
        text.text = $"<color=blue>You took too long to answer! -50 points</color>";

        // destroy the game object after 2 seconds
        Destroy(gameObject, 2);
    }

    // Updates the display depending on the private variables 
    private void UpdateDisplay()
    {
        TMP_Text text = gameObject.GetComponent<TMP_Text>();

        // if the answer is correct, display Correct and time in Green Text
        if (_result)
            text.text = $"<color=green>Correct! It took you {_time} seconds</color>";
        // if the answer is incorrect, display Wrong and time in Red Text
        else
            text.text =$"<color=red>Wrong! It took you {_time} seconds</color>";

        // Destroy the text in 2 seconds
        Destroy(gameObject, 2);
    }
}
