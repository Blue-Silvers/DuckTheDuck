using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool gameMaster, system;
    public string[] gameMasterDialogue, systemDialogue;
    public int imageForGM;

    void Start()
    {
        if(gameMaster)
        {
            DialogueSystem.instance.GameMasterTalking(gameMasterDialogue, imageForGM);
        }
        else if (system)
        {
            DialogueSystem.instance.SystemTalking(systemDialogue);
        }
    }
        
}
