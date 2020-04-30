using System;
using System.Linq;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class LoadDataset : MonoBehaviour {

	public int maxNumber = 10;
	public string dataSetName = "QRCode";
	public String patFilePath = "PokerConfig.txt";
	private bool hasConfig;
	private TrackableBehaviour[] mtb;
	private String[] augObjNames;
	private int[] patternNames;
    private GameObject[] augmentationObjects;

    void Start () {
		ReadConfig();
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
    }

	void ReadConfig() {
        var fileAddress = System.IO.Path.Combine(
			Application.streamingAssetsPath,
			patFilePath);
        FileInfo fInfo = new FileInfo(fileAddress);
		hasConfig = false;
        if (!fInfo.Exists)
			return;
		hasConfig = true;
        string s = "";
		StreamReader r = new StreamReader(fileAddress);
		// byte[] data = new byte[1024];
		// data = Encoding.UTF8.GetBytes(r.ReadToEnd());
		// s = Encoding.UTF8.GetString(data, 0, data.Length);
		s = r.ReadToEnd();
		var lines = s.Split('\n');
		patternNames = new int[lines.Length];
		augObjNames = new string[lines.Length];
		augmentationObjects = new GameObject[lines.Length];
		for(int i = 0; i < lines.Length; i ++)
		{
			if (lines[i].Length < 1)
				break;
			string[] items = lines[i].Split(' ');
			patternNames[i] = Int32.Parse(items[0]);
			augObjNames[i] = items[1];
			augmentationObjects[i] = Resources.Load<GameObject>(items[1]);
			Debug.Log(items[0]);
			//Debug.Log(augmentationObjects[i]);
		}
	}

    void OnVuforiaStarted()
    {
		ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
		
		DataSet dataSet = objectTracker.CreateDataSet();
		if (!dataSet.Load(dataSetName)) {
			Debug.LogError("<color=yellow>Failed to load dataset: '" + dataSetName + "'</color>");
			return;
		}

		objectTracker.Stop();  // stop tracker so that we can add new dataset

		if (!objectTracker.ActivateDataSet(dataSet)) {
			// Note: ImageTracker cannot have more than 100 total targets activated
			Debug.Log("<color=yellow>Failed to Activate DataSet: " + dataSetName + "</color>");
		}

		if (!objectTracker.Start()) {
			Debug.Log("<color=yellow>Tracker Failed to Start.</color>");
		}

		int counter = 0;

		IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
		mtb = new TrackableBehaviour [tbs.Count()];
		// The trackable name is required to be continuous integers
		foreach (TrackableBehaviour tb in tbs)
			mtb[Int32.Parse(tb.TrackableName)] = tb;
		for (int i = maxNumber; i < mtb.Length; i ++)
			mtb[i].gameObject.name = "ImageTarget-" + mtb[i].TrackableName + " (off)";
		for(int i = 0; i < maxNumber; i ++) {
			// change generic name to include trackable name
			mtb[i].gameObject.name = "ImageTarget-" + mtb[i].TrackableName + " (on)";

			// add additional script components for trackable
			mtb[i].gameObject.AddComponent<DefaultTrackableEventHandler>();
			mtb[i].gameObject.AddComponent<TurnOffBehaviour>();


			// instantiate augmentation object and parent to trackable
			GameObject augmentation = (GameObject)GameObject.Instantiate(augmentationObjects[i]);
			augmentation.transform.parent = mtb[i].gameObject.transform;
			augmentation.transform.localPosition = new Vector3(0f, 0f, 0f);
			augmentation.transform.localRotation = Quaternion.identity;
			augmentation.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
			augmentation.gameObject.SetActive(true);
		}
	} 
}