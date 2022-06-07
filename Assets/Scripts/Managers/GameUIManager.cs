using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : MonoBehaviour
{
    public GameObject HUDobj;
    public Button expandOptionsButton, hideOptionsButton, expandChatButton, expandInventoryButton;
    private Animator HUDanim;
    // Start is called before the first frame update
    void Start()
    {
        HUDanim = HUDobj.GetComponent<Animator>();

        expandOptionsButton.onClick.AddListener(OptionsUI);
        hideOptionsButton.onClick.AddListener(OptionsUI);

        expandChatButton.onClick.AddListener(ChatUI);

        expandInventoryButton.onClick.AddListener(InventoryUI);

    }

    void OptionsUI()
    {
        HUDanim.SetBool("ExpandOptions", !HUDanim.GetBool("ExpandOptions"));
    }

    void InventoryUI()
    {
        HUDanim.SetBool("ExpandInventory", !HUDanim.GetBool("ExpandInventory"));
    }

    void ChatUI()
    {
        HUDanim.SetBool("ExpandChat", !HUDanim.GetBool("ExpandChat"));
    }
}
