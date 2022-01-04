using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishGameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _correct;
    [SerializeField] private TMP_Text _average;

    private int _point;
    private List<float> _times;
    private List<bool> _answers;

    internal void Init(int point, List<float> times, List<bool> answers)
    {
        _point = point;
        _times = times;
        _answers = answers;

        UpdateDisplay();
    }

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
       
    }
}
