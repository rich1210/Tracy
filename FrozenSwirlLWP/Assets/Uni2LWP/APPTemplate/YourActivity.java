package com.mirage.app;

import com.unity3d.player.*;
import android.app.Activity;
import android.content.res.Configuration;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;

public class YourActivity extends Activity {
	private UnityPlayer player;
	boolean trueColor8888 = false;

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		requestWindowFeature(Window.FEATURE_NO_TITLE);

		player = new UnityPlayer(this);

		if (player.getSettings().getBoolean("hide_status_bar", true))
			getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);

		int glesMode = player.getSettings().getInt("gles_mode", 1);
		
		player.init(glesMode, trueColor8888);

		View playerView = player.getView();
		setContentView(playerView);
		playerView.requestFocus();
	}

	protected void onDestroy() {
		super.onDestroy();
		player.quit();
	}

	protected void onPause() {
		super.onPause();
		player.pause();
		if (isFinishing())
			player.quit();
	}

	protected void onResume() {
		super.onResume();
		player.resume();
	}

	public void onConfigurationChanged(Configuration newConfig) {
		super.onConfigurationChanged(newConfig);
		player.configurationChanged(newConfig);
	}

	public void onWindowFocusChanged(boolean hasFocus) {
		super.onWindowFocusChanged(hasFocus);
		player.windowFocusChanged(hasFocus);
	}

	public boolean onKeyMultiple(int keyCode, int count, KeyEvent event) {
		return player.onKeyMultiple(keyCode, count, event);
	}

	public boolean onKeyDown(int keyCode, KeyEvent event) {
		return player.onKeyDown(keyCode, event);
	}

	public boolean onKeyUp(int keyCode, KeyEvent event) {
		return player.onKeyUp(keyCode, event);
	}
}
