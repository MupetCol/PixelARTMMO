using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterCreateWorld : MonoBehaviour
{   
    [SerializeField]
    TMP_Text valid, invalid;

    [SerializeField]
    GameObject createPopUp, joinPopUp;

    private string findName = " ";

    [SerializeField]
    List<string> list_WorldNames = new List<string>();

    private void Start()
    {
        for(int i = 0; i < list_WorldNames.Count; i++)
        {
            list_WorldNames[i] = list_WorldNames[i].ToUpper();
        }
    }
    public void ValidateText(TMP_InputField inputField)
    {
        Regex regex = new Regex("[^a-zA-Z0-9]");
        if (regex.IsMatch(inputField.text) || inputField.text == "")
        {
            invalid.enabled = true;
            valid.enabled = false;   
        }
        else
        {
            invalid.enabled = false;
            valid.enabled = true;
        }
    }

    public void EnterPopUps(TMP_InputField inputField)
    {
        string uppeVersion = inputField.text.ToUpper();
        if (list_WorldNames.Contains(uppeVersion) && valid.enabled == true)
        {
            joinPopUp.SetActive(true);
        }
        if(list_WorldNames.Contains(uppeVersion) != true && valid.enabled == true)
        {
            createPopUp.SetActive(true);
        }
    }

    public void CreateWorld(TMP_InputField inputField)
    {
        string uppeVersion = inputField.text.ToUpper();
        list_WorldNames.Add(uppeVersion);
        createPopUp.SetActive(false);
    }

    public void JoinWorld()
    {
        Debug.Log("PLAYER JOINED WORLD");
        joinPopUp.SetActive(false);
    }

    private bool isTaken(string worldName)
    {

        return (worldName == findName);
    }

    public void AddWorld(TMP_InputField inputField)
    {
        list_WorldNames.Add(inputField.text);
    }

    public void ClosePopUp(GameObject popUp)
    {
        popUp.SetActive(false); 
    }
}
