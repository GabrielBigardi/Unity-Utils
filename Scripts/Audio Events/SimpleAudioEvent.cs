using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unity Utils/Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] clips;

    public RangedFloat volume;

    [MinMaxRange(0, 2)]
    public RangedFloat pitch;

    public SimpleAudioEvent()
    {
        volume = new RangedFloat(1f,1f);
        pitch = new RangedFloat(1f, 1f);

    }
    
    public override void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.loop = false;
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(volume.minValue, volume.maxValue);
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.Play();
    }

    public override void PlayLooping(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.loop = true;
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(volume.minValue, volume.maxValue);
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.Play();
    }

    public override void PlayOneShot(AudioSource source)
    {
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.PlayOneShot(clips[Random.Range(0, clips.Length)], Random.Range(volume.minValue, volume.maxValue));
    }
}
