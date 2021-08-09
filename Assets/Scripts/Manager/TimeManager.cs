﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    public Transform Center = null;
    public RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];
        for(int i=0; i<timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    {
        for(int i=0; i<boxNoteList.Count; i++)
        {
            float t_notPosX = boxNoteList[i].transform.localPosition.x;

            for(int x=0; x < timingBoxs.Length; x++)
            {
                if(timingBoxs[x].x <= t_notPosX && t_notPosX <= timingBoxs[x].y)
                {
                    //Destroy(boxNoteList[i]);
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log("Hit " + x);
                    return;
                }
            }
        }
        Debug.Log("Miss");
    }
}