﻿using UnityEngine;
using System.Collections;

public class TutorialDialogScript : MonoBehaviour {

    private int MAX_NUM_LINE = 100;
    private int MAX_NUM_CHAR_IN_ONE_LINE = 35;
	// Use this for initialization

	void Start () {

        GetComponent<MeshRenderer>().sortingLayerName = "Dialog Border";
        GetComponent<MeshRenderer>().sortingOrder = 1;
        GetComponent<TextMesh>().fontSize = 1024;

       if (GameManager.puzzleLv == "1") {
              TypeText("Input two numbers to the empty squares. Their sum is " + GameObject.Find("Game Manager").GetComponent<GameManager>().contentSpriteArray[1].GetComponent<ContentScript>().content + " and product is " + GameObject.Find("Game Manager").GetComponent<GameManager>().contentSpriteArray[2].GetComponent<ContentScript>().content + ". The sum and product together are called a pair clue");
       }
        if (GameManager.puzzleLv == "2") {
              TypeText("Now you have more options. Practise what you have learned from last level.");
       }
       
        if (GameManager.puzzleLv == "3") {
            TypeText("In this level we have two pair clues. Input three numbers and make them satisfy each pair clue. Sometimes a pair clue could be empty!");
        }
        
          if (GameManager.puzzleLv == "4") {
            TypeText("Puzzle is getting harder now. Don't worry. You can start from an easier pair clue and solve others! Each game only has one solution!");
        }
        
           if (GameManager.puzzleLv == "5") {
            TypeText("Numbers you find should satisfy both pair clues and square clue and square clue might be empty. Each combination of numbers can only appear once in a game regardless of their order. Four cornering identical numbers is an exception!");
        } 

    }
    
    void Update () {
        GameObject.Find ("Earl").GetComponent<Animator>().CrossFade("BirdMoving", 0f);
    }
    
    void TypeText(string message)
    {
        int charCountInOnline = 0;
        int lineCount = 0;
        for (int i = 0; i < message.Length; i++)
        {
            if (message.Substring(i, 1) == " ")
            {
                if (charCountInOnline == 0)
                {
                    i++;
                }
                else if (isWordStartNewLine(message, i, charCountInOnline, MAX_NUM_CHAR_IN_ONE_LINE))
                {
                    if (lineCount == MAX_NUM_LINE)
                    {
                        clearDialog();
                    }
                    else
                    {
                        GetComponent<TextMesh>().text += "\n";
                    }
                    charCountInOnline = 0;
                    lineCount++;
                    i++;
                }

            }
            if (charCountInOnline == MAX_NUM_CHAR_IN_ONE_LINE)
            {
                if (lineCount == MAX_NUM_LINE)
                {
                    clearDialog();
                }
                else
                {
                    GetComponent<TextMesh>().text += "\n";
                }
                charCountInOnline = 0;
                lineCount++;
            }
            GetComponent<TextMesh>().text += message[i];
            charCountInOnline++;
        }
    }
    
    bool isWordStartNewLine(string message, int messageIndex, int lineIndex, int maxCharInOneLine)
    {
        int countWordChar = 0;
        int offSetToAvoidBeginSpace = 0;
        if (messageIndex + 1 < message.Length)
        {
            if (message.Substring(messageIndex + 1, 1) == " ")
            {
                for (int i = messageIndex + 1; i < message.Length; i++)
                {
                    if (message.Substring(i, 1) != " ")
                    {
                        break;
                    }
                    offSetToAvoidBeginSpace++;
                }
            }
            for (int i = messageIndex + 1 + offSetToAvoidBeginSpace; i < message.Length; i++)
            {
                countWordChar++;
                if (message.Substring(i, 1) == " ")
                {
                    break;
                }
            }
            if (countWordChar > maxCharInOneLine - lineIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    void clearDialog()
    {
        GetComponent<TextMesh>().text = "";
    }
}
