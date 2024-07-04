using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Shut_Door : MonoBehaviour
{
    public GameObject Door_Hinge;
    public bool left_door;
    private bool door_open = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            if(door_open == false){
                if(left_door == true){
                    StartCoroutine(Left_Open_Door());
                }else{
                    StartCoroutine(Right_Open_Door());
                }
                door_open = true;
            }else{
                if(left_door == true){
                    StartCoroutine(Left_Close_Door());
                }else{
                    StartCoroutine(Right_Close_Door());
                }
                door_open = false;
            }
        }
    }
    IEnumerator Left_Open_Door(){
        for(int x = 0; x < 90; x++){
            transform.RotateAround(Door_Hinge.transform.position, Vector3.up, 1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
    IEnumerator Left_Close_Door(){
        for(int x = 0; x < 90; x++){
            transform.RotateAround(Door_Hinge.transform.position, Vector3.up, -1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
    IEnumerator Right_Open_Door(){
        for(int x = 0; x < 90; x++){
            transform.RotateAround(Door_Hinge.transform.position, Vector3.up, -1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
    IEnumerator Right_Close_Door(){
        for(int x = 0; x < 90; x++){
            transform.RotateAround(Door_Hinge.transform.position, Vector3.up, 1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
