using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant_Nolan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Animator character_controller;
    public Camera mainCamera;
    private Vector3 player_cam_pos;
    private float dist;
    public float interact_button;
    public Conversations first_conversation;
    public GameObject Dialogue_Controller;
    public Dialogue_Reader first_test;
    public bool first_time_speak = true;
    void Start()
    {
        character_controller = GetComponent<Animator>();
        first_test = Dialogue_Controller.GetComponent<Dialogue_Reader>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            dist = Vector3.Distance(player.transform.position, transform.position);
            player_cam_pos = mainCamera.WorldToViewportPoint(transform.position);
            if(first_time_speak == true && dist < 10 && player_cam_pos != null){
                Debug.Log("Speak");
                first_test.StartCoroutine(first_test.Read_Dialogue(first_conversation));
            }
        }
    }
}
