using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Transform player;
    public Transform npc;
    public GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position,npc.position)< 5f)

        {
        print("Hello NPC!");
        

        dialogueBox.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}
