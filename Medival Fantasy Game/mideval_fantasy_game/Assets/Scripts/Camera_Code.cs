using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Code : MonoBehaviour{
    public GameObject player;
    public Universal_Varible_Holder Outside_Variables;
    public float speed;
    public float rotation_speed;
    public float Horizontal_Input;
    public float Vertical_Input;
    private Vector3 newRotation;
    private string in_front_of_camera;
    private Ray raycast = new Ray(new Vector3(0,0,0), new Vector3(0,0,0));
    private RaycastHit hitData;
    private GameObject hitObject = null;
    private Renderer game_object__render = null;
    public int x = 0;
    public int y = 25;
    public int z = -50;
    void Start(){
    }
    //xp:6.430013, yp:2.24, yp:1.009993; rx:10.163, ry:-80.339, rz:6.329
    void Update(){
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        raycast.origin = transform.position;
        raycast.direction = transform.forward;
        if (Physics.Raycast(raycast, out hitData)){
            if (hitData.transform != null && hitData.transform.gameObject != hitObject){
                if (game_object__render != null){
                    game_object__render.enabled = true;
                }
                hitObject = hitData.transform.gameObject;
                game_object__render = hitObject.GetComponent<Renderer>();
            }
            if (hitObject != null && hitObject.tag == "Wall"){
                game_object__render.enabled = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.T)){
            StartCoroutine(Fight_Move());
        }
    }
    IEnumerator Fight_Move(){
        //int distance_move = (Vector.Distance(enemy.transform.position, transform.position)+Vector.Distance(player.transform.position, transform.position))/2;
        transform.localPosition = new Vector3(-0.03f, 22.55f, -0.32f);
        transform.Rotate(72.266f, 0.0f, 0.0f);
        yield return null;
    }
}