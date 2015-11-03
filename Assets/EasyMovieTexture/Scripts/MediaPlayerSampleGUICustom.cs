using UnityEngine;
using System.Collections;
using System;

public class MediaPlayerSampleGUICustom : MonoBehaviour {
	
	//public MediaPlayerCtrlCustom scrMedia;
	
	public string strNextScene;
	
	
	public string[] strVideoName;
	public GameObject[] videoManagers;
	
	private int nextPrevSizeDivider = 8;
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

	//private Boolean didBug = false;

	private MediaPlayerFullScreenCtrlCustom mdpFSC;
	private MediaPlayerCtrlCustom mpccInit;

	void OnEnable()
	{
		Application.targetFrameRate = 60;
	}

	// Use this for initialization
	void Start () {


		//scrMedia.OnEnd += OnEnd;
		btnWidth = Screen.width/dividerW; 
		btnHeight = Screen.height/dividerH;
		sUnitX = Screen.width / spaceBtnW;
		sUnitY = Screen.height / spaceBtnH;	

		
		//posXNextAnimBtn = new float[8]{ 9, 19, 15, 17, 17, 17, 16, 16};
		//posYNextAnimBtn = new float[8]{ 1, 0, 1, 2, 18, 18, 3, 3};
		
		/*posXNextAnimBtn = new float[8]{ 4, 13, 4, 15, 4, 15, 21, 16};
		posYNextAnimBtn = new float[8]{ 4, 13, 4, 15, 4, 15, 3, 6};
		
		sizeBtnModifierX = new float[8]{ 3, 3, 3, 3, 3, 3, 3, 3};		
		sizeBtnModifierY = new float[8]{ 3, 3, 3, 3, 3, 3, 3, 3};
		*/
		
		posXNextAnimBtn = new float[8]{ 8, 15, 12, 17, 16.75f, 16.75f, 15, 4};
		posYNextAnimBtn = new float[8]{ 1, 0, 2, 2, 13.75f,  13.75f, 4, 15};
		
		sizeBtnModifierX = new float[8]{ 6, 5, 5, 3, 4, 4, 3, 3};		
		sizeBtnModifierY = new float[8]{ 7, 5, 8, 14, 8, 8, 5, 5};
		mdpFSC = GetComponent<MediaPlayerFullScreenCtrlCustom> ();		
		//mdpFSC.SetNewVM(videoManagers[0]);
		
		//Debug.Log (currentVideoIndex);
		//mpccInit = videoManagers[0].GetComponent<MediaPlayerCtrlCustom> ();
		//mpccInit.Stop();
		//mpccInit.Load (strVideoName[0]);

		//mpccInit.Play ();
		//mpccInit.Play();
		/*for(int i=0; i<videoManagers.Length; i++){
			GameObject go = videoManagers[i];
			go.GetComponent<MediaPlayerCtrlCustom>().Load(""+strVideoName[i]);
		}*/
		//mpccInit.Play();
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log ("First video isPlayed");
		//mpccInit.Stop();
		//mpccInit.Play();
	}

	private void LoadNextVideo(){
		videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom>().gameObject.SetActive(false);
		//videoManagers [currentVideoIndex+1].GetComponent<MediaPlayerCtrlCustom>().gameObject.SetActive(true);
		Debug.Log (currentVideoIndex);
		if (currentVideoIndex < videoManagers.Length-2) {
			videoManagers [currentVideoIndex + 2].GetComponent<MediaPlayerCtrlCustom> ().gameObject.SetActive (true);
		}

		// Change current plane visibility with renderer
		currentVideoIndex += 1;
		Debug.Log ("After " + currentVideoIndex);
		//videoManagers[currentVideoIndex].GetComponent<MeshRenderer>().enabled = true;
		//videoManagers[currentVideoIndex-1].GetComponent<MeshRenderer>().enabled = false;
		//Color planeColor = videoManagers [currentVideoIndex].GetComponent<MeshRenderer> ().materials[0].color;
		//planeColor.a = 0;
		//videoManagers [currentVideoIndex].GetComponent<MeshRenderer> ().materials[0].color = planeColor;
		MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();

		videoManagers[currentVideoIndex].gameObject.transform.Translate(0,-100,0);
		videoManagers[currentVideoIndex-1].gameObject.transform.Translate(0,100,0);
		// callback to fullscreen script to resize the plane
		//mdpFSC.SetNewVM(videoManagers[currentVideoIndex]);
		// Reset the video and play
		//mpcc.Stop();
		//mpcc.SeekTo(200);
		mpcc.Play();
	}

	private void LoadPrevVideo(){
		Application.LoadLevel("Scene_Balle");
		MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
		//mdpFSC.SetNewVM(videoManagers[currentVideoIndex]);
		mpcc.Stop();
		mpcc.Play();
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


			if (GUI.RepeatButton (new Rect (0, (Screen.height) - (Screen.width / nextPrevSizeDivider), Screen.width / nextPrevSizeDivider, Screen.width / nextPrevSizeDivider), "Previous")) {
				if (currentVideoIndex != 0) {
					LoadPrevVideo ();
					//scrMedia.Play();
					m_bFinish = false;
				}
			}
			
			// Go to previous animation
			if (GUI.RepeatButton (new Rect (0, 0, Screen.width / nextPrevSizeDivider, Screen.width / nextPrevSizeDivider), "Next")) {
				
				if (currentVideoIndex < strVideoName.Length - 1) {
					LoadNextVideo ();
					m_bFinish = false;
				} else {
					Application.LoadLevel (strNextScene);
				}

			}
			
			//try{

			// If we are at the seventh animation, the following animations will have two NextAnimation buttons because there is two balls 
			// I switched the X and Y positions since the buttons just have to be positionned symmetrically
			// 5 bcoz there is 8 animations, so 8-1-2 because we are in an array and this behaviour must be actived from the sixth animation
			/*if (currentVideoIndex > 5 && currentVideoIndex < strVideoName.Length-1) {

				Rect btn = new Rect (posXNextAnimBtn [currentVideoIndex] * sUnitX, posYNextAnimBtn [currentVideoIndex] * sUnitY, 
				                    btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]);

				Rect btn2 = new Rect (posYNextAnimBtn [currentVideoIndex] * sUnitX, posXNextAnimBtn [currentVideoIndex] * sUnitY, 
				                      btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]);

				bool bBtn = GUI.RepeatButton (btn, "NextAnim");
				bool bBtn2 = GUI.RepeatButton (btn2, "NextAnim2");
				if ((bBtn | bBtn2) || (bBtn && bBtn2)) {
					if (currentVideoIndex < strVideoName.Length-1) {
						LoadNextVideo ();
						m_bFinish = false;
					}
				}
			} else */

			if (currentVideoIndex < strVideoName.Length - 1) {

				if (GUI.RepeatButton (new Rect (posXNextAnimBtn [currentVideoIndex] * sUnitX, posYNextAnimBtn [currentVideoIndex] * sUnitY, btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]), "NextAnimation")) {
					//Debug.Log ("NextAnimationBefore");
					if (currentVideoIndex < strVideoName.Length - 1) {
						//Debug.Log ("Video index courant =" + currentVideoIndex);						
						//Debug.Log ("NextAnimationInCondition");
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
