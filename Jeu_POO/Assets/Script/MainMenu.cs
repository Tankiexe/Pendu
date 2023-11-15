using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        AudioManager.instance.ToPlaySound(AudioManager.instance.correct);
        Gamemanager.instance.gameDifficulty.SetActive(true);
        Gamemanager.instance.mainMenuScreen.SetActive(false);
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

    public void Difficulty(int difficulty)
    {
        Gamemanager.instance.StartNewGame((Game.Difficulty)difficulty);
    }

    
}
