using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScreen : MonoBehaviour
{
    public IHM ihm;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Remet l'UI du choix de la difficulte
    /// </summary>
    public void OnRestartClick()
    {
        AudioManager.instance.ToPlaySound(AudioManager.instance.correct);
        Gamemanager.instance.OnRestart();
        Gamemanager.instance.gameUI.SetActive(false);
        Gamemanager.instance.otherGameUI.SetActive(true);
    }
    public void OnQuitClick()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
