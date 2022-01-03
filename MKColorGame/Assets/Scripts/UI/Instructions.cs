using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Following is to move on to the game after the player pressed start after reading the instructions
/// </summary>
public class Instructions : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private GameObject _startButton;

    [Header("Canvas's")]
    [SerializeField] private Canvas _instructions;
    [SerializeField] private Canvas _playCanvas;

    // Add function on click to start button
    private void Awake() =>  _startButton.GetComponent<Button>().onClick.AddListener(() => startPressed());

    // following disables the instruction canvass, and enable the games canvas
    private void startPressed()
    {
        _instructions.enabled = false;
        _playCanvas.enabled = true;
    }
}
