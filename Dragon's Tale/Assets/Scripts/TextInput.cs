using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;

    [HideInInspector] public ChapterNavigation chapterNavigation;

    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();

        chapterNavigation = GetComponent<ChapterNavigation>();

        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        if (userInput != "")
        {
            userInput = userInput.ToLower();

            for (int i = 0; i < chapterNavigation.currentChapter.ends.Length; i++)
            {
                if (userInput == chapterNavigation.currentChapter.ends[i].keystring)
                {
                    controller.LogStringWithReturn(chapterNavigation.currentChapter.ends[i].endDesciption);

                    InputComplete();

                    chapterNavigation.AttemptToChangeChapters(i, userInput);
                }
            }
        }
        else 
        {
            controller.LogStringWithReturn("Please make a choice");
        }
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
