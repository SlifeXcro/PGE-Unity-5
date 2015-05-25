﻿using UnityEngine;
using System.Collections;

//Parent Class for all Buttons
public class Button : MonoBehaviour
{
    //Flag to determine if Button has been selected
    public bool Selected = false;

    //Flag to determine when to execute Buttons's function
    protected bool bHold = false;
    public bool Execute = false;

    // 0 - Default Tex
    // 1 - Selected Tex
    public Sprite[] Tex = new Sprite[2];
    public Sprite SpriteToChange;

    public enum BType
    {
        BUTTON_DEFAULT,
        BUTTON_PAUSE,      
        BUTTON_COMBAT,
        BUTTON_CAM,
        BUTTON_A,
        BUTTON_B
    } public BType ButtonType = BType.BUTTON_DEFAULT;

    //Every Button has its own Function
    public virtual void ExecuteFunction()
    {
        Debug.Log("Button Clicked!");
    }

    //Parent Update
    public void StaticUpdate()
    {
        //True = Click (Ergo not !bHold), False = Hold (Ergo bHold)
        if (InputScript.Instance.InputCollided(this.gameObject.GetComponent<Collider>(), !bHold))
        {
            SpriteToChange = Tex[1]; //Change to Clicked Sprite
            Execute = Selected = true;
            ExecuteFunction();
        }
        else
        {
            SpriteToChange = Tex[0]; //Reset to Default Sprite
            Execute = Selected = false;
        }
    }

    //Update is called once per frame
    void Update()
    {
        StaticUpdate();
    }
}
