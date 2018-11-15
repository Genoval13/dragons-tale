using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Chapter")]
public class Chapter : ScriptableObject
{
    [TextArea]
    public string storyText;
    public string chapterTitle;
    public End[] ends;
}
