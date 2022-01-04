using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Set up the starting of the game
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _quitButton;

    [Header("Appearance")]
    [SerializeField] private TMP_Text _highScore;
    [SerializeField] private TMP_Text _average;

    [Header("Canvas's")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _instructions;

    // Add function on click to Play Button & Quit Button
    private void Awake()
    {
        _playButton.GetComponent<Button>().onClick.AddListener(() => playPressed());
        _quitButton.GetComponent<Button>().onClick.AddListener(() => quitGame());

        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScore.text = $"<b>High Score: </b>{highScore}";

        float average = PlayerPrefs.GetFloat("Average");
        _average.text = $"<b>Best Average: </b> {average}";
    }

    // following starts the game and enables the instruction panel
    private void playPressed()
    {
        _mainMenu.SetActive(false);
        _instructions.SetActive(true);
    }

    // following quits the game when quit button pressed
    private void quitGame() => Application.Quit();
}
