using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{   
	public GameObject[] contentSpriteArray;
    public static bool isInputing;
    private bool isGameover;
    public static int errorCount;
    public const int maxError = 5;
    public const int gameDuration = 120;
    public static int remainingTime = gameDuration;

    public GameObject inputNumberHanlder;

    void Awake ()
    {

    }

    void Start()
    {
        InitGameboard();
        
    }

    void Update ()
    {
        if (errorCount > maxError)
        {
            isGameover = true;
            Debug.Log("Game Over");
        }
        if (isInputing) { 
            Debug.Log("isInputing true ");
        } else
        {
            Debug.Log("isInputing false ");

        }
    }

    void InitGameboard ()
    {
        CSVParser.Packet rawData = CSVParser.ParseCSV.generateData("6");    // How to pass a parameter 
        List<string> contentList = rawData.displayData;
        List<string> answerList = rawData.answerData;

        // ---------------------- Test ------------------------
        string completeDisplayContentTestString = "";
        for (int a = 0; a < contentList.Count; a++)
        {
            completeDisplayContentTestString = completeDisplayContentTestString + " " + contentList[a];
        }
        Debug.Log(rawData.rowSize + "x" + rawData.columnSize + " Puzzle: " + rawData.index + " size of " + contentList.Count);
        Debug.Log("content: " + completeDisplayContentTestString);

        string completeAnswerTestString = "";
        for (int a = 0; a < answerList.Count; a++)
        {
            completeAnswerTestString = completeAnswerTestString + " " + answerList[a];
        }
        Debug.Log("answer: " + completeAnswerTestString);

        // ---------------------- Assign ------------------------
        if (contentList.Count == contentSpriteArray.Length)
        {   // size check
            for (int a = 0; a < contentSpriteArray.Length; a++)
            {
                contentSpriteArray[a].GetComponent<ContentScript>().content = contentList[a];       // assign content
                contentSpriteArray[a].GetComponent<ContentScript>().answer = answerList[a];     // assign answer
            }
        }
    }

    public static void IncreaseErrorCount ()
    {
        errorCount++;
    }
}