using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    public Transform tfNoteAppear = null;
    public GameObject goNote = null;

    TimeManager theTimeManager;

    private void Start()
    {
        theTimeManager = GetComponent<TimeManager>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >=60d / bpm)
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            theTimeManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            theTimeManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
