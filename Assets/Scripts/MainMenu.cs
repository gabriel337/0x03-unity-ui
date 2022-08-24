using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// MainMenu class that has the components for the mainmenu canvas
/// </summary>
public class MainMenu : MonoBehaviour
{    
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    /// <summary>
    /// method for colorblind option and to change scene to Maze
    /// </summary>
    public void PlayerMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene("maze");
    }
    /// <summary>
    /// method for quitting the application
    /// </summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
