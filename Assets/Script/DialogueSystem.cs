using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI gmDialogueBox, systemDialogueBox;
    [SerializeField] private string[] gmText, systemText;
    [SerializeField] private float textSpeed;
    private int index;
    void Start()
    {
      gmDialogueBox.text = string.Empty;
      StartDialogue();  
    }

    
    void Update()
    {
        //a changer pour le new input system
        if (Input.GetMouseButtonDown(0))
        {
            if(gmDialogueBox.text == gmText[index])
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Typing());

    }

    IEnumerator Typing()
    {
        if (gmText != null)
        {
            foreach (char c in gmText[index].ToCharArray() )
            {
                gmDialogueBox.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        
    }

    void NextLine()
    {
        if (index < gmText.Length -1)
        {
            index++;
            gmDialogueBox.text = string.Empty;
            StartCoroutine(Typing());
        }
        else
        {
            gmDialogueBox.text = "fin de texte";
        }
    }
}
