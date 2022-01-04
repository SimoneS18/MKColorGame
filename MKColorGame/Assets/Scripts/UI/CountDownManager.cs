using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Following Script controls the appearance of the countdown and the countdown controller
/// </summary>
public class CountDownManager : MonoBehaviour
{
    [SerializeField] private int _count; 
    [SerializeField] private TMP_Text _countDown;
    [SerializeField] private TMP_Text _pointsAdded;

    public static Action RestartTimer;
    public static Action StopTimer;
    public int points;

    private void Start()
    {
        RestartTimer += Restart;
        StopTimer += Stop;

        // following starts the countdown as soon as the game object is started
        StartCoroutine(CountDownToStart());
    }

    private void OnDestroy()
    {
        RestartTimer -= Restart;
        StopTimer -= Stop;
    }

    // sets up the countdown and have it count down ever 1 second
    IEnumerator CountDownToStart()
    {
        // loop until _count is not 0
        while (_count >= 0)
        {
            _countDown.text = _count.ToString();

            // set up points
            _pointsAdded.text = $"+{_count * 10}";
            points = _count * 10;

            yield return new WaitForSeconds(1f);

            // determines if count has reached 0 or not
            if (_count != 0)
                _count--;
            if (_count == 0)
                GameManager.TimerCountedDown?.Invoke();
        }

    }

    // following sets up and starts the countdown
    private void Restart()
    {
        _count = 10;

        StopAllCoroutines();
        StartCoroutine(CountDownToStart());
    }

    // following stops the countdown
    private void Stop() => StopAllCoroutines();
}
