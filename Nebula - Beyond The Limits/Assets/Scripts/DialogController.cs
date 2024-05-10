using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public float typingSpeed = 0.1f;

    public AudioSource somDialogo;
    public AudioSource textAudio;

    private List<int> shownDialogues = new List<int>();

    public string[] allDialogues = {
        "Get the relic and save the Galaxy",
        "Get the Green Gem to restore your integrity",
       
    };

    private void Start()
    {        
        TriggerDialog(0);
    }

    public void TriggerDialog(int dialogueIndex)
    {
        if (dialogueIndex >= 0 && dialogueIndex < allDialogues.Length && !shownDialogues.Contains(dialogueIndex))
        {
            string selectedDialogue = allDialogues[dialogueIndex];
            StartCoroutine(TypeText(selectedDialogue));
            shownDialogues.Add(dialogueIndex); 
        }
    
    }

    private IEnumerator TypeText(string fullText)
    {
        dialogBox.SetActive(true);
        somDialogo.Play();
        dialogText.text = "";

        foreach (char letter in fullText)
        {
            textAudio.Play();
            dialogText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }

        
        yield return new WaitForSeconds(4f);

        CloseDialog();
    }

    public void CloseDialog()
    {
        dialogBox.SetActive(false);
    }
}
