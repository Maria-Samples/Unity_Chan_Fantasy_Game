using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character_Controller : MonoBehaviour
{
    public GameObject Univeral_Var;
    public float speed;
    public GameObject thirdPersonCamera;
    public GameObject firstPersonCamera;
    public Camera Camera_First;
    public Camera Camera_Third;
    public float rotation_speed;
    public float jump_speed;
    public float Horizontal_Input;
    public float Vertical_Input;
    private Animator player_anim;
    private Rigidbody player_rigidbody;
    public bool UI_bool;
    public Universal_Varible_Holder Outside_Variables;
    public int health = 35;
    public float head_bob_speed = 0.3f;
    public float head_bob_strength = 0.03f;
    public bool firstPersonCam = false;
    private bool is_jumping = false;

    
    void Start()
    {
        player_anim = GetComponent<Animator>();
        player_rigidbody = GetComponent<Rigidbody>();
        player_rigidbody.freezeRotation = true;
        Camera_Third.rect = new Rect(0, 0.0f, 1.0f - 0 * 2.0f, 1.0f);
    }

    void Update(){
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        Horizontal_Input = Input.GetAxis("Horizontal");
        Vertical_Input = Input.GetAxis("Vertical");
        if(Vertical_Input != 0 && Outside_Variables.Is_UI_On == false){
            if(Input.GetKeyDown(KeyCode.Space) && Outside_Variables.Is_UI_On == false){
                transform.Translate(0, jump_speed * Time.deltaTime, speed * Vertical_Input * Time.deltaTime);
                StartCoroutine(Jump());
            }else{
                transform.Translate(0, 0, speed * Vertical_Input * Time.deltaTime);
                player_anim.SetBool("Run", true);
            }
            Outside_Variables.player_running = true;
        }
        if(Horizontal_Input != 0 && Outside_Variables.Is_UI_On == false){
            transform.Rotate(Vector3.up, rotation_speed * Horizontal_Input * Time.deltaTime);
            if(is_jumping == false){
                player_anim.SetBool("Run", true);
            }
        }
        if(Horizontal_Input == 0 && Vertical_Input == 0 && Outside_Variables.Is_UI_On == false){
            player_anim.SetBool("Run", false);
        }


        if(Outside_Variables.num_players == 2){
            if(Input.GetKeyDown(KeyCode.X) && Outside_Variables.Is_UI_On == false){
                player_anim.SetTrigger("Kick");
            }
            if(Input.GetKeyDown(KeyCode.Z) && Outside_Variables.Is_UI_On == false){
                player_anim.SetTrigger("Left_Punch");
            }
            if(Input.GetKeyDown(KeyCode.C) && Outside_Variables.Is_UI_On == false){
                player_anim.SetTrigger("Right_Punch");
            }
        }
        if(Outside_Variables.num_players == 1){ 
            if(Input.GetKeyDown(KeyCode.K) && Outside_Variables.Is_UI_On == false){
                player_anim.SetTrigger("Kick");
            }
            if(Input.GetKeyDown(KeyCode.J) && Outside_Variables.Is_UI_On == false){
                player_anim.SetTrigger("Left_Punch");
            }
            if(Input.GetKeyDown(KeyCode.L) && Outside_Variables.Is_UI_On == false){
                player_anim.SetTrigger("Right_Punch");
            }
        }
        

        if(Input.GetKeyDown(KeyCode.G) && Outside_Variables.Is_UI_On == false && Outside_Variables.Is_Gathering == true){
                player_anim.SetTrigger("Gather");
        }
        if(transform.position.y < -0.2){
            transform.Translate(0, 1, 0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            thirdPersonCamera.SetActive(true);
            firstPersonCamera.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            thirdPersonCamera.SetActive(false);
            firstPersonCamera.SetActive(true);
            firstPersonCam = true;
        }
    }
    IEnumerator Jump(){
        is_jumping = true;
        transform.Translate(0, jump_speed * 1 * Time.deltaTime, 0);
        player_anim.SetTrigger("Jump");
        yield return new WaitForSecondsRealtime(1.25f);
        is_jumping = false;
    }
}