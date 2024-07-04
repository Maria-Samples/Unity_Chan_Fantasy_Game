using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Controller : MonoBehaviour
{
    public Universal_Varible_Holder Outside_Variables;
    public GameObject player;
    private Vector3 player_cam_pos;
    public string type;
    private float dist;
    private bool Has_Gathered = false;
    void Start(){
        type = gameObject.tag;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update(){
        Outside_Variables = GameObject.Find("Universal_Variable_Holder").GetComponent<Universal_Varible_Holder>();
        dist = Vector3.Distance(player.transform.position, transform.position);
        if(Input.GetKeyUp(KeyCode.G) && dist < 5 && Has_Gathered == false){
            Outside_Variables.Is_Gathering = true;
            StartCoroutine(Gather());
        }
    }

    IEnumerator Gather(){
        if(Has_Gathered == false){
            yield return new WaitForSecondsRealtime(1.5f);
            Outside_Variables.player_inventory.Add(type);
            Debug.Log(type + Has_Gathered);
            Has_Gathered = true;
            Destroy(gameObject);
        }
    }
}

