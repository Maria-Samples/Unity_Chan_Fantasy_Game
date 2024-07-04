using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Data_Script : MonoBehaviour
{
    public static Start_Data_Script Instance;
    public int num_players;
    
    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
