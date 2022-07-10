using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class AudioEvent : UnityEvent<bool , GameObject, AudioSource> { }

[System.Serializable]
public class AudioClipEvent : UnityEvent<AudioSource> { }
