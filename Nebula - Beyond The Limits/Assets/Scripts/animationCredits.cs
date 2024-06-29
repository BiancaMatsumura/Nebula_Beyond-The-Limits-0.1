using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationCredits : MonoBehaviour
{
    public Animator creditsAnim;
    public GameObject credits;

    public bool ativarAnim = false;
 
    public void OnPlayAnim()
    {
        StartCoroutine(PlayAnim());
    }
    private IEnumerator PlayAnim()
    {
        yield return new WaitForSeconds(1);

        if (creditsAnim != null  && credits.activeSelf)
        {

            creditsAnim.SetTrigger("ativar");
        }

    }
}
