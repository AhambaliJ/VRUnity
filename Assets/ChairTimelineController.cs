using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChairTimelineController : MonoBehaviour {

	public List<PlayableDirector> playableDirector;

	public void Play() {

		playableDirector[0].Play();
	}
	
}
