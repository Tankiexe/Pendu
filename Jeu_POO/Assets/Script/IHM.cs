using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class IHM : MonoBehaviour
{
    public GameObject wordui;
    public TextMeshProUGUI word;
    public TextMeshProUGUI messageToPlayer;
    public TextMeshProUGUI playedletters;
    public TMP_InputField userInput;

    public Image hangMan;
    public List<Sprite> hangingSprites;
    private Sprite getSprite
    {
        get
        {
            int index = Gamemanager.instance.currentGame.life;
            return hangingSprites[index];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnButtonClick()
    {
        if (Gamemanager.instance.CharDetecteur())
        {
            string input = userInput.text;
            Gamemanager.instance.OnPlayerLetter(input[0]);
            userInput.text = null;
        }
        SendMessage();
    }

    public void UpdateWord()
    {
        word.text = Gamemanager.instance.GetGuessedWord();
    }
    /// <summary>
    /// Envoie le message au joueur
    /// </summary>
    public void SendMessage()
    {
        messageToPlayer.text = Gamemanager.instance.message; 
    }

    public void UpdatePlayedLetters()
    {
        playedletters.text = Gamemanager.instance.GetPlayedLetters();
    }

    public void UpdateHangMan()
    {
        hangMan.sprite = getSprite;
    }
}
