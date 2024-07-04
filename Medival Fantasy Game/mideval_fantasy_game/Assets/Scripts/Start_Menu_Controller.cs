using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Menu_Controller : MonoBehaviour{

    public Button one_player;
    public Button two_player;
    public GameObject play_button;
    public GameObject player_buttons;
    public GameObject[] loading_images;
    public GameObject start_menu_background_image;
    public Start_Data_Script Start_Data;
    private int image_num;

    void Start(){
        one_player.onClick.AddListener(OnOne_Player_Button);
        two_player.onClick.AddListener(OnTwo_Player_Button);
        player_buttons.SetActive(false);
        for(int image = 0; image < loading_images.Length; image++){
            loading_images[image].SetActive(false);
        }
        Start_Data = GameObject.Find("Start_Data").GetComponent<Start_Data_Script>();
    }

    public void OnPlayButton(){
        play_button.SetActive(false);
        player_buttons.SetActive(true);
        image_num = Random.Range(0, loading_images.Length);
    }

    public void OnOne_Player_Button(){
        Start_Data.num_players = 1;
        start_menu_background_image.SetActive(false);
        player_buttons.SetActive(false);
        loading_images[image_num].SetActive(true);
        SceneManager.LoadScene("World");
    }

    public void OnTwo_Player_Button(){
        Start_Data.num_players = 2;
        SceneManager.LoadScene("World");
    }
}
