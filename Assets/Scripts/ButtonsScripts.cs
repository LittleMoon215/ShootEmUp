using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsScripts : MonoBehaviour
{
    public void OnPlayPressed() => SceneManager.LoadScene("Game");
    public void OnExitPressed() => Application.Quit();
}
