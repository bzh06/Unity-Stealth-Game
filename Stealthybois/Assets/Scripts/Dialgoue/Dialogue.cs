using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;


[System.Serializable]
public class Dialogue{
    public string name;
	[TextArea (3, 10)]
	public List<DialogueNode> Nodes;
    public bool npc_talking;
    public Dialogue()
    {
        Nodes = new List<DialogueNode>();
    }
    public void AddNode(DialogueNode node)
    {
        if (node != null)
        {
            Nodes.Add(node);
            node.NodeID = Nodes.IndexOf(node);
        }
    }

    public void AddOption(string text, DialogueNode node, DialogueNode dest)
    {
        if (!Nodes.Contains(dest))
            AddNode(dest);
        if (!Nodes.Contains(node))
            AddNode(node);

        DialogueOption option;

        if (dest == null)
            option = new DialogueOption(text, -1);
        else
            option = new DialogueOption(text, dest.NodeID);

        node.DialogueOptions.Add(option);
    }

    

}
