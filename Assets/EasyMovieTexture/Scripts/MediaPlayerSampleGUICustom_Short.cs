using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MediaPlayerSampleGUICustom_Short : MonoBehaviour {
	
	//public MediaPlayerCtrlCustom scrMedia;

	public Text consoleText;
	public Text consoleText2;
	public Text consoleDuration;	
	public Text consoleEnd;

	public GameObject[] videoManagers;
	private int currentVideoIndex = -1;

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
		if (currentVideoIndex != -1) {
			videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ().gameObject.SetActive (false);
			if (currentVideoIndex < videoManagers.Length - 2) {
				videoManagers [currentVideoIndex + 2].GetComponent<MediaPlayerCtrlCustom> ().gameObject.SetActive (true);
			}
			currentVideoIndex += 1;
			//Change current plan visibility
			videoManagers [currentVideoIndex].gameObject.transform.Translate (0, -100, 0);
			videoManagers [currentVideoIndex - 1].gameObject.transform.Translate (0, 100, 0);
		} else {
			currentVideoIndex += 1;
		}
		// On ne lance pas la vidéo sur le dernier VideoManager parce que c'est juste 
		if (currentVideoIndex != videoManagers.Length - 1) {
			MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
			mpcc.Stop ();
			mpcc.Play ();
		}
	}

	void OnGUI() {


		if (hideGUI) 
		{
			GUI.backgroundColor = Color.clear;
		}
		//Debug.Log ("Video index courant =" + currentVideoIndex);
		// Go to previous animation		
		//try{
		if (currentVideoIndex == -1 /*|| mpcc.GetSeekPosition () == mpcc.GetDuration () || mpcc.GetDuration () == 0*/) {

			// Next Animation moving around the screen
			if (currentVideoIndex < videoManagers.Length - 1) {
				if (GUI.RepeatButton (new Rect (posXNextAnimBtn [currentVideoIndex+1] * sUnitX, posYNextAnimBtn [currentVideoIndex+1] * sUnitY, btnWidth * sizeBtnModifierX [currentVideoIndex+1], btnHeight * sizeBtnModifierY [currentVideoIndex+1]), "")) {
					//Debug.Log ("NextAnimationBefore");
					if (currentVideoIndex < videoManagers.Length - 1) {
						LoadNextVideo ();
						m_bFinish = false;
					}
				}
			}

		} else{			
			MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
			if(mpcc.GetDuration () != 0 && mpcc.GetSeekPosition () == mpcc.GetDuration ()) {
				//Debug.Log ("Happened");
				consoleText.text = "Yay";
			} else if(mpcc.GetDuration () == 0) {			
				consoleText2.text = " " + currentVideoIndex;
				if(	currentVideoIndex < videoManagers.Length - 1 ){
					LoadNextVideo();
				}
			}
		}
		//}catch(Exception e){
			//consoleText2.text = ""+e.Message;
		//}

	}
	
	void OnEnd()
	{
		//scrMedia.Pause ();
		m_bFinish = true;
	}
}
