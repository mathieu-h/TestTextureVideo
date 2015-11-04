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
	private int currentVideoIndex2 = 0;

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
	// Array of positions of the next button n2, one index for one animation (video)
	private float[] posXNextAnimBtn2;
	private float[] posYNextAnimBtn2; 
	
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

		
		//posXNextAnimBtn = new float[8]{ 9, 19, 15, 17, 17, 17, 16, 16};
		//posYNextAnimBtn = new float[8]{ 1, 0, 1, 2, 18, 18, 3, 3};
		
		/*posXNextAnimBtn = new float[8]{ 4, 13, 4, 15, 4, 15, 21, 16};
		posYNextAnimBtn = new float[8]{ 4, 13, 4, 15, 4, 15, 3, 6};
		
		sizeBtnModifierX = new float[8]{ 3, 3, 3, 3, 3, 3, 3, 3};		
		sizeBtnModifierY = new float[8]{ 3, 3, 3, 3, 3, 3, 3, 3};
		*/
		
		posXNextAnimBtn = new float[8]{ 8, 15, 12, 17, 16.75f, 16.75f, 16, 2};
		posYNextAnimBtn = new float[8]{ 1, 0, 2, 0, 13.75f,  13.75f, 2.5f, 2};

		posXNextAnimBtn2 = new float[2]{ 2, 17};
		posYNextAnimBtn2 = new float[2]{ 16, 17};

		sizeBtnModifierX = new float[8]{ 6, 5, 5, 4, 4, 4, 2.75f, 2.75f};		
		sizeBtnModifierY = new float[8]{ 7, 5, 8, 16, 8, 8, 5, 5};
		//mdpFSC = GetComponent<MediaPlayerFullScreenCtrlCustom> ();		
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
		//Debug.Log (currentVideoIndex);
		videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ().gameObject.SetActive (false);
		if (currentVideoIndex < videoManagers.Length - 2) {
			videoManagers [currentVideoIndex + 2].GetComponent<MediaPlayerCtrlCustom> ().gameObject.SetActive (true);
		}
		// Change current plane visibility with renderer
		currentVideoIndex += 1;
		//Debug.Log ("After " + currentVideoIndex);
		//videoManagers[currentVideoIndex].GetComponent<MeshRenderer>().enabled = true;
		//videoManagers[currentVideoIndex-1].GetComponent<MeshRenderer>().enabled = false;
		//Color planeColor = videoManagers [currentVideoIndex].GetComponent<MeshRenderer> ().materials[0].color;
		//planeColor.a = 0;
		//videoManagers [currentVideoIndex].GetComponent<MeshRenderer> ().materials[0].color = planeColor;

		// callback to fullscreen script to resize the plane
		//mdpFSC.SetNewVM(videoManagers[currentVideoIndex]);
		// Reset the video and play
		//mpcc.Stop();
		//mpcc.SeekTo(200);

		if (currentVideoIndex == f_indexTextureLastVid) {			
			//Debug.Log ("Force change 8 ! :" + currentVideoIndex);
			videoManagers [currentVideoIndex - 1].gameObject.transform.Translate (0, 100, 0);
			videoManagers [currentVideoIndex].gameObject.SetActive(false);
			videoManagers [f_indexTexturePreLastVid].gameObject.SetActive (true);
			videoManagers [f_indexTexturePreLastVid].gameObject.transform.Translate (0, -100, 0);			
			videoManagers [f_indexTexturePreLastVid].GetComponent<MediaPlayerCtrlCustom> ().Stop();
			videoManagers [f_indexTexturePreLastVid].GetComponent<MediaPlayerCtrlCustom> ().Play();
		} else {
			//videoManagers [currentVideoIndex+1].GetComponent<MediaPlayerCtrlCustom>().gameObject.SetActive(true);
			MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
			videoManagers [currentVideoIndex].gameObject.transform.Translate (0, -100, 0);
			videoManagers [currentVideoIndex - 1].gameObject.transform.Translate (0, 100, 0);
			mpcc.Stop ();
			mpcc.Play ();
		}
		if (currentVideoIndex == f_indexTextureLastVid-1) {			
			//Debug.Log ("Preload " + currentVideoIndex);
			Material material = Resources.Load("bg_09", typeof(Material)) as Material;
			videoManagers[f_indexTexturePreLastVid].GetComponent<MeshRenderer>().material = material;
			videoManagers[f_indexTexturePreLastVid].GetComponent<MediaPlayerCtrlCustom> ().Load ("Ball-RA-09.mp4");
		}
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

			//Previous
			if (GUI.RepeatButton (new Rect (0, 0, Screen.width / nextPrevSizeDivider, Screen.width / nextPrevSizeDivider), "")) {
				if (currentVideoIndex != 0) {
					LoadPrevVideo ();
					//scrMedia.Play();
					m_bFinish = false;
				}
			}
			
			// Go to Next animation - Desactivated when the NextAnimation button is also at the corner of the screen (when we open the corner to reveal the ball
			if(currentVideoIndex != 1 && currentVideoIndex != 2 && currentVideoIndex != 3){
				if (GUI.RepeatButton (new Rect (Screen.width - (Screen.width / nextPrevSizeDivider), 0, Screen.width / nextPrevSizeDivider, Screen.width / nextPrevSizeDivider), "")) {
					
					if (currentVideoIndex < strVideoName.Length - 1) {
						LoadNextVideo ();
						m_bFinish = false;
					} else {
						Application.LoadLevel (strNextScene);
					}
				}
			}
			//try{

			// If we are at the seventh animation, the following animations will have two NextAnimation buttons because there is two balls 
			// I switched the X and Y positions since the buttons just have to be positionned symmetrically
			// 5 bcoz there is 8 animations, so 8-1-2 because we are in an array and this behaviour must be actived from the sixth animation
			if (currentVideoIndex > 5 && currentVideoIndex < strVideoName.Length-1) {
				//Debug.Log ("currentVideoIndex :"+ currentVideoIndex);
				Rect btn = new Rect (posXNextAnimBtn [currentVideoIndex] * sUnitX, posYNextAnimBtn [currentVideoIndex] * sUnitY, 
				                    btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]);

				Rect btn2 = new Rect (posXNextAnimBtn2 [currentVideoIndex2] * sUnitX, posYNextAnimBtn2 [currentVideoIndex2] * sUnitY, 
				                      btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]);
				//Next Animation - Next Animation 2
				bool bBtn = GUI.RepeatButton (btn, "");
				bool bBtn2 = GUI.RepeatButton (btn2, "");
				if ((bBtn | bBtn2) || (bBtn && bBtn2)) {
					if (currentVideoIndex < strVideoName.Length-1) {
						LoadNextVideo ();
						m_bFinish = false;
						currentVideoIndex2+=1;
					}					
				}
			} else {
				// Next Animation moving around the screen
				if (currentVideoIndex < strVideoName.Length - 1) {

					if (GUI.RepeatButton (new Rect (posXNextAnimBtn [currentVideoIndex] * sUnitX, posYNextAnimBtn [currentVideoIndex] * sUnitY, btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]), "")) {
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
	}
	
	void OnEnd()
	{
		//scrMedia.Pause ();
		m_bFinish = true;
	}
}
