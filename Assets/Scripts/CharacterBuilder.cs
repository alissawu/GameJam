using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterBuilder : MonoBehaviour
{
    // image "body" as base

    // categories w/ options
    public Image skin; // blue, purple, red
    public Image hair; // longhair, shorthair
    public Image face; // angry, shy, smile
    public Image shirt; // buttonup, layershirt, tank
    public Image pants; // pants, shorts, skirt
    public Image shoes; // boots, sneakers, socks
    public Image wings; // angelwing, devilwing, fairwing

    public void InitializeCharacterOptions(Dictionary<string, string> personalityResults) {
        UpdateCharacter(personalityResults);
    }

    public void UpdateCharacter(Dictionary<string, string> personalityResults)
    {
        if (personalityResults.ContainsKey("Skin"))
        {
            skin.sprite = Resources.Load<Sprite>($"Skin/{personalityResults["Skin"]}");
        }

        if (personalityResults.ContainsKey("Hair"))
        {
            hair.sprite = Resources.Load<Sprite>($"Hair/{personalityResults["Hair"]}");
        }

        if (personalityResults.ContainsKey("Face"))
        {
            face.sprite = Resources.Load<Sprite>($"Face/{personalityResults["Face"]}");
        }

        if (personalityResults.ContainsKey("Shirt"))
        {
            shirt.sprite = Resources.Load<Sprite>($"Shirt/{personalityResults["Shirt"]}");
        }

        if (personalityResults.ContainsKey("Pants"))
        {
            pants.sprite = Resources.Load<Sprite>($"Pants/{personalityResults["Pants"]}");
        }

        if (personalityResults.ContainsKey("Shoes"))
        {
            shoes.sprite = Resources.Load<Sprite>($"Shoes/{personalityResults["Shoes"]}");
        }

        if (personalityResults.ContainsKey("Wings"))
        {
            wings.sprite = Resources.Load<Sprite>($"Wings/{personalityResults["Wings"]}");
        }
    }

}
