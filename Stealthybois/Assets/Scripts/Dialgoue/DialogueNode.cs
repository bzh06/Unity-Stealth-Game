using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

public class DialogueNode{
    public string Text;
    public List<string> Lines;
    public bool startFight;
    public int NodeID = -1;
    public List<DialogueOption> DialogueOptions;

    public DialogueNode() { }

    public DialogueNode(string txt, List<string> lines, bool fight)
    {
        this.Text = txt;
        this.Lines = lines;
        this.startFight = fight;
        DialogueOptions = new List<DialogueOption>();
    }
}

