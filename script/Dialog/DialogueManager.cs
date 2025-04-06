using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Dialogue
{
    public string characterName; // 角色名
    // public Sprite characterIcon; // 头像
    // [TextArea(3, 10)]
    public string[] sentences; // 对话内容数组
}

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogText;
    //[SerializeField] private Image characterIcon;
    [SerializeField] private GameObject dialogBox;
   

    private Queue<string> sentencesQueue = new Queue<string>();
    private Dialogue currentDialogue;
    private bool isTyping = false;

    void Start()
    {
        
        dialogBox.SetActive(false); // 初始隐藏对话框
    }
    
    void Update()
    {
        // 检测玩家输入（如按下空格键）
        if (Input.GetKeyDown(KeyCode.Space) && dialogBox.activeSelf)
        {
            DisplayNextSentence();
        }
    }

    // 开始新对话
    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        sentencesQueue.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }

        dialogBox.SetActive(true);
        //characterIcon.sprite = dialogue.characterIcon; // 设置头像
        DisplayNextSentence();
    }

    // 显示下一句
    public void DisplayNextSentence()
    {
        if (isTyping)
        {
            // 如果正在逐字显示，立即完成
            StopAllCoroutines();
            dialogText.text = sentencesQueue.Peek();
            isTyping = false;
            return;
        }

        if (sentencesQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentencesQueue.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    // 逐字显示效果
    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f); // 调整显示速度
        }
        isTyping = false;
    }

    // 结束对话
    void EndDialogue()
    {
        dialogBox.SetActive(false);
        // 触发后续事件（如任务更新）
    }
}