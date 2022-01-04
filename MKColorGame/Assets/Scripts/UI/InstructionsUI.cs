using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Following is to move on to the game after the player pressed start after reading the instructions
/// This wasn't needed but gave a quick summary to the player on how to play if they have never need it before
/// </summary>
public class InstructionsUI : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private GameObject _startButton;

    [Header("Canvas's")]
    [SerializeField] private GameObject _instructions;
    [SerializeField] private GameObject _playCanvas;

    // Add function on click to start button
    private void Awake() =>  _startButton.GetComponent<Button>().onClick.AddListener(() => startPressed());

    // following disables the instruction canvass, and enable the games canvas
    private void startPressed()
    {
        _instructions.SetActive(false);
        _playCanvas.SetActive(true);
    }
}
