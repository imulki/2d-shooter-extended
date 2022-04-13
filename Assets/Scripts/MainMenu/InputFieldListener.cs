using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldListener : MonoBehaviour
{
    public TMP_InputField mainInputField;

    GameObject playerDataSingleton;
    PlayerData playerData;

    void Start()
    {
        //Adds a listener to the main input field and invokes a method when the value changes.
        mainInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });

        playerDataSingleton = GameObject.FindGameObjectWithTag("Data");
        playerData = playerDataSingleton.GetComponent<PlayerData> ();
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        playerData.setPlayerName(mainInputField.text);
    }
}
