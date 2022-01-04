using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// following is just for visual purposes
/// When the GameObject is first load, pick a random color and then another random color
/// </summary>
public class RandomWordUI : MonoBehaviour
{
    [Header("Appearance")]
    [SerializeField] private GameObject _text;
    [SerializeField] private List<ColorSO> _colors;

    private int _randomColor;
    private int _randomText;

    // play as soon as item is awake
    private void Awake()
    {
        // get the TMP_Text component of the text gamobject
        TMP_Text text = _text.GetComponent<TMP_Text>();

        // pick a random number out of the size of color provided
        _randomColor = Random.Range(0, _colors.Count);

        // set the color to the first selected random color
        text.color = _colors[_randomColor].Color;

        // remove the color that was selected
        _colors.RemoveAt(_randomColor);

        // pick another random (exculding the one above) to be the text 
        _randomText = Random.Range(0, _colors.Count);

        // set the text to the second selected color
        text.text = $"{_colors[_randomText].Name}";
    }
}
