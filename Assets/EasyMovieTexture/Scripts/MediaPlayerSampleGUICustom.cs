using UnityEngine;
using System.Collections;

public class MediaPlayerSampleGUICustom : MonoBehaviour {
	
	public MediaPlayerCtrlCustom scrMedia;
	
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
	
	// Array of positions of the next button, one index for one animation (video)
	private float[] posXNextAnimBtn;
	private float[] posYNextAnimBtn; 
	
	private float[] sizeBtnModifierX; 	
	private float[] sizeBtnModifierY; 

	private MediaPlayerFullScreenCtrlCustom mdpFSC;
	
	// Use this for initialization
	void Start () {

		for(int i=0; i<videoManagers.Length; i++){
			GameObject go = videoManagers[i];
			go.GetComponent<MediaPlayerCtrlCustom>().Load(""+strVideoName[i]);
		}

		scrMedia.OnEnd += OnEnd;
		btnWidth = Screen.width/dividerW; 
		btnHeight = Screen.height/dividerH;
		sUnitX = Screen.width / spaceBtnW;
		sUnitY = Screen.height / spaceBtnH;	
		
		int size = strVideoName.Length;
		
		posXNextAnimBtn = new float[8]{ 9, 19, 15, 17, 17, 17, 16, 16};
		posYNextAnimBtn = new float[8]{ 1, 0, 1, 2, 18, 18, 3, 3};
		
		sizeBtnModifierX = new float[8]{ 4, 3, 3, 3, 3, 3, 2, 2};		
		sizeBtnModifierY = new float[8]{ 5, 3, 5, 14, 3, 3, 2, 2};
		
		mdpFSC = GetComponent<MediaPlayerFullScreenCtrlCustom> ();


	}
	
	// Update is called once per frame
	void Update () {
	}

	private void LoadNextVideo(){
		// Change current plane visibility with renderer
		Debug.Log ("Avant : video index courant =" + currentVideoIndex);
		currentVideoIndex += 1;
		Debug.Log ("Après : video index courant =" + currentVideoIndex);
		MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
		//videoManagers[currentVideoIndex].GetComponent<MeshRenderer>().enabled = true;
		//videoManagers[currentVideoIndex-1].GetComponent<MeshRenderer>().enabled = false;
		//Color planeColor = videoManagers [currentVideoIndex].GetComponent<MeshRenderer> ().materials[0].color;
		//planeColor.a = 0;
		//videoManagers [currentVideoIndex].GetComponent<MeshRenderer> ().materials[0].color = planeColor;

		videoManagers[currentVideoIndex].gameObject.transform.Translate(0,-100,0);
		videoManagers[currentVideoIndex-1].gameObject.transform.Translate(0,100,0);
		// callback to fullscreen script to resize the plane
		mdpFSC.SetNewVM(videoManagers[currentVideoIndex]);
		// Reset the video and play
		mpcc.Stop();
		mpcc.SeekTo(0);
		mpcc.Play();
	}

	private void LoadPrevVideo(){
		Application.LoadLevel("Scene_Balle");

	}

	void OnGUI() {

		MediaPlayerCtrlCustom mpcc = videoManagers [currentVideoIndex].GetComponent<MediaPlayerCtrlCustom> ();
				
		//Debug.Log(""+scrMedia.GetSeekPosition());
		if(mpcc.GetSeekPosition() != 0){
			Debug.Log(" "+mpcc.GetSeekPosition()+" on " + mpcc.GetDuration());
		}

		if (mpcc.GetSeekPosition() == mpcc.GetDuration()) {
			// Go to previous animation
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
			
			
			// If we are at the seventh animation, the following animations will have two NextAnimation buttons because there is two balls 
			// I switched the X and Y positions since the buttons just have to be positionned symmetrically
			// 5 bcoz there is 8 animations, so 8-1-2 because we are in an array and this behaviour must be actived from the sixth animation
			if (currentVideoIndex > 5 && currentVideoIndex < strVideoName.Length) {
				Rect btn = new Rect (posXNextAnimBtn [currentVideoIndex] * sUnitX, posYNextAnimBtn [currentVideoIndex] * sUnitY, 
				                    btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]);

				Rect btn2 = new Rect (posYNextAnimBtn [currentVideoIndex] * sUnitX, posXNextAnimBtn [currentVideoIndex] * sUnitY, 
				                      btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]);

				bool bBtn = GUI.RepeatButton (btn, "NextAnim");
				bool bBtn2 = GUI.RepeatButton (btn2, "NextAnim2");
				if ((bBtn | bBtn2) || (bBtn && bBtn2)) {
					if (currentVideoIndex != strVideoName.Length - 1) {
						LoadNextVideo ();
						m_bFinish = false;
					}
				}
			} else {
				if (GUI.RepeatButton (new Rect (posXNextAnimBtn [currentVideoIndex] * sUnitX, posYNextAnimBtn [currentVideoIndex] * sUnitY, 
				                        btnWidth * sizeBtnModifierX [currentVideoIndex], btnHeight * sizeBtnModifierY [currentVideoIndex]), "NextAnimation")) {
					if (currentVideoIndex != strVideoName.Length - 1) {
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
