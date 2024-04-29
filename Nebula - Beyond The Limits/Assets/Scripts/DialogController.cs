using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public float delayTime = 5f;
    public float typingSpeed = 0.1f;

    private string fullText = "Take the relic before it's beyond our grasp!";
    private string currentText = "";

    private void Start()
    {
        StartCoroutine(TriggerDialogAfterDelay());
    }

    public void ActivateDialog()
    {
        dialogBox.SetActive(true);
    }

    private IEnumerator TriggerDialogAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        if (dialogBox != null)
        {
            StartDialog();
        }
        else
        {
            Debug.LogError("DialogManager não atribuído ao DialogTrigger!");
        }
    }

    private void StartDialog()
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            currentText += letter;
            dialogText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        
        yield return new WaitForSeconds(5f); 
        CloseDialog();
    }

    public void CloseDialog()
    {
        dialogBox.SetActive(false);
    }
}
