using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400f;
    UnityEngine.UI.Image noteImage;

    private void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }

    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;
    }


}
