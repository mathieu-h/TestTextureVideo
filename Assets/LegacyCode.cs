#region COMMENTED
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
#endregion

/*
	private void LoadPrevVideo(){
		// Change current plane visibility with renderer
		currentVideoIndex -= 1;
		//videoManagers[currentVideoIndex].GetComponent<MeshRenderer>().enabled = true;
		//videoManagers[currentVideoIndex+1].GetComponent<MeshRenderer>().enabled = false;

		videoManagers[currentVideoIndex].gameObject.transform.Translate(0,-100,0);
		videoManagers[currentVideoIndex+1].gameObject.transform.Translate(0,100,0);
		// callback to fullscreen script to resize the plane
		mdpFSC.SetNewVM(videoManagers[currentVideoIndex]);
		// Reset the video and play
		videoManagers[currentVideoIndex].GetComponent<MediaPlayerCtrlCustom>().Stop();
		videoManagers[currentVideoIndex].GetComponent<MediaPlayerCtrlCustom>().SeekTo(0);
		videoManagers[currentVideoIndex].GetComponent<MediaPlayerCtrlCustom>().Play();
	}*/



//}catch(IndexOutOfRangeException e){
//	Debug.Log(e.Message + " : INDEX :  " + currentVideoIndex );
//}
/*
			if(mpcc.GetSeekPosition() != 0){
				Debug.Log(""+scrMedia.GetSeekPosition()+" on " + scrMedia.GetDuration());
			}
			*/
//Debug.Log(""+scrMedia.GetSeekPosition());
//}else{				
	//Debug.Log ("Video SeekPosition courant = " + mpcc.GetSeekPosition() + " ----- Video GetDuration : " + mpcc.GetDuration());
	//Debug.Log(mpcc.ToString());
//}
