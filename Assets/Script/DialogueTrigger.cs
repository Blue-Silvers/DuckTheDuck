using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool gameMaster, system;
    public string[] gameMasterDialogue, systemDialogue;

    void Start()
    {
        if(gameMaster)
        {
            DialogueSystem.instance.GameMasterTalking(gameMasterDialogue);
        }
        else if (system)
        {
            DialogueSystem.instance.SystemTalking(systemDialogue);
        }
    }
        
}
