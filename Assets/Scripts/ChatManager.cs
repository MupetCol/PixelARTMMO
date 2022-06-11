using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
    [SerializeField] TMP_InputField writingField;
    PlayerMovement pM;
    [SerializeField] TMP_Text globalChat;
    bool chatOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!chatOpen)
            {
                writingField.gameObject.SetActive(true);
                pM.usingButton = true;
                pM.horizontalMove = 0;
                writingField.Select();
                writingField.ActivateInputField();
                writingField.text = "";
            }
            else
            { 
                globalChat.text = globalChat.text + "\n" + writingField.text;
                writingField.gameObject.SetActive(false);
                pM.gameObject.SetActive(true);
                pM.usingButton = false;
            }
            chatOpen = !chatOpen;

        }
    }
}
