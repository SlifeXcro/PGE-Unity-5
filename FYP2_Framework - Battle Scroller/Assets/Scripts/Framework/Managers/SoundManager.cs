using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public enum Sounds
	{
		MAIN_BGM
	}	
	public static SoundManager Instance { get; private set; }
	
	
	void Awake()
	{
		Instance = this;
		Object.DontDestroyOnLoad(this.gameObject);
	}
	
	public void PlaySound(Sounds SoundType)
	{
	
	
	}
}

