using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTip : MonoBehaviour
{
    public TMP_Text tMP_Text;

    // Start is called before the first frame update
    void Start()
    {
        if (tMP_Text != null)
        {
            Debug.Log("Tip Displayed");
            tMP_Text.text = PlayerDeathTips.chosenTip;
        }
        else
        {
            Debug.Log("TMP_Text component is not assigned.");
        }
    }
}