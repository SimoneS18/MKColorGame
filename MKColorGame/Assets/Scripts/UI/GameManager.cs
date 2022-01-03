using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private List<GameObject> _colorButtons;
    [SerializeField] private TMP_Text _mainColor;
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private int _numberOfRandomWords;

    [Header("Colors")]
    [SerializeField] private List<ColorSO> _colors;

    [Header("Countdown")]
    [SerializeField] private CountDownManager _countDownManager;


    private ColorSO correctColor;
    public static Action<ColorSO> OnButtonPressed;
    public static Action TimerCountedDown;

    private int points;
    private int count;

    void Start()
    {
        SetupCorrectColor();
        SetupColorButtons();

        points = 0;
        _points.text = $"{points}";

        count = 0;
        _count.text = $"{count}/{_numberOfRandomWords}";
    }

    private void Awake()
    {
        OnButtonPressed += CheckIfCorrectAnswer;
        TimerCountedDown += NextQuestion;
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

        if (count != _numberOfRandomWords)
        {
            SetupCorrectColor();
            SetupColorButtons();

            CountDownManager.RestartTimer?.Invoke();
        }
        else
        {
            Debug.Log("FINSH!");
            CountDownManager.StopTimer?.Invoke();
        }
    }

    // following checks to see if the pressed button is the correct button
    private void CheckIfCorrectAnswer(ColorSO colorSO)
    {
        if (colorSO == correctColor)
        {
            int point = _countDownManager.points;
            points = points + point;

            count++;

            NextWord();
        }
        else
        {
            count++;
            NextWord();
        }
            
    }

    private void NextQuestion()
    {
        points = points - 50;

        count++;
        NextWord();
    }
}
