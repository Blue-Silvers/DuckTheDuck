using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    
    [SerializeField] private string[] gmText, systemText;
    [SerializeField] private float textSpeed, timeSpeaking;
    [SerializeField] private TextMeshProUGUI gmDialogueBox, systemDialogueBox;
    [SerializeField] private GameObject gameMasterBox, systemBox;
    private int  indexSystem;
    public int nbLines, indexGM;
    public bool activateGM, activateSystem;
    private bool gmTalking, systemTalking, finishedTalking;

    void Start()
    {
      gmDialogueBox.text = string.Empty;
      systemDialogueBox.text = string.Empty;
    }

    
    void Update()
    {

        if (activateGM)
        {
            gmDialogueBox.text = string.Empty;
            gmTalking = true;
            gameMasterBox.GetComponent<Animator>().SetTrigger("Up");
            StartDialogue();
            //StartCoroutine(GMTalking());
            activateGM = false;
        }

        //a changer pour le new input system
        if (systemTalking && Input.GetMouseButtonDown(0))
        {
            if(systemDialogueBox.text == systemText[indexSystem])
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        indexSystem = 0;
        StartCoroutine(Typing());

    }

    // IEnumerator GMTalking()
    // {
        
    // }

    IEnumerator Typing()
    {
        if (gmTalking)
        {
            foreach (char c in gmText[indexGM].ToCharArray() )
            {
                gmDialogueBox.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            yield return new WaitForSeconds(timeSpeaking);
            NextLine();
        }
        else if (systemTalking)
        {
            foreach (char c in systemText[indexSystem].ToCharArray() )
            {
                systemDialogueBox.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
        
    }

    void NextLine()
    {
        if (gmTalking )
        {
            if (indexGM < nbLines -1)
            {
                indexGM++;
                gmDialogueBox.text = string.Empty;
                StartCoroutine(Typing());
            }
            else
            {
                indexGM++;
                gmTalking = false;
                gameMasterBox.GetComponent<Animator>().SetTrigger("Down");
                //StartCoroutine(GMTalking());
            }
        }
        else if (systemTalking)
        {
            if (indexSystem < systemText.Length -1)
            {
                indexSystem++;
                systemDialogueBox.text = string.Empty;
                StartCoroutine(Typing());
            }
            else
            {
                systemDialogueBox.text = "fin de texte";
            }
        }
    }

    void GameMasterTalking(string[] gameMasterDialogue, int numberLines)
    {
        gmText = gameMasterDialogue;
        nbLines = numberLines;
    }
}
