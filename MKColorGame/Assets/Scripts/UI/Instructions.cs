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
