using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Controller : MonoBehaviour
{
    public GameObject player;
    public Universal_Varible_Holder Outside_Variables;
    public Animator mushroom_anim;
    public float distance_player;
    public float speed;
    public float rotateSpeed;
    public Camera mainCamera;
    private Vector3 player_cam_pos;
    public float health = 30;
    private string type;
    private bool hit = false;
    private bool dizzy = false;
    private int num_kicks = 0;
    private int rand_attack;
    public Vector3 playerDirection;
    public Vector3 newDirection;
    public Collider[] Other_Characters;
    public int level;
    public bool threatened = false;
    public string[] states = new string[] {"Run_Away", "Play", "Attack", "Walk", "Threaten", "Idle"};
    private string in_front_of_camera;
    private Ray raycast = new Ray(new Vector3(0,0,0), new Vector3(0,0,0));
    private RaycastHit hitData;
    private GameObject hitObject = null;
    private Renderer game_object__render = null;

    void Start(){
        mushroom_anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        type = gameObject.tag;
        mainCamera = Camera.main;
    }


    public bool has_fight = false;
    void Update(){
        Other_Characters = Physics.OverlapSphere(transform.position, 45);
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        rand_attack = Random.Range(1,4);
        player_cam_pos = mainCamera.WorldToViewportPoint(transform.position);
        distance_player = Vector3.Distance(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));
        if(distance_player <= 13 && player_cam_pos != null && (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.J)) && rand_attack != 2){
            health = health - 5;
            if(Input.GetKeyDown(KeyCode.K)){
                num_kicks++;
            }
            StartCoroutine(isDead());
        }
        if(distance_player <= 7){
            Outside_Variables.player_fighting = true;
        }
    }
    IEnumerator isDead(){
        if(health <= 0){
            StartCoroutine(Die());
        }else{
            if(num_kicks >= 3){
                StartCoroutine(Dizzy());
                num_kicks = 0;
            }else if(dizzy == false && hit == false){
                hit = true;
                mushroom_anim.SetBool("Damage", true);
                Debug.Log("Damage");
                yield return new WaitForSecondsRealtime(1.0f);
                mushroom_anim.SetBool("Damage", false);
                hit = false;
            }
        }
    }
    IEnumerator Die(){
        mushroom_anim.SetTrigger("Die");
        yield return new WaitForSecondsRealtime(2.0f);
        Outside_Variables.player_inventory.Add("Mushrun");
        Destroy(gameObject);
    }
    IEnumerator Dizzy(){
        mushroom_anim.SetBool("Dizzy", true);
        dizzy = true;
        yield return new WaitForSecondsRealtime(2.0f);
        mushroom_anim.SetBool("Dizzy", false);
        dizzy = false;
        hit = false;
    }
    public void Interact(GameObject other){
        other.SendMessage(type);
        Debug.Log("Interact");
    }
}
