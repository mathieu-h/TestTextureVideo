using UnityEngine;
using System.Collections;

public class MediaPlayerSampleGUI : MonoBehaviour {
	
	public MediaPlayerCtrl scrMedia;

	public string[] strVideoName;
	private int currentVideoIndex = 0;
	private int dividerW = 12;
	private int dividerH = 16;
	private int btnWidth; 
	private int btnHeight;

	private float spaceBtnH = 25f;	
	private float spaceBtnW = 25f;

	public bool m_bFinish = false;

	// Use this for initialization
	void Start () {
		scrMedia.OnEnd += OnEnd;
		btnWidth = Screen.width/dividerW; 
		btnHeight = Screen.height/dividerH;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		
		if( GUI.Button(new Rect(7*(Screen.width/spaceBtnW),(Screen.height/spaceBtnH),btnWidth,btnHeight),"Reset"))
		{
			currentVideoIndex = 0;
			scrMedia.Load(""+strVideoName[currentVideoIndex]);
			m_bFinish = false;
		}

		if( GUI.Button(new Rect(7*(Screen.width/spaceBtnW),4*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Next"))
		{
			if(currentVideoIndex != strVideoName.Length-1){
				currentVideoIndex += 1;
				scrMedia.Load(""+strVideoName[currentVideoIndex]);
				m_bFinish = false;
			}
		}

		if( GUI.Button(new Rect((Screen.width/spaceBtnW),(Screen.height/spaceBtnH),btnWidth,btnHeight),"Load"))
		{
			scrMedia.Load(""+strVideoName[currentVideoIndex]);
			m_bFinish = false;
		}
		
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),4*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Play"))
		{
			scrMedia.Play();
			m_bFinish = false;
		}
	 	
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),7*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Stop"))
		{
			scrMedia.Stop();
		}
		
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),10*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Pause"))
		{
			scrMedia.Pause();
		}
		
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),13*(Screen.height/spaceBtnH),btnWidth,btnHeight),"Unload"))
		{
			scrMedia.UnLoad();
		}
		
		if( GUI.Button(new Rect((Screen.width/spaceBtnW),16*(Screen.height/spaceBtnH),btnWidth,btnHeight), " " + m_bFinish))
		{
		
		}
		
		if( GUI.Button(new Rect(4*(Screen.width/spaceBtnW),(Screen.height/spaceBtnH),btnWidth,btnHeight),"SeekTo"))
		{
			scrMedia.SeekTo(10000);
		}


		if( scrMedia.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
		{
			if( GUI.Button(new Rect(4*(Screen.width/spaceBtnW),4*(Screen.height/spaceBtnH),btnWidth,btnHeight),scrMedia.GetSeekPosition().ToString()))
			{
				
			}
			
			if( GUI.Button(new Rect(4*(Screen.width/spaceBtnW),7*(Screen.height/spaceBtnH),btnWidth,btnHeight),scrMedia.GetDuration().ToString()))
			{
				
			}
		}

	
	

	}
	
	void OnEnd()
	{
		m_bFinish = true;
	}
}
