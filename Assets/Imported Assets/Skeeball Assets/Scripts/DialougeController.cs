using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeController : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip ("Changes speed of type effect")]public float delay = 0.1f;
    [Tooltip("Text to type")] public string fullText;
    //makes the string initially empty
    private string currentText="";
    
    void Update()
    {
        //This fixes visual bug after multiple restarts
        if(GameManager.gm.isGameActive &&!GameManager.gm.secondGameOverCheck)
        {
            StartCoroutine(ShowText());
            GameManager.gm.secondGameOverCheck = true;
        }
        else
        {
            currentText = "";
            fullText = "Game Over!";
        }
       

    }
    IEnumerator ShowText()
    {
        //creates a type writter effect
        for (int i = 0; i <= fullText.Length; i++) 
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshPro>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
