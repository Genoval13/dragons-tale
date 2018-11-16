using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterNavigation : MonoBehaviour {
    public Chapter currentChapter;

    Dictionary<string, Chapter> endingDictionary = new Dictionary<string, Chapter>();
    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackChoicesInChapter()
    {
        for (int i = 0; i < currentChapter.ends.Length; i++)
        {
            endingDictionary.Add(currentChapter.ends[i].keystring, currentChapter.ends[i].valueChapter);
            controller.playerChoices.Add(currentChapter.ends[i].endDesciption);
        }
    }

    public void AttemptToChangeChapters(int endingNumber, string choiceLetter)
    {
        if (endingDictionary.ContainsKey(choiceLetter))
        {
            currentChapter = currentChapter.ends[endingNumber].valueChapter;
            controller.DisplayChapterText();
        }
    }

    public void ClearEndings()
    {
        endingDictionary.Clear();
    }
}
