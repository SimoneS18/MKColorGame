using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColor", menuName = "StroopTest/Color")]
public class ColorSO : BasicScriptable
{
    [Header("Information")]
    [SerializeField] private string _name;
    [SerializeField] private Color32 _color;
}
