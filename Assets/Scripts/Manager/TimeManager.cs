using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    public Transform Center = null;
    public RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    EffectManager theEffect;

    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();

        timingBoxs = new Vector2[4];
        for(int i=0; i<4; i++)
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
                if(timingBoxs[x].x <= t_notPosX+10 && t_notPosX-10 <= timingBoxs[x].x)
                {
                    // 노트 제거
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    // 이펙트 연출
                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();
                    Debug.Log(x);
                    theEffect.JudgementEffect(x);

                    return;
                }
            }
        }
    //    theEffect.JudgementEffect(timingBoxs.Length-1);
    }
}
