using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaundryManager : MonoBehaviour
{
    public static LaundryManager LM;


    public Text dialogueBox;
    public Text laundryCountUI;

    private int laundryCounter;
    public string[] laundryDialogue;
    public string[] coffeeDialogue;
    public string[] sushiDialogue;
    public string[] inariDialogue;
    
    void Start()
    {
        // SINGLETON 
        if (LM == null)
        {
            DontDestroyOnLoad(gameObject);
            LM = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //start laundry dialogue to 0
        laundryCounter = 0;

    }

    void Update()
    {
        
    }
    
    
}
