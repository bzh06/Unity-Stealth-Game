using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour {
	public Text nameText;
	public Text dialogueText;
    public Text choice1, choice2, choice3, choice4;
    public GameObject dbox;
    public GameObject cbox;
    private PlayerController player;
    private DialogueNode currentNode;
    public bool exitDialogue;
    private float exitDiaTimer;
    private int placeInLine;
    public int choice;
    private Dialogue currentDialogue;
    // Use this for initialization
    void Start () {
        dbox.SetActive(false);
        cbox.SetActive(false);
        player = FindObjectOfType<PlayerController>();
        currentNode = new DialogueNode();
        exitDialogue = false;
        exitDiaTimer = 0;
        choice = -1;
        placeInLine = 0;
    }

    private void Update()
    {
        
        if(cbox.activeInHierarchy)
        {
            if(choice > -1)
            {
                ChooseOption(choice, currentDialogue);
                choice = -1;
            }
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        dbox.SetActive(true);
        cbox.SetActive(false);
		nameText.text = dialogue.name;
        if (dialogue.Nodes[0].Text != null)
        {
            dialogueText.text = dialogue.Nodes[0].Text;
        } else
        {
            dialogueText.text = dialogue.Nodes[0].Lines[0];
        }
        player.inDialogue = true;
        currentNode = dialogue.Nodes[0];
        dialogue.npc_talking = true;
        currentDialogue = dialogue;
        exitDialogue = false;
	}

    public void DisplayNPCLine(Dialogue dialogue) {
        cbox.SetActive(false);
        placeInLine = 0;
        dbox.SetActive(true);
        dialogue.npc_talking = true;
        if (currentNode.NodeID == -1) {
            EndDialogue(dialogue);
            return;
        }
        dialogueText.text = currentNode.Text;
	}
    public void DisplayNextLine(Dialogue dialogue)
    {
        placeInLine++;
        if (placeInLine < currentNode.Lines.Count)
        {
            dialogueText.text = currentNode.Lines[placeInLine];
        } else
        {
            placeInLine = 0;
            DisplayOptions(dialogue);
        }
    }
    public void DisplayOptions(Dialogue dialogue)
    {
        choice = -2;
        dialogue.npc_talking = false;
        dbox.SetActive(false);
        cbox.SetActive(true);
        choice1.text = currentNode.DialogueOptions[0].text;
        choice2.text = currentNode.DialogueOptions[1].text;
        choice3.text = currentNode.DialogueOptions[2].text;
        choice4.text = currentNode.DialogueOptions[3].text;
    }

    public void ChooseOption(int choice, Dialogue dialogue)
    {
        if (currentNode.DialogueOptions[choice].DestinationNodeID == -1)
        {
            EndDialogue(dialogue);
        }
            currentNode = dialogue.Nodes[currentNode.DialogueOptions[choice].DestinationNodeID];
        if (currentNode.startFight)
        {
            SceneManager.LoadScene("BattleScene");
        }
            choice1.text = "";
            choice2.text = "";
            choice3.text = "";
            choice4.text = "";
            DisplayNPCLine(dialogue);
    }
	public void EndDialogue(Dialogue dialogue) {
        dialogueText.text = "";
        dbox.SetActive(false);
        cbox.SetActive(false);
        exitDialogue = true;
        dialogue.npc_talking = false;
        currentDialogue = null;
        player.inDialogue = false;
	}

    public DialogueNode getCurrentNode()
    {
        return currentNode;
    }
    public void Choice1()
    {
        if(choice1.text != "")
            choice = 0;
    }
    public void Choice2()
    {
        if(choice2.text != "")
            choice = 1;
    }
    public void Choice3()
    {
        if(choice3.text != "")
            choice = 2;
    }
    public void Choice4()
    {
        if(choice4.text != "")
            choice = 3;
    }

}
