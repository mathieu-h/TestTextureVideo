using UnityEngine;
using System.Collections;

public class MediaPlayerSampleGUICustom : MonoBehaviour {
	
	public MediaPlayerCtrlCustom scrMedia;

	public string[] strVideoName;
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


	// Use this for initialization
	void Start () {
		scrMedia.OnEnd += OnEnd;
		btnWidth = Screen.width/dividerW; 
		btnHeight = Screen.height/dividerH;
		sUnitX = Screen.width / spaceBtnW;
		sUnitY = Screen.height / spaceBtnH;	
		posXNextAnimBtn = new float[]{ 4*sUnitX, 23*sUnitX, 23*sUnitX, 12*sUnitX};
		posYNextAnimBtn = new float[]{ 18*sUnitY, 1*sUnitY, 1*sUnitY, 12*sUnitY};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		// Go to previous animation
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),4*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Previous"))
		{
			// Faire le chargement de la scène précédente via le singleton
			//if(currentVideoIndex == 0)
			if(currentVideoIndex != 0){
				currentVideoIndex -= 1;
				scrMedia.Load(""+strVideoName[currentVideoIndex]);
				m_bFinish = false;
			}
		}

		// Go to previous animation
		if( GUI.Button(new Rect(22*(Screen.width/spaceBtnW),4*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Next"))
		{
			// Faire le chargement de la scène suivante via le singleton
			//if(currentVideoIndex == strVideoName.Length-1)
			if(currentVideoIndex != strVideoName.Length-1){
				currentVideoIndex += 1;
				scrMedia.Load(""+strVideoName[currentVideoIndex]);
				m_bFinish = false;
			}
		}

		if( GUI.Button(new Rect(posXNextAnimBtn[currentVideoIndex], posYNextAnimBtn[currentVideoIndex], btnWidth, btnHeight),"NextAnimation"))
		{
			if(currentVideoIndex != strVideoName.Length-1){
				currentVideoIndex += 1;
				scrMedia.Load(""+strVideoName[currentVideoIndex]);
				m_bFinish = false;
			}
		}

		/*
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),7*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Reset"))
		{
			currentVideoIndex = 0;
			scrMedia.Load(""+strVideoName[currentVideoIndex]);
			m_bFinish = false;
		}


		if( GUI.Button(new Rect(22*(Screen.width/spaceBtnW),7*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Reload"))
		{
			scrMedia.Load(""+strVideoName[currentVideoIndex]);
			m_bFinish = false;
		}
		
		if( GUI.Button(new Rect(22*(Screen.width/spaceBtnW),22*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Play"))
		{
			scrMedia.Play();
			m_bFinish = false;
		}
	 			
		if( GUI.Button(new Rect(19*(Screen.width/spaceBtnW),22*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Pause"))
		{
			scrMedia.Pause();
		}


		if( GUI.Button(new Rect(4*(Screen.width/spaceBtnW),(Screen.height/spaceBtnH),btnWidth,btnHeight),"SeekTo"))
		{
			scrMedia.SeekTo(10000);
		}


		if( scrMedia.GetCurrentState() == MediaPlayerCtrlCustom.MEDIAPLAYER_STATE.PLAYING)
		{
			if( GUI.Button(new Rect(4*(Screen.width/spaceBtnW),4*(Screen.height/spaceBtnH),btnWidth,btnHeight),scrMedia.GetSeekPosition().ToString()))
			{
				
			}
			
			if( GUI.Button(new Rect(4*(Screen.width/spaceBtnW),7*(Screen.height/spaceBtnH),btnWidth,btnHeight),scrMedia.GetDuration().ToString()))
			{
				
			}
		}

		
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),10*(Screen.height/spaceBtnH),btnWidth,btnHeight), " " + m_bFinish))
		{
		
		}
		 */
	
	

	}
	
	void OnEnd()
	{
		//scrMedia.Pause ();
		m_bFinish = true;
	}
}
