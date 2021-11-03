using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    public Text NameBox;
    public Text DialogueBox;
    public int TextSpeed;

    public void RunDialogue(string name, string dialogue)
    {
        StartCoroutine(DisplayDialogue(name, dialogue));
    }

    private IEnumerator DisplayDialogue(string name, string dialogue)
    {
        NameBox.text = name;
        DialogueBox.text = string.Empty;
        foreach (char character in dialogue)
        {
            DialogueBox.text += character;
            switch (character)
            {
                default:
                    yield return new WaitForSecondsRealtime(2.5f / TextSpeed);
                    break;
                case ',':
                    yield return new WaitForSecondsRealtime(20f / TextSpeed);
                    break;
                case '.':
                    yield return new WaitForSecondsRealtime(50f / TextSpeed);
                    break;

            }
        }
    }
}
