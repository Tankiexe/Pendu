using System;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public Game currentGame;

    public List<DifficultyLevel> levels;
    public int startingLife = 11;

    public GameObject mainMenu;
    public GameObject mainMenuScreen;
    public GameObject gameDifficulty;
    public GameObject winingScreen;
    public GameObject killingScreen;
    public GameObject otherGameUI;
    public GameObject gameUI;
    public IHM ihm;
    public string message;

    public List<string> list;
    public string[] array;
    private void Awake()
    {
        instance = this;
        gameUI.SetActive(false);
        gameDifficulty.SetActive(false);
    }

    void Start()
    {
        //Debug.Log("Le mot a deviner contien " + choosenWord.Length + " lettres.");
    }

    public void StartNewGame(Game.Difficulty difficulty)
    {
        currentGame = new Game(startingLife, difficulty);
        //currentGame.choosenWord = GetRandomWord(dictionary1);
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        ihm.UpdateHangMan();
        ihm.UpdateWord();
        ihm.UpdatePlayedLetters();
        message = "Commencez par saisir une lettre";
        ihm.SendMessage();
    }


    /// <summary>
    /// Permet de choisir un mot aléatoire.
    /// </summary>
    /// <returns></returns>
    public string GetRandomWord(List<string> dictionary)
    {
        int index = UnityEngine.Random.Range(0, dictionary.Count);
        return dictionary[index];
    }

    /// <summary>
    /// Detecte si un character est saisie.
    /// </summary>
    /// <returns></returns>
    public bool CharDetecteur()
    {
        if (ihm.userInput.text.Length == 0) 
        {
            message = "Veuillez saisir une lettre";
            return false; 
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Fonction pour savoir si l'utilisateur a saisie une lettre de l'alphabet
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public bool LetterDetecteur(char input)
    {
        return Char.IsLetter(input);
    }

    /// <summary>
    /// Retourne vrai si la lettre passée en parametre est présente dans le mot choisi.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public bool LetterIsInWord(char input)
    {
        return currentGame.choosenWord.Contains(input);
        
        /*foreach (char lettre in choosenWord)
        {
            if (lettre == input) return true;
        }
        return false;*/
    }

    /// <summary>
    /// Retire de la vie et mettre fin au jeu a 0 pv.
    /// </summary>
    public void KillingMethod()
    {
        currentGame.life--;
        ihm.UpdateHangMan();
        AudioManager.instance.ToPlaySound(AudioManager.instance.hit);
        if (currentGame.isLost)
        {
            AudioManager.instance.ToPlaySound(AudioManager.instance.death);
            otherGameUI.SetActive(false);
            killingScreen.SetActive(true);
        }
    }

    /// <summary>
    /// Logique du jeu pour savoir quoi faire, quel message envoyer ect...
    /// </summary>
    /// <param name="input"></param>
    public void OnPlayerLetter(char input)
    {
        if (!LetterDetecteur(input))
        {
            message = "Vous n'avez pas saisie une lettre";
            AudioManager.instance.ToPlaySound(AudioManager.instance.incorrect);
            return;
        }
        if (LetterPlayed(input))
        {
            message = "Vous avez dejà joué cette lettre.";
            AudioManager.instance.ToPlaySound(AudioManager.instance.incorrect);
            return;
        }
        currentGame.pickedLetter.Add(input);
        ihm.UpdatePlayedLetters();
        if (LetterIsInWord(input))
        {
            message = "La lettre est dans le mot";
            AudioManager.instance.ToPlaySound(AudioManager.instance.correct);
            ihm.UpdateWord();
        }
        else
        {
            message = "La lettre saisie n'est pas dans le mot.";
            KillingMethod();
        }
    }

    /// <summary>
    /// Ajoute la lettre jouer a celles deja jouées.
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    public bool LetterPlayed(char letter)
    {
        return currentGame.pickedLetter.Contains(letter);
    }

    /// <summary>
    /// Ecrire les lettre du mot deviner et mettre fin au jeu le mot est complet
    /// </summary>
    /// <returns></returns>
    public string GetGuessedWord()
    {
        string guesWord = string.Empty;
        foreach (char letter in currentGame.choosenWord)
        {
            if (LetterPlayed(letter))
            {
                guesWord += letter;
            }
            else
            {
                guesWord += "_";
            }
        }
        if (guesWord == currentGame.choosenWord)
        {
            otherGameUI.SetActive(false);
            winingScreen.SetActive(true);
        }
        return guesWord;
    }

    /// <summary>
    /// Retourne le string des lettre deja jouer
    /// </summary>
    /// <returns></returns>
    public string GetPlayedLetters()
    {
        string guesletters = string.Empty;
        foreach (char letter in currentGame.pickedLetter)
        {
            if (LetterPlayed(letter))
            {
                guesletters += letter;
            }
        }
        return guesletters;
    }

    /// <summary>
    /// recharge la scene
    /// </summary>
    public void OnRestart()
    {
        killingScreen.SetActive(false);
        winingScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    /*KeyCode GetKeyDown()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(kcode))
                return kcode;
        }
        return KeyCode.None;
    }*/
}
/*while ( true )
        {
            while (!Input.anyKey)
            {

                yield return null;
            }
            KeyCode key = GetKeyDown();
            Debug.Log($"Vous avez saisi la lettre {key}");
            yield return null;
        }*/