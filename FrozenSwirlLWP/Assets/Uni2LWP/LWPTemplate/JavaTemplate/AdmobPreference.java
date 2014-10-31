package com.mirage.livewallpaper;

import android.content.Context;
import android.preference.Preference;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

public class AdmobPreference extends Preference {
	View adview;

	public AdmobPreference(Context context) {
		super(context, null);
	}

	public AdmobPreference(Context context, AttributeSet attrs) {
		super(context, attrs);
	}

	@Override
	protected View onCreateView(ViewGroup parent) {
		LayoutInflater inflater = (LayoutInflater) getContext().getSystemService(Context.LAYOUT_INFLATER_SERVICE);

		if (adview == null)
			adview = inflater.inflate(R.layout.admob_preference, null);

		return adview;
	}
}
