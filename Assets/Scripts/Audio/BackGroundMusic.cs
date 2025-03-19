using UnityEngine;
namespace SlotGame
{
    public class BackGroundMusic : MonoBehaviour
    {
        /// <summary>
        /// audio source for background music play
        /// </summary>
        private AudioSource backgroundMusic = new AudioSource();
       

        /// <summary>
        /// Stop playing the background music
        /// </summary>
        public void StopBgMusic()
        {
            Destroy(backgroundMusic.gameObject);
        }
        /// <summary>
        /// start playing background music
        /// </summary>
        public void StartBgMusic()
        {
            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
                return;
            }
            backgroundMusic = AudioManager.Instance.Play(AudioData.EAudio.BackGroundMusic, .35f, true, AudioManager.AudioType.Music);
        }
        /// <summary>
        /// change background music
        /// </summary>
        /// <param name="Audio">name of the audioclip</param>
  

        void OnDestroy()
        {
            Destroy(backgroundMusic);
        }
    }
}