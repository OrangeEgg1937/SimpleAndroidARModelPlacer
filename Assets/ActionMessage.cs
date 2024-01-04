using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionMessage : MonoBehaviour
{
    // Get the Text
    private TextMeshProUGUI m_displayMessage;

    private void Awake()
    {
        m_displayMessage = GetComponent<TextMeshProUGUI>();
    }

    public void SetMessage(string message)
    {
        m_displayMessage.text = message;
    }
}
