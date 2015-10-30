﻿using UnityEngine;
using System.Collections;

public class MediaPlayerFullScreenCtrlCustom : MonoBehaviour {
	
	public GameObject m_objVideo;
	
	int m_iOrgWidth = 0;
	int m_iOrgHeight = 0;
	// Use this for initialization
	void Start () {
		Resize ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if( m_iOrgWidth != Screen.width)
			Resize();
		
		if( m_iOrgHeight != Screen.height)
			Resize();
		
	
	}
	
	public void SetNewVM(GameObject vm){
		m_objVideo = vm;
		Resize ();
	}
	
	void Resize()
	{
		m_iOrgWidth = Screen.width;
		m_iOrgHeight = Screen.height;
		
		float fRatio = (float) m_iOrgHeight / (float)m_iOrgWidth;
		
		m_objVideo.transform.localScale = new Vector3( 20.0f / fRatio, 20.0f / fRatio, 1.0f);
		
		m_objVideo.transform.GetComponent<MediaPlayerCtrlCustom>().Resize();
	}
	
	
	
	
}
