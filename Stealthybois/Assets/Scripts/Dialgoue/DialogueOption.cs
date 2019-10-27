using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
[System.Serializable]
public class DialogueOption{
    public string text;
    public int DestinationNodeID;
	// Use this for initialization
	public DialogueOption() { }

    public DialogueOption(string txt, int id)
    {
        this.text = txt;
        this.DestinationNodeID = id;
    }
}
