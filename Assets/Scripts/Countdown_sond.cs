using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown_sond : MonoBehaviour
{
    public AudioClip clip_321;
    public AudioClip clip_start;

    float remaining_time = 4.0f;

    bool justOnce_3 = false;
    bool justOnce_2 = false;
    bool justOnce_1 = false;
    bool justOnce_start = false;

    // Update is called once per frame
    void Update()
    {
        remaining_time -= Time.deltaTime;

        one_beep(3, ref justOnce_3);
        one_beep(2, ref justOnce_2);
        one_beep(1, ref justOnce_1);
        one_beep(0, ref justOnce_start);

    }
    void one_beep(int _range, ref bool _once)
    {
        if (remaining_time > _range && remaining_time < _range + 1)
        {
            if (!_once)
            {
                if (_range != 0)
                {
                    AudioSource.PlayClipAtPoint(clip_321, transform.position);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(clip_start, transform.position);
                }
                Debug.Log(_range);
                _once = true;
            }
        }
    }
}
