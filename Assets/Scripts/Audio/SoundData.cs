using System.Collections.Generic;
using UnityEngine;
namespace SlotGame
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObject/SoundData")]
    public class SoundData : ScriptableObject
    {
        public List<AudioData> AudioDatas = new List<AudioData>();
    }

    [System.Serializable]
    public class AudioData
    {
        public enum EAudio
        {
            BackGroundMusic,
            ButtonPress,
            SpinButtonPress,
            SpinStop,
            SpinSound

        }
        public EAudio AudioID;
        public AudioClip AudioClip;
    }
}