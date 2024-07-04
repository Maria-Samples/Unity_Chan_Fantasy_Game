using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Reader : MonoBehaviour
{
    public GameObject Dialogue_Box;
    public GameObject Choice_Box;
    public TextMeshProUGUI Dialogue_Text;
    public TextMeshProUGUI[] Dialogue_Options;
    public Button[] Dialogue_Button_Options;
    private int current_section = 0;
    private int num_dialogue = 0;
    private bool talking = true;
    private bool space_down = false;
    public int button_pressed = 9;
    void Start(){
        Dialogue_Button_Options[0].onClick.AddListener(() => num_dialogue_pressed(0));
        Dialogue_Button_Options[1].onClick.AddListener(() => num_dialogue_pressed(1));
        Dialogue_Button_Options[2].onClick.AddListener(() => num_dialogue_pressed(2));
        Dialogue_Button_Options[3].onClick.AddListener(() => num_dialogue_pressed(3));
    }
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            space_down = true;
        }
    }

    public IEnumerator Read_Dialogue(Conversations conv){
        Dialogue_Box.SetActive(true);
        Choice_Box.SetActive(true);
        while(talking == true){
            num_dialogue = 0;
            Debug.Log("run");
            while(num_dialogue < conv.Sections[current_section].Dialogue.Length){
                Debug.Log(conv.Sections[current_section].Dialogue[num_dialogue]);
                Dialogue_Text.text = conv.Sections[current_section].Dialogue[num_dialogue];
                yield return new WaitUntil(() => space_down == true);
                space_down = false;
                num_dialogue += 1;
            }
            if(conv.Sections[current_section].End_Dialogue == true){
                Dialogue_Box.SetActive(false);
                Choice_Box.SetActive(false);
                break;
            }
            Debug.Log(conv.Sections[current_section].Dialogue_Branches.Question);
            Dialogue_Text.text = conv.Sections[current_section].Dialogue_Branches.Question;
            yield return new WaitUntil(() => space_down == true);
            space_down = false;
            for(int x = 0; x < conv.Sections[current_section].Dialogue_Branches.Answers.Length; x++){
                Dialogue_Options[x].text = conv.Sections[current_section].Dialogue_Branches.Answers[x].Answer;
            }
            yield return new WaitUntil(() => button_pressed != 9);
            Debug.Log(current_section);
            current_section = conv.Sections[current_section].Dialogue_Branches.Answers[button_pressed].Next_Section_Index-1;
            button_pressed = 9;
            for(int i = 0; i < Dialogue_Options.Length; i++){
                Dialogue_Options[i].text = "";
            }
        }
    }
    void num_dialogue_pressed(int num){
        button_pressed = num;
    }
}
