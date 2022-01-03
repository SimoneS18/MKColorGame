using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private List<GameObject> _colorButtons;
    [SerializeField] private TMP_Text _mainColor;

    [Header("Colors")]
    [SerializeField] private List<ColorSO> _colors;

    private ColorSO correctColor;

    void Start()
    {
        SetupCorrectColor();
        SetupColorButtons();
    }

    private void SetupCorrectColor()
    {
        // setting it to the default list of colors
        List<ColorSO>  _tempColors = _colors;

        // select a random color to be the color the the main color
        int _randomColor = Random.Range(0, _tempColors.Count);
        _mainColor.color = _tempColors[_randomColor].Color;

        correctColor = _tempColors[_randomColor];

        // remove this color
        _tempColors.RemoveAt(_randomColor);

        // now selec the color the text should be
        int _randomText = Random.Range(0, _tempColors.Count);
        _mainColor.text = $"{_tempColors[_randomText].Name}";

    }

    private void SetupColorButtons()
    {
        // setting it to the default list of colors
        List<ColorSO> _tempColors = _colors;


    }
}
