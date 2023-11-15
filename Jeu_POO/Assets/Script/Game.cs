using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Game 
{
    public List<string> choosenDictionary;
    public string choosenWord;
    public List<char> pickedLetter;
    public int life;
    public bool isLost 
    {
        get
        {
            return life <= 0;
        }
    }

    public enum Difficulty
    {
        easy,medium,hard
    }
    
    public Game(int life, Difficulty difficulty)
    {
        foreach (DifficultyLevel level in Gamemanager.instance.levels)
        {
            if (level.difficulty != difficulty) continue;
            choosenDictionary = level.dico;

            break;
        }
        Debug.Log(choosenDictionary  + " " + difficulty);


        pickedLetter = new List<char>();
        choosenWord = Gamemanager.instance.GetRandomWord(choosenDictionary);
        this.life = life;
    }
    

}

[System.Serializable]
public class DifficultyLevel
{
    public Game.Difficulty difficulty;
    public List<string> dico;
    


}