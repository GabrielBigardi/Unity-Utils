using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioEvent : ScriptableObject
{
    public abstract void Play(AudioSource source);
    public abstract void PlayLooping(AudioSource source);
    public abstract void PlayOneShot(AudioSource source);
}
