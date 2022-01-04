using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private List<GameObject> _colorButtons;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TMP_Text _mainColor;
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private int _numberOfRandomWords;

    [Header("Colors")]
    [SerializeField] private List<ColorSO> _colors;

    [Header("Countdown")]
    [SerializeField] private CountDownManager _countDownManager;

    [Header("Prefabs")]
    [SerializeField] private GameObject _resultText;
    [SerializeField] private Transform _resultSpawnPoint;

    [Header("Canvas's")]
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private GameObject _finishGameCanvas;

    private ColorSO correctColor;
    public static Action<ColorSO> OnButtonPressed;
    public static Action TimerCountedDown;

    private int points;
    private int count;
    private float time;

    private List<float> times =new List<float>();
    private List<bool> answers = new List<bool>();

    void Start()
    {
        // Set up restart Game Button
        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(() => RestartGame());
    }

    private void Awake()
    {
        OnButtonPressed += CheckIfCorrectAnswer;
        TimerCountedDown += NextQuestion;

        RestartGame();
    }

    private void OnDestroy()
    {
        OnButtonPressed -= CheckIfCorrectAnswer;
        TimerCountedDown -= NextQuestion;
    }

    // following function sets up the correct color
    private void SetupCorrectColor()
    {
        // setting it to the default list of colors
        List<ColorSO>  _tempColors = new List<ColorSO>(_colors);

        // select a random color to be the color the the main color
        int _randomColor = UnityEngine.Random.Range(0, _tempColors.Count);
        _mainColor.color = _tempColors[_randomColor].Color;

        correctColor = _tempColors[_randomColor];

        // remove this color
        _tempColors.RemoveAt(_randomColor);

        // now selec the color the text should be
        int _randomText = UnityEngine.Random.Range(0, _tempColors.Count);
        _mainColor.text = $"{_tempColors[_randomText].Name}";
    }

    // following function sets up the color buttons
    private void SetupColorButtons()
    {
        // setting it to the default list of colors
        List<ColorSO> _tempColors = new List<ColorSO>(_colors);

        // now set up each button on the screen
        for (int i = 0; i < 4; i++)
        {
            int random = UnityEngine.Random.Range(0, _tempColors.Count);
            _colorButtons[i].GetComponent<ColorButton>().Init(_tempColors[random]);

            _tempColors.RemoveAt(random);
        }
    }

    private void NextWord()
    {
        _points.text = $"{points}";
        _count.text = $"{count}/{_numberOfRandomWords}";

        time = Time.time;

        // following determines if its the end of the game
        if (count != _numberOfRandomWords)
        {
            SetupCorrectColor();
            SetupColorButtons();

            CountDownManager.RestartTimer?.Invoke();
        }
        else
        {
            CountDownManager.StopTimer?.Invoke();

            _finishGameCanvas.SetActive(true);

            _finishGameCanvas.GetComponent<FinishGameUI>().Init(points, times, answers);

            _gameCanvas.SetActive(false);
        }
    }

    // following checks to see if the pressed button is the correct button
    private void CheckIfCorrectAnswer(ColorSO colorSO)
    {
        GameObject resultText = Instantiate(_resultText, _resultSpawnPoint);

        float finishTime = Time.time - time;

        times.Add(finishTime);
        

        if (colorSO == correctColor)
        {
            answers.Add(true);
            resultText.GetComponent<ResultUI>().Init(true, finishTime);

            int point = _countDownManager.points;
            points = points + point;

            count++;

            NextWord();
        }
        else
        {
            answers.Add(false);
            resultText.GetComponent<ResultUI>().Init(false, finishTime);

            count++;
            NextWord();
        }
    }

    private void NextQuestion()
    {
        GameObject resultText = Instantiate(_resultText, _resultSpawnPoint);
        resultText.GetComponent<ResultUI>().Init();

        points = points - 50;

        float finishTime = (float)Math.Round(Time.time - time, 3);

        times.Add(finishTime);
        answers.Add(false);

        count++;
        NextWord();
    }

    // following is called at the start/restart of a game
    private void RestartGame()
    {
        // set points to 0 are game start/restart & display
        points = 0;
        _points.text = $"{points}";

        // set count to 0 are game start/restart
        count = 0;
        _count.text = $"{count}/{_numberOfRandomWords}";

        // restart timer
        CountDownManager.RestartTimer?.Invoke();

        // sets up the Main color and the color buttons as the Start of the Game
        SetupCorrectColor();
        SetupColorButtons();

        // set the starting time to determine how long it takes for the player to play
        time = Time.time;
    }
}
