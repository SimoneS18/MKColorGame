using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Set up the starting of the game
/// </summary>
public class MainMenu : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _quitButton;

    [Header("Canvas's")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _instructions;

    // Add function on click to Play Button & Quit Button
    private void Awake()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(() => playPressed());
        _quitButton.GetComponent<Button>().onClick.AddListener(() => quitGame());
    }

    // following starts the game and enables the instruction panel
    private void playPressed()
    {
        _mainMenu.SetActive(false);
        _instructions.SetActive(true);
    }

    private void quitGame()
    {
        Debug.Log("Quit");
    }
}
