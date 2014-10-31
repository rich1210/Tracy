package com.mirage.livewallpaper;

import com.unity3d.player.UnityPlayer;

import android.util.Log;
import android.view.GestureDetector.OnGestureListener;
import android.view.MotionEvent;

/**
 * Gesture listener.
 * 
 * @see http://developer.android.com/reference/android/view/GestureDetector.
 *      OnGestureListener.html
 */
public class GestureLstr implements OnGestureListener {
	private String TAG = "Uni2LwP-GestureLstr";
	private boolean DEBUG = false;
	private static final int SWIPE_MIN_DISTANCE = 6;
//	private static final int SWIPE_MAX_OFF_PATH = 125;
	private static final int SWIPE_THRESHOLD_VELOCITY = 50;
	private boolean isEnabled = false;

	@Override
	public boolean onDown(MotionEvent e) {
		return false;
	}

	@Override
	public boolean onFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY) {
		try {

			if (isEnabled) {

//				if (Math.abs(e1.getY() - e2.getY()) > SWIPE_MAX_OFF_PATH)
//					return false;

				if (e1.getX() - e2.getX() > SWIPE_MIN_DISTANCE && Math.abs(velocityX) > SWIPE_THRESHOLD_VELOCITY) {
					if (DEBUG)
						Log.v(TAG, "LEFT");

					UnityPlayer.UnitySendMessage("Main Camera", "SetSimulateCamOffset", "LEFT");

				} else if (e2.getX() - e1.getX() > SWIPE_MIN_DISTANCE && Math.abs(velocityX) > SWIPE_THRESHOLD_VELOCITY) {
					if (DEBUG)
						Log.v(TAG, "RIGHT");

					UnityPlayer.UnitySendMessage("Main Camera", "SetSimulateCamOffset", "RIGHT");
				}

			}

		} catch (Exception e) {
			// Nothing
		}

		return true;
	}
	
	/**
	 * Enabled/Disables emulated swipe.
	 * @param isEnabled
	 */
	public void isEnabled(boolean isEnabled){
		this.isEnabled = isEnabled;
	}

	@Override
	public void onLongPress(MotionEvent e) {
	}

	@Override
	public boolean onScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY) {
		return false;
	}

	@Override
	public void onShowPress(MotionEvent e) {
	}

	@Override
	public boolean onSingleTapUp(MotionEvent e) {
		return false;
	}

}
