using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{

    private TextMeshProUGUI GemCounter;

    // Start is called before the first frame update
    void Start()
    {
        GemCounter = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateGemCounter(playerInventory playerInventory)
    {
        GemCounter.text = playerInventory.NumberOfGems.ToString();
    }
}
