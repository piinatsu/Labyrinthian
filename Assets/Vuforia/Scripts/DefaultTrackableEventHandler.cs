/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
	string trackableName;
	bool aohIsHidden = false;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

		Time.timeScale = 0;
		//Debug.Log ("StartTime0");
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			trackableName = mTrackableBehaviour.TrackableName;
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
		GameObject aoh;

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
		/*
		aoh = GameObject.FindGameObjectWithTag ("ActiveObjectHolder");

		if(!aohIsHidden) {
			if (aoh != null) {
				Debug.Log ("aohishere");
				foreach (Transform child in aoh.transform) {
					//child.gameObject.GetComponent<Renderer> ().enabled = false;
					//child.gameObject.GetComponent<MeshCollider> ().enabled = false;
					child.gameObject.SetActive(false);
				}
			}
			aohIsHidden = true;
		}
		*/

		if (trackableName == "object_ramp" ||
		    trackableName == "object_coiled_spring" ||
		    trackableName == "object_arch_bridge") {
			Debug.Log ("aTimescale 0.01");
			Time.timeScale = 0.01f;
		} else {
			Debug.Log ("Timescale 1");
			Time.timeScale = 1;
		}
		//Debug.Log ("Time1");
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

		if (trackableName == "object_ramp" ||
		    trackableName == "object_coiled_spring" ||
		    trackableName == "object_arch_bridge") {
			Debug.Log ("aTimescale 1");
			Time.timeScale = 1f;
		} else {
			Time.timeScale = 0;
			Debug.Log ("DefaultTrackableEventHandler: TimeScale 0");
		}

		//Time.timeScale = 0;
		//Debug.Log ("DefaultTrackableEventHandler: TimeScale 0");
    }

    #endregion // PRIVATE_METHODS
}
