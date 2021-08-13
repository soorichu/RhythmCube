using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public Animator noteHitAnimator;
    public Animator judgementAnimator;
    string hit = "Hit";

    public Sprite[] judgementSprite;
    UnityEngine.UI.Image judgementImage = null;

    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }

    public void JudgementEffect(int p_num)
    {
        judgementImage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }
}
