using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private GameObject _startButton;

    [Header("Canvas's")]
    [SerializeField] private Canvas _instructions;
    [SerializeField] private Canvas _playCanvas;

    private void Awake()
    {
        _startButton.GetComponent<Button>().onClick.AddListener(() => startPressed());
    }

    private void startPressed()
    {
        Debug.Log("Start Pressed");

        _instructions.enabled = false;
        _playCanvas.enabled = true;
    }
}
