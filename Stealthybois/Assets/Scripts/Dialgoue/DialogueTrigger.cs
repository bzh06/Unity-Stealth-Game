using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    private Dialogue dialogue;
    public string dialogue_file;
    public string NPC_Name;
    private DialogueManager dm;
    private bool canTalk;
    public bool autostart;
    private PlayerController player;
    private void Awake()
    {
        dm = FindObjectOfType<DialogueManager>();
        canTalk = false;
        player = FindObjectOfType<PlayerController>();
        dialogue = load_Dialogue(dialogue_file);
        dialogue.name = NPC_Name;
    }
    private void Update()
    {
        if(canTalk)
        {
            if (!player.inDialogue && Input.GetMouseButtonDown(0))
                dm.StartDialogue(dialogue);
            if (autostart && player.inDialogue)
            {
                dm.StartDialogue(dialogue);
                autostart = false;
            }
            else if (player.inDialogue && Input.GetMouseButtonDown(0) && !dialogue.npc_talking && dm.choice != -2)
            {
                if (dm.getCurrentNode().Lines != null && dm.getCurrentNode().Text == null)
                {
                    dm.DisplayNextLine(dialogue);
                }
                else
                {
                    dm.DisplayNPCLine(dialogue);
                }
            }
            else if (player.inDialogue && Input.GetMouseButtonDown(0) && dialogue.npc_talking)
            {
                if (dm.getCurrentNode().Lines != null && dm.getCurrentNode().Text == null)
                {
                    dm.DisplayNextLine(dialogue);
                }
                else
                {
                    dm.DisplayOptions(dialogue);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canTalk = false;
        }
    }

    private Dialogue load_Dialogue(string path)
    {
        XmlSerializer seri = new XmlSerializer(typeof(Dialogue));
        StreamReader streamReader = new StreamReader(path);

        Dialogue bigD = (Dialogue)seri.Deserialize(streamReader);

        return bigD;
    }

    public void setCanTalk(bool talk)
    {
        canTalk = talk;
    }

    


}

