using UnityEngine;
using System.Collections;

public class TutorialDialogScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().sortingLayerName = "Dialog Border";
        GetComponent<MeshRenderer>().sortingOrder = 1;
        GetComponent<TextMesh>().fontSize = 1024;
        TypeText(GameObject.Find ("Game Manager").GetComponent<GameManager>().contentSpriteArray[1].GetComponent<ContentScript>().content+
            GameObject.Find("Game Manager").GetComponent<GameManager>().contentSpriteArray[2].GetComponent<ContentScript>().content);
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
                else if (isWordStartNewLine(message, i, charCountInOnline, 15))
                {
                    if (lineCount == 6)
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
            if (charCountInOnline == 15)
            {
                if (lineCount == 6)
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
