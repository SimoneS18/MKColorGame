using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// following just quits the game if the escape key is pressed (if built)
/// </summary>
public class QuitGameManager : MonoBehaviour
{
    void Update()
    {
       if(Input.GetKey("escape"))
            Application.Quit();
    }
}
