package com.Pineappsels.FrozenSwirlLWP;

import net.margaritov.preference.colorpicker.ColorPickerPreference;
import android.app.WallpaperManager;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.preference.Preference;
import android.preference.PreferenceActivity;
import android.preference.Preference.OnPreferenceChangeListener;
import android.preference.Preference.OnPreferenceClickListener;
import android.view.View;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;

/**
 * Preference change listener.
 */
public class FrozenSwirlLWPSettings extends PreferenceActivity implements SharedPreferences.OnSharedPreferenceChangeListener,  SeekBar.OnSeekBarChangeListener {
	private SeekBar mSeekBar;
	
	@Override
	public void onSharedPreferenceChanged(SharedPreferences sharedPreferences, String key) {
	}

	@Override
	protected void onCreate(Bundle icicle) {
		super.onCreate(icicle);

		getPreferenceManager().setSharedPreferencesName(FrozenSwirlLWP.SHARED_PREFS_NAME);
		addPreferencesFromResource(R.xml.wallpaper_settings);
		getPreferenceManager().getSharedPreferences().registerOnSharedPreferenceChangeListener(this);
		
		// get value of color First color 1
	      ((ColorPickerPreference)findPreference("color1_1")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

				@Override
				public boolean onPreferenceChange(Preference preference, Object newValue) {
					String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
				
					// set up values
					int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
					int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
					int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
					float finalRed = (float) (red/255.00);
					float finalGreen = (float) (green/255.0);
					float finalBlue = (float) (blue/255.0);
					
					// save values for unity message
					SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
					SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
					prefsEditorPlayer.putFloat("redVal1_1", finalRed );
					prefsEditorPlayer.putFloat("greenVal1_1", finalGreen );
					prefsEditorPlayer.putFloat("blueVal1_1", finalBlue );
					prefsEditorPlayer.commit();
					
					return true;
				}

	        });
	        ((ColorPickerPreference)findPreference("color1_1")).setAlphaSliderEnabled(false);
	        
		// get value of color First color 2
	      ((ColorPickerPreference)findPreference("color1_2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

				@Override
				public boolean onPreferenceChange(Preference preference, Object newValue) {
					String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
				
					// set up values
					int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
					int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
					int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
					float finalRed = (float) (red/255.00);
					float finalGreen = (float) (green/255.0);
					float finalBlue = (float) (blue/255.0);
					
					// save values for unity message
					SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
					SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
					prefsEditorPlayer.putFloat("redVal1_2", finalRed );
					prefsEditorPlayer.putFloat("greenVal1_2", finalGreen );
					prefsEditorPlayer.putFloat("blueVal1_2", finalBlue );
					prefsEditorPlayer.commit();
					
					return true;
				}

	        });
	        ((ColorPickerPreference)findPreference("color1_2")).setAlphaSliderEnabled(false);
	        
	        
			// get value of color First color 3
		      ((ColorPickerPreference)findPreference("color1_3")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

					@Override
					public boolean onPreferenceChange(Preference preference, Object newValue) {
						String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
					
						// set up values
						int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
						int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
						int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
						float finalRed = (float) (red/255.00);
						float finalGreen = (float) (green/255.0);
						float finalBlue = (float) (blue/255.0);
						
						// save values for unity message
						SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
						SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
						prefsEditorPlayer.putFloat("redVal1_3", finalRed );
						prefsEditorPlayer.putFloat("greenVal1_3", finalGreen );
						prefsEditorPlayer.putFloat("blueVal1_3", finalBlue );
						prefsEditorPlayer.commit();
						
						return true;
					}

		        });
		        ((ColorPickerPreference)findPreference("color1_3")).setAlphaSliderEnabled(false);
		        
		        
		        //////////////////////////////////////////////////////////////////////////////////////////
		        //////////////////////////////////////////////////////////////////////////////////////////
		        
				// get value of color First color 1
			      ((ColorPickerPreference)findPreference("color2_1")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

						@Override
						public boolean onPreferenceChange(Preference preference, Object newValue) {
							String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
						
							// set up values
							int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
							int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
							int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
							float finalRed = (float) (red/255.00);
							float finalGreen = (float) (green/255.0);
							float finalBlue = (float) (blue/255.0);
							
							// save values for unity message
							SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
							SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
							prefsEditorPlayer.putFloat("redVal2_1", finalRed );
							prefsEditorPlayer.putFloat("greenVal2_1", finalGreen );
							prefsEditorPlayer.putFloat("blueVal2_1", finalBlue );
							prefsEditorPlayer.commit();
							
							return true;
						}

			        });
			        ((ColorPickerPreference)findPreference("color2_1")).setAlphaSliderEnabled(false);
			        
				// get value of color First color 2
			      ((ColorPickerPreference)findPreference("color2_2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

						@Override
						public boolean onPreferenceChange(Preference preference, Object newValue) {
							String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
						
							// set up values
							int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
							int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
							int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
							float finalRed = (float) (red/255.00);
							float finalGreen = (float) (green/255.0);
							float finalBlue = (float) (blue/255.0);
							
							// save values for unity message
							SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
							SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
							prefsEditorPlayer.putFloat("redVal2_2", finalRed );
							prefsEditorPlayer.putFloat("greenVal2_2", finalGreen );
							prefsEditorPlayer.putFloat("blueVal2_2", finalBlue );
							prefsEditorPlayer.commit();
							
							return true;
						}

			        });
			        ((ColorPickerPreference)findPreference("color2_2")).setAlphaSliderEnabled(false);
			        
			        
					// get value of color First color 3
				      ((ColorPickerPreference)findPreference("color2_3")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

							@Override
							public boolean onPreferenceChange(Preference preference, Object newValue) {
								String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
							
								// set up values
								int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
								int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
								int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
								float finalRed = (float) (red/255.00);
								float finalGreen = (float) (green/255.0);
								float finalBlue = (float) (blue/255.0);
								
								// save values for unity message
								SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
								SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
								prefsEditorPlayer.putFloat("redVal2_3", finalRed );
								prefsEditorPlayer.putFloat("greenVal2_3", finalGreen );
								prefsEditorPlayer.putFloat("blueVal2_3", finalBlue );
								prefsEditorPlayer.commit();
								
								return true;
							}

				        });
				        ((ColorPickerPreference)findPreference("color2_3")).setAlphaSliderEnabled(false);
				        
				        
				        //////////////////////////////////////////////////////////////////////////////////////
				        /////////////////////////////////////////////////////////////////////////////////////
				        
				     // get value of color First color 1
				      ((ColorPickerPreference)findPreference("color3_1")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

							@Override
							public boolean onPreferenceChange(Preference preference, Object newValue) {
								String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
							
								// set up values
								int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
								int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
								int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
								float finalRed = (float) (red/255.00);
								float finalGreen = (float) (green/255.0);
								float finalBlue = (float) (blue/255.0);
								
								// save values for unity message
								SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
								SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
								prefsEditorPlayer.putFloat("redVal3_1", finalRed );
								prefsEditorPlayer.putFloat("greenVal3_1", finalGreen );
								prefsEditorPlayer.putFloat("blueVal3_1", finalBlue );
								prefsEditorPlayer.commit();
								
								return true;
							}

				        });
				        ((ColorPickerPreference)findPreference("color3_1")).setAlphaSliderEnabled(false);
				        
					// get value of color First color 2
				      ((ColorPickerPreference)findPreference("color3_2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

							@Override
							public boolean onPreferenceChange(Preference preference, Object newValue) {
								String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
							
								// set up values
								int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
								int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
								int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
								float finalRed = (float) (red/255.00);
								float finalGreen = (float) (green/255.0);
								float finalBlue = (float) (blue/255.0);
								
								// save values for unity message
								SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
								SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
								prefsEditorPlayer.putFloat("redVal3_2", finalRed );
								prefsEditorPlayer.putFloat("greenVal3_2", finalGreen );
								prefsEditorPlayer.putFloat("blueVal3_2", finalBlue );
								prefsEditorPlayer.commit();
								
								return true;
							}

				        });
				        ((ColorPickerPreference)findPreference("color3_2")).setAlphaSliderEnabled(false);
				        
				        
						// get value of color First color 3
					      ((ColorPickerPreference)findPreference("color3_3")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

								@Override
								public boolean onPreferenceChange(Preference preference, Object newValue) {
									String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
								
									// set up values
									int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
									int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
									int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
									float finalRed = (float) (red/255.00);
									float finalGreen = (float) (green/255.0);
									float finalBlue = (float) (blue/255.0);
									
									// save values for unity message
									SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
									SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
									prefsEditorPlayer.putFloat("redVal3_3", finalRed );
									prefsEditorPlayer.putFloat("greenVal3_3", finalGreen );
									prefsEditorPlayer.putFloat("blueVal3_3", finalBlue );
									prefsEditorPlayer.commit();
									
									return true;
								}

					        });
					        ((ColorPickerPreference)findPreference("color3_3")).setAlphaSliderEnabled(false);
					        
					        
					        //////////////////////////////////////////////////////////////////////////////////
					        /////////////////////////////////////////////////////////////////////////////////
					        
					        // get value of color First color 1
					      ((ColorPickerPreference)findPreference("color4_1")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

								@Override
								public boolean onPreferenceChange(Preference preference, Object newValue) {
									String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
								
									// set up values
									int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
									int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
									int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
									float finalRed = (float) (red/255.00);
									float finalGreen = (float) (green/255.0);
									float finalBlue = (float) (blue/255.0);
									
									// save values for unity message
									SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
									SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
									prefsEditorPlayer.putFloat("redVal4_1", finalRed );
									prefsEditorPlayer.putFloat("greenVal4_1", finalGreen );
									prefsEditorPlayer.putFloat("blueVal4_1", finalBlue );
									prefsEditorPlayer.commit();
									
									return true;
								}

					        });
					        ((ColorPickerPreference)findPreference("color4_1")).setAlphaSliderEnabled(false);
					        
						// get value of color First color 2
					      ((ColorPickerPreference)findPreference("color4_2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

								@Override
								public boolean onPreferenceChange(Preference preference, Object newValue) {
									String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
								
									// set up values
									int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
									int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
									int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
									float finalRed = (float) (red/255.00);
									float finalGreen = (float) (green/255.0);
									float finalBlue = (float) (blue/255.0);
									
									// save values for unity message
									SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
									SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
									prefsEditorPlayer.putFloat("redVal4_2", finalRed );
									prefsEditorPlayer.putFloat("greenVal4_2", finalGreen );
									prefsEditorPlayer.putFloat("blueVal4_2", finalBlue );
									prefsEditorPlayer.commit();
									
									return true;
								}

					        });
					        ((ColorPickerPreference)findPreference("color4_2")).setAlphaSliderEnabled(false);
					        
					        
							// get value of color First color 3
						      ((ColorPickerPreference)findPreference("color4_3")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

									@Override
									public boolean onPreferenceChange(Preference preference, Object newValue) {
										String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
									
										// set up values
										int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
										int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
										int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
										float finalRed = (float) (red/255.00);
										float finalGreen = (float) (green/255.0);
										float finalBlue = (float) (blue/255.0);
										
										// save values for unity message
										SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
										SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
										prefsEditorPlayer.putFloat("redVal4_3", finalRed );
										prefsEditorPlayer.putFloat("greenVal4_3", finalGreen );
										prefsEditorPlayer.putFloat("blueVal4_3", finalBlue );
										prefsEditorPlayer.commit();
										
										return true;
									}

						        });
						        ((ColorPickerPreference)findPreference("color4_3")).setAlphaSliderEnabled(false);
						        
						        
						        /////////////////////////////////////////////////////////////////////////////////////
						        ////////////////////////////////////////////////////////////////////////////////////
						        
						        // get value of color First color 1
						      ((ColorPickerPreference)findPreference("color5_1")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

									@Override
									public boolean onPreferenceChange(Preference preference, Object newValue) {
										String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
									
										// set up values
										int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
										int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
										int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
										float finalRed = (float) (red/255.00);
										float finalGreen = (float) (green/255.0);
										float finalBlue = (float) (blue/255.0);
										
										// save values for unity message
										SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
										SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
										prefsEditorPlayer.putFloat("redVal5_1", finalRed );
										prefsEditorPlayer.putFloat("greenVal5_1", finalGreen );
										prefsEditorPlayer.putFloat("blueVal5_1", finalBlue );
										prefsEditorPlayer.commit();
										
										return true;
									}

						        });
						        ((ColorPickerPreference)findPreference("color5_1")).setAlphaSliderEnabled(false);
						        
							// get value of color First color 2
						      ((ColorPickerPreference)findPreference("color5_2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

									@Override
									public boolean onPreferenceChange(Preference preference, Object newValue) {
										String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
									
										// set up values
										int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
										int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
										int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
										float finalRed = (float) (red/255.00);
										float finalGreen = (float) (green/255.0);
										float finalBlue = (float) (blue/255.0);
										
										// save values for unity message
										SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
										SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
										prefsEditorPlayer.putFloat("redVal5_2", finalRed );
										prefsEditorPlayer.putFloat("greenVal5_2", finalGreen );
										prefsEditorPlayer.putFloat("blueVal5_2", finalBlue );
										prefsEditorPlayer.commit();
										
										return true;
									}

						        });
						        ((ColorPickerPreference)findPreference("color5_2")).setAlphaSliderEnabled(false);
						        
						        
								// get value of color First color 3
							      ((ColorPickerPreference)findPreference("color5_3")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {

										@Override
										public boolean onPreferenceChange(Preference preference, Object newValue) {
											String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
										
											// set up values
											int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
											int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
											int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
											float finalRed = (float) (red/255.00);
											float finalGreen = (float) (green/255.0);
											float finalBlue = (float) (blue/255.0);
											
											// save values for unity message
											SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
											SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
											prefsEditorPlayer.putFloat("redVal5_3", finalRed );
											prefsEditorPlayer.putFloat("greenVal5_3", finalGreen );
											prefsEditorPlayer.putFloat("blueVal5_3", finalBlue );
											prefsEditorPlayer.commit();
											
											return true;
										}

							        });
							        ((ColorPickerPreference)findPreference("color5_3")).setAlphaSliderEnabled(false);
							        
							  ////////////////////////////////////////////////////////////////////////////////////////////////
							  ////////////////////////////////////////////////////////////////////////////////////////////////
							        
							        
						        // get value of color First color 1
						      ((ColorPickerPreference)findPreference("color6_1")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {
	
									@Override
									public boolean onPreferenceChange(Preference preference, Object newValue) {
										String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
									
										// set up values
										int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
										int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
										int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
										float finalRed = (float) (red/255.00);
										float finalGreen = (float) (green/255.0);
										float finalBlue = (float) (blue/255.0);
										
										// save values for unity message
										SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
										SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
										prefsEditorPlayer.putFloat("redVal6_1", finalRed );
										prefsEditorPlayer.putFloat("greenVal6_1", finalGreen );
										prefsEditorPlayer.putFloat("blueVal6_1", finalBlue );
										prefsEditorPlayer.commit();
										
										return true;
									}
	
						        });
						        ((ColorPickerPreference)findPreference("color6_1")).setAlphaSliderEnabled(false);
						        
							// get value of color First color 2
						      ((ColorPickerPreference)findPreference("color6_2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {
	
									@Override
									public boolean onPreferenceChange(Preference preference, Object newValue) {
										String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
									
										// set up values
										int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
										int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
										int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
										float finalRed = (float) (red/255.00);
										float finalGreen = (float) (green/255.0);
										float finalBlue = (float) (blue/255.0);
										
										// save values for unity message
										SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
										SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
										prefsEditorPlayer.putFloat("redVal6_2", finalRed );
										prefsEditorPlayer.putFloat("greenVal6_2", finalGreen );
										prefsEditorPlayer.putFloat("blueVal6_2", finalBlue );
										prefsEditorPlayer.commit();
										
										return true;
									}
	
						        });
						        ((ColorPickerPreference)findPreference("color6_2")).setAlphaSliderEnabled(false);
						        
						        
								// get value of color First color 3
							      ((ColorPickerPreference)findPreference("color6_3")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {
	
										@Override
										public boolean onPreferenceChange(Preference preference, Object newValue) {
											String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
										
											// set up values
											int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
											int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
											int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
											float finalRed = (float) (red/255.00);
											float finalGreen = (float) (green/255.0);
											float finalBlue = (float) (blue/255.0);
											
											// save values for unity message
											SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
											SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
											prefsEditorPlayer.putFloat("redVal6_3", finalRed );
											prefsEditorPlayer.putFloat("greenVal6_3", finalGreen );
											prefsEditorPlayer.putFloat("blueVal6_3", finalBlue );
											prefsEditorPlayer.commit();
											
											return true;
										}
	
							        });
							        ((ColorPickerPreference)findPreference("color6_3")).setAlphaSliderEnabled(false);

							        
							        ///////////////////////////////////////////////////////////////////////////////////////
							        /////////////////////////////////////////////////////////////////////////////////////
							        
							        
						        // get value of color First color 1
						      ((ColorPickerPreference)findPreference("color7_1")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {
	
									@Override
									public boolean onPreferenceChange(Preference preference, Object newValue) {
										String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
									
										// set up values
										int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
										int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
										int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
										float finalRed = (float) (red/255.00);
										float finalGreen = (float) (green/255.0);
										float finalBlue = (float) (blue/255.0);
										
										// save values for unity message
										SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
										SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
										prefsEditorPlayer.putFloat("redVal7_1", finalRed );
										prefsEditorPlayer.putFloat("greenVal7_1", finalGreen );
										prefsEditorPlayer.putFloat("blueVal7_1", finalBlue );
										prefsEditorPlayer.commit();
										
										return true;
									}
	
						        });
						        ((ColorPickerPreference)findPreference("color7_1")).setAlphaSliderEnabled(false);
						        
							// get value of color First color 2
						      ((ColorPickerPreference)findPreference("color7_2")).setOnPreferenceChangeListener(new OnPreferenceChangeListener() {
	
									@Override
									public boolean onPreferenceChange(Preference preference, Object newValue) {
										String value = ColorPickerPreference.convertToARGB(Integer.valueOf(String.valueOf(newValue)));
									
										// set up values
										int red = Integer.decode("0x"+value.substring(3).substring(0, value.length()-7));
										int green = Integer.decode("0x"+value.substring(5).substring(0, value.length()-7));
										int blue = Integer.decode("0x"+value.substring(7).substring(0, value.length()-7));
										float finalRed = (float) (red/255.00);
										float finalGreen = (float) (green/255.0);
										float finalBlue = (float) (blue/255.0);
										
										// save values for unity message
										SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
										SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
										prefsEditorPlayer.putFloat("redVal7_2", finalRed );
										prefsEditorPlayer.putFloat("greenVal7_2", finalGreen );
										prefsEditorPlayer.putFloat("blueVal7_2", finalBlue );
										prefsEditorPlayer.commit();
										
										return true;
									}
	
						        });
						        ((ColorPickerPreference)findPreference("color7_2")).setAlphaSliderEnabled(false);
					        
	}

	@Override
	protected void onDestroy() {
		getPreferenceManager().getSharedPreferences().unregisterOnSharedPreferenceChangeListener(this);
		super.onDestroy();
	}
	
	@Override
	public void onProgressChanged(SeekBar seekBar, int progress,
			boolean fromUser) {
		// TODO Auto-generated method stub
	
	    if (mSeekBar != null)
	      mSeekBar.setProgress(progress); 
	    
	 // save values for unity message
		SharedPreferences myPrefsPlayer = getSharedPreferences(FrozenSwirlLWP.SHARED_PREFS_NAME, 0);
		SharedPreferences.Editor prefsEditorPlayer = myPrefsPlayer.edit();	
		prefsEditorPlayer.putInt("seek", progress );
		prefsEditorPlayer.commit();
		
	// would update a text view here
		//tv.setText(Integer.toString(progress)+"%");
	
		
	}

	@Override
	public void onStartTrackingTouch(SeekBar seekBar) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onStopTrackingTouch(SeekBar seekBar) {
		// TODO Auto-generated method stub
		
	}

}
