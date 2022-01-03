using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ColorButton : MonoBehaviour
{
    [Header("Appearance")]
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _text;

    private ColorSO _colorSO;

    internal void Init(ColorSO colorSO)
    {
        _colorSO = colorSO;

        UpdateDisplay();

        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClicked());
    }

    // Start is called before the first frame update
    private void UpdateDisplay()
    {
        _background.color = _colorSO.Color;
        _text.text = _colorSO.Name;
        _text.color = _colorSO.Color;
    }

    private void OnButtonClicked() => GameManager.OnButtonPressed?.Invoke(_colorSO);
}
