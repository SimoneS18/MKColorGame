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
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private Canvas _instructions;

    private void Awake()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(() => playPressed());
        _quitButton.GetComponent<Button>().onClick.AddListener(() => quitGame());
    }

    private void playPressed()
    {
        Debug.Log("Play Pressed");

        _mainMenu.enabled = false;
        _instructions.enabled = true;
    }

    private void quitGame()
    {
        Debug.Log("Quit");
    }
}
