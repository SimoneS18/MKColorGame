using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] private int _count; 
    [SerializeField] private TMP_Text _countDown;
    [SerializeField] private TMP_Text _pointsAdded;

    public static Action RestartTimer;
    public static Action StopTimer;
    public int points;
    private int maxCount;

    private void Start()
    {
        RestartTimer += Restart;
        StopTimer += Stop;

        maxCount = _count;

        // following starts the countdown as soon as the game object is started
        StartCoroutine(CountDownToStart());
    }

    private void OnDestroy()
    {
        RestartTimer -= Restart;
        StopTimer -= Stop;
    }

    // sets up the countdown
    IEnumerator CountDownToStart()
    {
        while (_count >= 0)
        {
            _countDown.text = _count.ToString();

            _pointsAdded.text = $"+{_count * 10}";
            points = _count * 10;

            yield return new WaitForSeconds(1f);

            if (_count != 0)
                _count--;
            if (_count == 0)
                GameManager.TimerCountedDown?.Invoke();
        }

    }

    private void Restart()
    {
        _count = 10;

        StopAllCoroutines();
        StartCoroutine(CountDownToStart());
    }

    private void Stop() => StopAllCoroutines();
}
