using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Person_Camera_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    // public float bobSpeed;
    // public float bobHeight;
    // public float speed;
    // public float pivot;
    public Universal_Varible_Holder Outside_Variables;
    public bool not_stop_running = true;
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        if(Outside_Variables.player_running == true && not_stop_running == true){
            transform.Rotate(-10, 0, 0);
            not_stop_running = false;
        }
        if(Outside_Variables.player_running == false && not_stop_running == false){
            not_stop_running = true;
            transform.Rotate(20, 0, 0);
        }
    }
}
