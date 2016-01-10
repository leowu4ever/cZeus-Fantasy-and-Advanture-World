using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MathIconIndication : MonoBehaviour {

    public Sprite[] mathSymbols;

    void Update ()
    {

        if (BoardPressedHandler.curPressedContent == null)
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
        else if (BoardPressedHandler.curPressedContent.name == "Mystery Number Content")
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
        else if (BoardPressedHandler.curPressedContent.name == "Addition Content")
        {
            gameObject.GetComponent<Image>().enabled = true;

            gameObject.GetComponent<Image>().sprite = mathSymbols[0];

        }
        else if (BoardPressedHandler.curPressedContent.name == "Product Content")
        {
            gameObject.GetComponent<Image>().enabled = true;

            gameObject.GetComponent<Image>().sprite = mathSymbols[1];

        }
    }
}
    