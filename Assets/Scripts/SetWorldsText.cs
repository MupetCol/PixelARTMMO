using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetWorldsText : MonoBehaviour
{
    public TMP_InputField text;
    public Button yes1, yes2;

    private List<string> recentWorlds;
    private TMP_Text[] textOnChildren;
    private int indexPos = 0;
    private int size;

    void Start()
    {
        size = GetComponent<Transform>().childCount;
        textOnChildren = new TMP_Text[size];
        recentWorlds = new List<string>();
        textOnChildren = GetComponentsInChildren<TMP_Text>();
        for (int i = 0; i < textOnChildren.Length; i++)
        {
            Debug.Log(textOnChildren[i].text);
        }

        yes1.onClick.AddListener(() => SetRecentArrayElement(text));
        yes2.onClick.AddListener(() => SetRecentArrayElement(text));
    }

    void SetRecentArrayElement(TMP_InputField text)
    {
        string upperVersion = text.text.ToUpper();
        if (!recentWorlds.Contains(upperVersion))
        {
            if (indexPos < size)
            {
                recentWorlds.Add(upperVersion);
                textOnChildren[indexPos].text = text.text;
                indexPos++;
            }
            else
            {
                indexPos = 0;
                recentWorlds.Add(upperVersion);
                textOnChildren[indexPos].text = text.text;
                indexPos++;
            }
        }
    }

    
}
