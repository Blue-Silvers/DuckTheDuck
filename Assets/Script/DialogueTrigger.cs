using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool gameMaster, system;
    public string[] gameMasterDialogue, systemDialogue;
    public int imageForGM;
    public float timeSpeaking;

    public void Trigger()
    {
        if(gameMaster && !system)
        {
            DialogueSystem.instance.GameMasterTalking(gameMasterDialogue, imageForGM, timeSpeaking);
        }
        else if (system && !gameMaster)
        {
            DialogueSystem.instance.SystemTalking(systemDialogue);
        }

    }
        
}
