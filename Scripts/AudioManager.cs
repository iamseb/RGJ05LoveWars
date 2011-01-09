// /////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audio Manager.
//
// This code is release under the MIT licence. It is provided as-is and without any warranty.
//
// Developed by Daniel Rodríguez (Seth Illgard) in April 2010
// http://www.silentkraken.com
//
// /////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	public AudioClip[] music;
	private ArrayList audios;

	void Start(){
		audios = new ArrayList();
		foreach(AudioClip c in music){
			AudioSource s = Managers.Audio.AddAndPlay(c, true);
			s.volume = 0;
		}
	}
	
	void Awake(){
		audios = new ArrayList();
	}
	
	public void SetActive(int[] sources){
		foreach(AudioSource s in audios){
			int idx = audios.IndexOf(s);
			float targetVolume = 0.0f;
			foreach(int i in sources){
				Debug.Log("Checking source " + idx + " against argument " + i);
				if(i == idx){
					targetVolume = 1.0f;
					break;
				}
			}
			StartCoroutine(SetTargetVolume(idx, targetVolume, 2.0f));
		}
	}
	
	public IEnumerator SetTargetVolume(int idx, float targetVolume, float seconds){
		Debug.Log("Called to set " + idx + " to volume " + targetVolume + " over " + seconds + " seconds.");
		AudioSource s = (AudioSource)audios[idx];
		float currentVolume = s.volume;
		// take the difference between the current and target volume
		float volumeChange = targetVolume - currentVolume;
		float step = volumeChange / seconds / 10.0f;
		for(float i=0; i<seconds; i+= 0.1f){
			s.volume += step;
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	public AudioSource AddAndPlay(AudioClip clip, bool loop){
		AudioSource s = Play(clip, Vector3.zero, loop);
		audios.Add(s);
		return s;
	}
	
    public AudioSource Play(AudioClip clip, Transform emitter)
    {
        return Play(clip, emitter, 1f, 1f);
    }

    public AudioSource Play(AudioClip clip, Transform emitter, float volume)
    {
        return Play(clip, emitter, volume, 1f);
    }

    /// <summary>
    /// Plays a sound by creating an empty game object with an AudioSource
    /// and attaching it to the given transform (so it moves with the transform). Destroys it after it finished playing.
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="emitter"></param>
    /// <param name="volume"></param>
    /// <param name="pitch"></param>
    /// <returns></returns>
    public AudioSource Play(AudioClip clip, Transform emitter, float volume, float pitch)
    {
        //Create an empty game object
        GameObject go = new GameObject ("Audio: " +  clip.name);
        go.transform.position = emitter.position;
        go.transform.parent = emitter;

        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play ();
        Destroy (go, clip.length);
        return source;
    }

    public AudioSource Play(AudioClip clip, Vector3 point, bool loop)
    {
        return Play(clip, point, 1f, 1f, loop);
    }

    public AudioSource Play(AudioClip clip, Vector3 point, float volume)
    {
        return Play(clip, point, volume, 1f, false);
    }

    /// <summary>
    /// Plays a sound at the given point in space by creating an empty game object with an AudioSource
    /// in that place and destroys it after it finished playing.
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="point"></param>
    /// <param name="volume"></param>
    /// <param name="pitch"></param>
    /// <returns></returns>
    public AudioSource Play(AudioClip clip, Vector3 point, float volume, float pitch, bool loop)
    {
        //Create an empty game object
        GameObject go = new GameObject("Audio: " + clip.name);
        go.transform.position = point;

        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
		source.loop = loop;
        source.Play();
		if(!loop)
        	Destroy(go, clip.length);
        return source;
    }
}
