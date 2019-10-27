using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Diagnostics;
class TestDialogue : UnityEngine.MonoBehaviour {
    // Use this for initialization

    public virtual void CreateDialogue() {
        XmlSerializer seri = new XmlSerializer(typeof(Dialogue));
        Dialogue dia = new Dialogue();
        DialogueNode node1 = new DialogueNode("Hi! I'm a normie.",null, false);
        List<string> line2 = new List<string>();
        line2.Add("AAA PUSI");
        line2.Add("HA!");
        DialogueNode node2 = new DialogueNode(null,line2, false);
        DialogueNode node3 = new DialogueNode("You don't stand a chance!",null, true);
        dia.AddNode(node1);
        dia.AddNode(node2);
        dia.AddNode(node3);
        dia.AddOption("Fight this normie", node1, node3);
        dia.AddOption("Run away like a pussi", node1, node2);
        dia.AddOption("EXIT", node2, null);
        StreamWriter streamWriter = new StreamWriter("testdialogue2.xml");
        seri.Serialize(streamWriter, dia);
    }

}
