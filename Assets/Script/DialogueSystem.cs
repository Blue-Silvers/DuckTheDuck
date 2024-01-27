using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;

    
    [SerializeField] private float textSpeed;
    [SerializeField] private TextMeshProUGUI gmDialogueBox, systemDialogueBox;
    [SerializeField] private GameObject gameMasterBox, systemBox;
    [SerializeField] private Image gameMasterSprite;
    [SerializeField] private Sprite[] dialogueBoxes;
    private float timeSpeaking;
    private string[] gmText, systemText;
    private int  indexSystem, indexGM;
    private bool gmTalking, systemTalking, bothTalking;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    void Start()
    {
      gmDialogueBox.text = string.Empty;
      systemDialogueBox.text = string.Empty;
    }

    
    void Update()
    {

        //a changer pour le new input system
        if (systemTalking && Input.GetMouseButtonDown(0))
        {
            NextLine();
        }

    }

    public void GameMasterTalking(string[] gameMasterDialogue, int image, float timeToSpeak)
    {
        gmDialogueBox.text = string.Empty;
        timeSpeaking = timeToSpeak;
        gameMasterSprite.GetComponent<Image>().sprite = dialogueBoxes[image];
        gmText = gameMasterDialogue;
        gmTalking = true;
        gameMasterBox.GetComponent<Animator>().SetTrigger("Up");
        StartCoroutine(Typing());
    }

    public void SystemTalking(string[] systemDialogue)
    {
        systemDialogueBox.text = string.Empty;
        systemText = systemDialogue;
        systemTalking = true;
        systemBox.GetComponent<Animator>().SetTrigger("Up");
        StartCoroutine(Typing());
        
    }


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
            if (indexGM < gmText.Length -1)
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
                systemBox.GetComponent<Animator>().SetTrigger("Down");
            }
        }
    }

    
}
