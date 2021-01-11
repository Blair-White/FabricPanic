using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text nameText;
    public Text dialogueText;

    private Queue<string> lines;
    void Start()
    {
        lines = new Queue<string>();
    }
    public void BeginDialogue (Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        lines.Clear();

        foreach (string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }
        DisplayNewLine();
    }
    public void DisplayNewLine()
    {
        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        string line = lines.Dequeue();
        dialogueText.text = line;
    }
    void EndDialogue()
    {
        Debug.Log("");
    }
}
