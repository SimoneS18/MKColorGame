using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Following Sets up the color buttons to display ingame
/// </summary>
[RequireComponent(typeof(Button))]
public class ColorButtonUI : MonoBehaviour
{
    [Header("Appearance")]
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _text;

    private ColorSO _colorSO;

    // takes in the assigned ColorSO
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

    // tell ths Game manager if this button was pressed and what color it is
    private void OnButtonClicked() => GameManager.OnButtonPressed?.Invoke(_colorSO);
}
