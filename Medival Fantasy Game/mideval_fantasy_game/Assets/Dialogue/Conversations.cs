using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Conversations : ScriptableObject
{
    // Start is called before the first frame update
    public DialogueSections[] Sections;


    [System.Serializable]
    public struct DialogueSections{
        public int SectionIndex;
        [TextArea]
        public string[] Dialogue;
        public bool End_Dialogue;
        public Dialogue_Branch Dialogue_Branches;
    }

    [System.Serializable]
    public struct Dialogue_Branch{
        [TextArea]
        public string Question;
        public Answers[] Answers;
    }

    [System.Serializable]
    public struct Answers{
        [TextArea]
        public string Answer;
        public int Next_Section_Index;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
