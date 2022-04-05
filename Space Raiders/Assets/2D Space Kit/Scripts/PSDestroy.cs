using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PSDestroy : MonoBehaviour {

	public AudioSource clip;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, GetComponent<ParticleSystem>().duration);
		clip.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
