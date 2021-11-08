using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    public Text NameBox;
    public Text DialogueBox;
    public int TextSpeed;
    private IEnumerator dialogueCoroutine;

    public void RunDialogue(string name, string dialogue)
    {
        if (dialogueCoroutine != null)
        {
            print("Stopping coroutine");
            StopCoroutine(dialogueCoroutine);
        }
        dialogueCoroutine = DisplayDialogue(name, dialogue);
        StartCoroutine(dialogueCoroutine);
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
                case '!':
                case '?':
                    yield return new WaitForSecondsRealtime(50f / TextSpeed);
                    break;
            }
        }
    }

    public void ToggleUI(bool visible)
    {
        gameObject.SetActive(visible);
    }
}
