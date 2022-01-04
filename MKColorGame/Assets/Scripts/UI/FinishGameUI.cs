using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// following sets up the finish game ui
/// </summary>
public class FinishGameUI : MonoBehaviour
{
    [Header("Apperence")]
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _correct;
    [SerializeField] private TMP_Text _average;
    [SerializeField] private Button _restartButton;

    [Header("Canvas's")]
    [SerializeField] private GameObject _finishGameCanvas;
    [SerializeField] private GameObject _gameCanvas;

    private int _point;
    private List<float> _times;
    private List<bool> _answers;

    private void Awake() => _restartButton.onClick.AddListener(() => RestartGame());
    
    // following takes in the finishing points, times and answers from the game manager
    internal void Init(int point, List<float> times, List<bool> answers)
    {
        _point = point;
        _times = times;
        _answers = answers;

        UpdateDisplay();
    }

    // update the display
    private void UpdateDisplay()
    {
        // Displays the player Points
        _points.text = $"{_point}";

        // determines how many the player got correct
        int correct = _answers.Count(x => x);
        
        // prints the total of correct answers
        _correct.text = $"{correct}/10";

        float average = 0; 

        for(int i  = 0; i < _times.Count; i++)
            average = average + _times[i];

        average = average / (_times.Count);

        _average.text = $"{average} sec is you average time";

        // now set the PlayerPrefs for High Score and Average
        int currentHighScore = PlayerPrefs.GetInt("HighScore");
        float currentBestAverage = PlayerPrefs.GetFloat("Average");

        // set the high score if it is higher then our current stored store
        if (currentHighScore < _point)
            PlayerPrefs.SetInt("HighScore", _point);

        // set the best average time if it is lower then our current stored time 
        if (currentBestAverage > average)
            PlayerPrefs.SetFloat("Average", average);
    }

    // restarts the game when restart button pressed
    private void RestartGame()
    {
        _gameCanvas.SetActive(true);

        GameManager.Restart?.Invoke();

        _finishGameCanvas.SetActive(false);
    }
}
