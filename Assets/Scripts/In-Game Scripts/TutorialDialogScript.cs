using UnityEngine;
using System.Collections;

public class TutorialDialogScript : MonoBehaviour {

    private int MAX_NUM_LINE = 100;
    private int MAX_NUM_CHAR_IN_ONE_LINE = 30;
	// Use this for initialization

	void Start () {
        GetComponent<MeshRenderer>().sortingLayerName = "Dialog Border";
        GetComponent<MeshRenderer>().sortingOrder = 1;
        GetComponent<TextMesh>().fontSize = 1024;
        TypeText("The left mystery number + the right mystery number = " + GameObject.Find("Game Manager").GetComponent<GameManager>().contentSpriteArray[1].GetComponent<ContentScript>().content + " The left mystery number x the right mystery number = " + GameObject.Find("Game Manager").GetComponent<GameManager>().contentSpriteArray[2].GetComponent<ContentScript>().content);
    }
	
	// Update is called once per frame
	void Update () {
	
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
