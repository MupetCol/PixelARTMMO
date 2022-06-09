using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CustomizableCharacter : MonoBehaviour
{
    [SerializeField]
    private int skinNr;

    [SerializeField]
    private string spriteSheetName;

    [SerializeField]
    private Skins[] skins;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void LateUpdate()
    {
        SkinChoice();
    }

    void SkinChoice()
    {
        if (spriteRenderer.sprite.name.Contains(spriteSheetName))
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = Regex.Replace(spriteName, "[^0-9]", "");
            int spriteNr = int.Parse(spriteName);

            spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        }
        else { Debug.LogWarning("CUSTOM WARNING: BAD SPRITE SHEET NAME"); }
    }
}



[System.Serializable]
public struct Skins{
    public Sprite[] sprites;
}