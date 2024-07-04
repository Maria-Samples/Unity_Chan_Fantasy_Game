using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universal_Varible_Holder : MonoBehaviour
{
    // Start is called before the first frame update
    //public Start_Data_Script Start_Data;
    public bool Is_In_Inventory = false;
    public bool Is_UI_On = false;
    public bool Is_Gathering = false;
    public GameObject player;
    public Animator player_animator;
    private bool Gather_Update_Running = false;
    public bool Player_Getting_Hit = false;
    public int player_damage;
    public bool player_challenge = false;
    public bool player_fighting = false;
    public GameObject player2;
    public Animator player_animator_2;
    public bool Player_Getting_Hit_2 = false;
    public int player_damage_2;
    public bool player_challenge_2 = false;
    public bool player_fighting_2 = false;
    public string enemy_fighting;
    public bool has_logged = false;
    public List<string> player_inventory = new List<string>();
    Dictionary<string, int> levels = new Dictionary<string, int>();
    public int num_players;
    public bool player_running = false;
    void Start(){
        //Start_Data = GameObject.Find("Start_Data").GetComponent<Start_Data_Script>();
        num_players = 1;
        player = GameObject.FindWithTag("Player");
        player2 = GameObject.FindWithTag("Player2");
        player_animator = player.GetComponent<Animator>();
        levels.Add("Mushrun", 1);
        levels.Add("Player", 1);
    }

    // Update is called once per frame
    void Update(){
        Is_UI_On = Is_In_Inventory;
        if(Is_Gathering == true && Gather_Update_Running == false){
            StartCoroutine(Gather_Update());
            Gather_Update_Running = true;
        }
        if(player_challenge == true && has_logged == false){
            Debug.Log("Variable");
            has_logged = true;
            StartCoroutine(Player_Challenge());
        } 
    }

    IEnumerator Player_Challenge(){
        Debug.Log(player_challenge);
        yield return new WaitForSecondsRealtime(1.0f);
        player_challenge = false;
    }

    IEnumerator Gather_Update(){
        yield return new WaitForSecondsRealtime(1.8f);
        Is_Gathering = false;
        Gather_Update_Running = false;
    }
}
