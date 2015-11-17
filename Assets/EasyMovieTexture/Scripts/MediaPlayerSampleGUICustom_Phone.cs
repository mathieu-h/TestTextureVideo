using UnityEngine;
using System.Collections;
using System;

public class MediaPlayerSampleGUICustom_Phone : MonoBehaviour {
	
	//public MediaPlayerCtrlCustom scrMedia;

	public GameObject[] videoManagers;
	private int currentVideoIndex = 0;

	private int dividerW = 12;
	private int dividerH = 16;
	// Height and width of the buttons, directly defined by the dividers
	private int btnWidth; 
	private int btnHeight;
	
	private float spaceBtnH = 25f;	
	private float spaceBtnW = 25f;
	
	// Unit of space in the X and Y axis to set the position of the button Next easier
	private float sUnitX;
	private float sUnitY;
	
	public bool m_bFinish = false;
	public bool hideGUI;
	// Array of positions of the next button, one index for one animation (video)
	private float[] posXNextAnimBtn;
	private float[] posYNextAnimBtn;

	private float[] sizeBtnModifierX; 	
	private float[] sizeBtnModifierY; 

	//index where we begin to preload the video
	private int f_indexTexturePreLastVid ;
	private int f_indexTextureLastVid;

	//private Boolean didBug = false;

	//private MediaPlayerFullScreenCtrlCustom mdpFSC;
	private MediaPlayerCtrlCustom mpccInit;

	void OnEnable()
	{
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {
		f_indexTexturePreLastVid = 3;
		f_indexTextureLastVid = videoManagers.Length-1;

		//scrMedia.OnEnd += OnEnd;
		btnWidth = Screen.width/dividerW; 
		btnHeight = Screen.height/dividerH;
		sUnitX = Screen.width / spaceBtnW;
		sUnitY = Screen.height / spaceBtnH;	

		
		posXNextAnimBtn = new float[1]{ 3.5f};
		posYNextAnimBtn = new float[1]{ 0.5f};

		sizeBtnModifierX = new float[1]{ 10.25f};		
		sizeBtnModifierY = new float[1]{ 15.5f};

	}

	private void LoadNextVideo(){
		//Debug.Log (currentVideoIndex);
		videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ().gameObject.SetActive (false);
		if (currentVideoIndex < videoManagers.Length - 2) {
			videoManagers [currentVideoIndex + 2].GetComponent<MediaPlayerCtrlCustom> ().gameObject.SetActive (true);
		}
		// Change current plane visibility with renderer
		currentVideoIndex += 1;

		/*if (currentVideoIndex == f_indexTextureLastVid) {			
			//Debug.Log ("Force change 8 ! :" + currentVideoIndex);
			videoManagers [currentVideoIndex - 1].gameObject.transform.Translate (0, 100, 0);
			videoManagers [currentVideoIndex].gameObject.SetActive(false);
			videoManagers [f_indexTexturePreLastVid].gameObject.SetActive (true);
			videoManagers [f_indexTexturePreLastVid].gameObject.transform.Translate (0, -100, 0);			
			videoManagers [f_indexTexturePreLastVid].GetComponent<MediaPlayerCtrlCustom> ().Stop();
			videoManagers [f_indexTexturePreLastVid].GetComponent<MediaPlayerCtrlCustom> ().Play();
		} else {*/
			//videoManagers [currentVideoIndex+1].GetComponent<MediaPlayerCtrlCustom>().gameObject.SetActive(true);
			MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
			videoManagers [currentVideoIndex].gameObject.transform.Translate (0, -100, 0);
			videoManagers [currentVideoIndex - 1].gameObject.transform.Translate (0, 100, 0);
			mpcc.Stop ();
			mpcc.Play ();
		/*}
		if (currentVideoIndex == f_indexTextureLastVid-1) {			
			//Debug.Log ("Preload " + currentVideoIndex);
			Material material = Resources.Load("bg_09", typeof(Material)) as Material;
			videoManagers[f_indexTexturePreLastVid].GetComponent<MeshRenderer>().material = material;
			videoManagers[f_indexTexturePreLastVid].GetComponent<MediaPlayerCtrlCustom> ().Load ("Ball-RA-09.mp4");
		}*/
	}

	void OnGUI() {

		if (hideGUI) 
		{
			GUI.backgroundColor = Color.clear;
		}
		//Debug.Log ("Video index courant =" + currentVideoIndex);
		MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
		// Go to previous animation		

		if (currentVideoIndex == 0 || mpcc.GetSeekPosition () == mpcc.GetDuration () || mpcc.GetDuration () == 0) {

			// Next Animation moving around the screen
			if (currentVideoIndex < videoManagers.Length - 1) {
				if (GUI.RepeatButton (new Rect (posXNextAnimBtn [currentVideoIndex] * sUnitX, posYNextAnimBtn [currentVideoIndex] * sUnitY, btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]), "")) {
					//Debug.Log ("NextAnimationBefore");
					if (currentVideoIndex < videoManagers.Length - 1) {
						LoadNextVideo ();
						m_bFinish = false;
					}
				}
			}
		}

	}
	
	void OnEnd()
	{
		//scrMedia.Pause ();
		m_bFinish = true;
	}
}
