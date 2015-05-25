﻿using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour
{
    //Singleton Structure
    protected static InputScript mInstance;
    public static InputScript Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject tempObj = new GameObject();
                mInstance = tempObj.AddComponent<InputScript>();
                Destroy(tempObj);
            }
            return mInstance;
        }
    }

    public static bool TouchDown = false;

    //Use this for initialization
    void Start()
    {
        mInstance = this;
    }

    //Process User Input
    public bool InputCollided(Collider col, bool Select = false)
    {
        Vector3 WorldPos, TouchPos;
        WorldPos = TouchPos = Vector3.zero;

        bool proceed = false;
#if UNITY_EDITOR || UNITY_STANDALONE
        WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TouchPos = new Vector3(WorldPos.x, WorldPos.y, 0);
#elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            WorldPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (Select && touch.phase == TouchPhase.Began)
                proceed = true;
        }
        TouchPos = new Vector3(WorldPos.x, WorldPos.y, 0);
#endif

        if (col.bounds.Contains(TouchPos))
        {
            if (Select)
            {
#if UNITY_EDITOR || UNITY_STANDALONE
                if (Input.GetMouseButtonDown(0))
                    proceed = true;
#endif
                return proceed;
            }
            else return true;
        }
        return false;
    }

    //Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
            TouchDown = true;
        if (Input.GetMouseButtonUp(0))
            TouchDown = false;
#elif UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
                TouchDown = true;
            if (touch.phase == TouchPhase.Ended)
                TouchDown = false;
        }
#endif
    }
}
