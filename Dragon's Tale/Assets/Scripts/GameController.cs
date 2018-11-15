using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text displayText;

    [HideInInspector] public ChapterNavigation chapterNavigation;
    [HideInInspector] public List<string> playerChoices = new List<string>();

    List<string> storyLog = new List<string>();

	void Awake () {
        chapterNavigation = GetComponent<ChapterNavigation>();
	}

    void Start()
    {
        DisplayChapterText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", storyLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayChapterText()
    {
        ClearCollectionsForNewChapter();

        UnpackChapter();

        string joinedEndDescriptions = string.Join("\n", playerChoices.ToArray());

        string combinedText = chapterNavigation.currentChapter.storyText + "\n";

        LogStringWithReturn(combinedText);
    }

    private void UnpackChapter()
    {
        chapterNavigation.UnpackChoicesInChapter(); 
    }

    void ClearCollectionsForNewChapter()
    {
        playerChoices.Clear();
        chapterNavigation.ClearEndings();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        storyLog.Add(stringToAdd + "\n");
    }
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
