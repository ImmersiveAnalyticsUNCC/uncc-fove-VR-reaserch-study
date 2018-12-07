using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

/*
 edited by Benjamin Aranyi, and Zachary Aranyi during the UNCC Spring semester 2018
 for all edits made please use the CTRL+F shortcut and type 1493.
 all lines with this marker (1493) have been edited or added by us from the original file found here: https://github.com/FoveHMD/UnityDataCollector  
*/


// A behaviour class which records eye gaze data (with floating-point timestamps) and writes it out to a .csv file
// for continued processing.
public class FOVERecorder0 : MonoBehaviour
{
    // Require a reference (assigned via the Unity Inspector panel) to a FoveInterfaceBase object.
    // This could be either FoveInterface or FoveInterface2.
    [Tooltip("This should be a reference to any FoveInterface or FoveInterface2 object in the scene.")]
    public FoveInterfaceBase fove = null;
   
    // Pick a key (customizable via the Inspector panel) to toggle recording.
    [Tooltip("Pressing this key will toggle data recording.")]
    public KeyCode toggleRecordingKeyCode = KeyCode.R;

    // The number a data to record before writing out to disk
    [Tooltip("The number of entries to store in memory before writing asynchronously to disk")]
    public uint writeAtDataCount = 1000;

    
    // The name of the file to write our results into
    [Tooltip("The base name of the file. Don't add any extensions, as \".csv\" will be appended to whatever you put " +
             "here.")]
    public string fileName = "fove_recorded_results";

    // Check this to overwrite existing data files rather than incrementing a value each time.
    [Tooltip("If the specified filename already exists, the recorder will increment a counter until an unused " +
             "filename is found.")]
    public bool overwriteExistingFile = false;

    /*1493*/
    public GameObject GO_GreenCube;
    public GameObject GO_YellowSphere;
    public GameObject GO_GreyCapsule;
    public GameObject GO_CyanCylander;
    public GameObject GO_RedCube;
    public GameObject GO_PurpleCube;
    public GameObject GO_BlackSphere;
    public GameObject GO_BrownSphere;
    public GameObject GO_PinkCapsule;
    public GameObject GO_OrangeCylander;

    public Collider c_GreenCube;
    public Collider c_YellowSphere;
    public Collider c_GreyCapsule;
    public Collider c_CyanCylander;
    public Collider c_RedCube;
    public Collider c_PurpleCube;
    public Collider c_BlackSphere;
    public Collider c_BrownSphere;
    public Collider c_PinkCapsule;
    public Collider c_OrangeCylander;

    public GameObject sceneOBJ;


    public Boolean isLookingAtObj() // is the user currently looking at the object
    {
        if (fove.Gazecast(c_GreenCube) == true ||
            fove.Gazecast(c_YellowSphere) == true || 
            fove.Gazecast(c_GreyCapsule) == true || 
            fove.Gazecast(c_CyanCylander) == true || 
            fove.Gazecast(c_RedCube) == true || 
            fove.Gazecast(c_PurpleCube) == true || 
            fove.Gazecast(c_BlackSphere) == true || 
            fove.Gazecast(c_BrownSphere) == true || 
            fove.Gazecast(c_PinkCapsule) == true || 
           fove.Gazecast(c_OrangeCylander) == true)
        {
            return true;

        }
        else {return false;}
    }

    public string IsIndicatingSelection() // is the user indicating their selection for purposes of right or wrong if the user is correct at some point then we will mark the scene as correct
    {
        if (Input.GetMouseButton(0)) {return "+";}
        else if (Input.GetMouseButton(0) == false) { return "-"; }
        else { return "?";}
    }

        public String IsLookingAtCorrectObj() // is the user looking at the correct object indicated by the instructions
    {
        //initial or adjustment scene
        if (sceneOBJ.transform.position == new Vector3(0, 20, 0)) { return "no indication requiered at this point in time."; }

        //scene 1
        if (sceneOBJ.transform.position == new Vector3(0, 20, 1) && fove.Gazecast(c_RedCube) == true) { return "scene one correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 1) && fove.Gazecast(c_YellowSphere) == true) { return "scene one correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 1) && fove.Gazecast(c_RedCube) == false && fove.Gazecast(c_YellowSphere) == false) { return "scene one incorect object"; }

        //scene 2
        if (sceneOBJ.transform.position == new Vector3(0, 20, 2) && fove.Gazecast(c_PurpleCube) == true) { return "scene two correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 2) && fove.Gazecast(c_BrownSphere) == true) { return "scene two correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 2) && fove.Gazecast(c_PurpleCube) == false && fove.Gazecast(c_BrownSphere) == false) { return "scene two incorect object"; }

        //scene 3
        if (sceneOBJ.transform.position == new Vector3(0, 20, 3) && fove.Gazecast(c_PurpleCube) == true) { return "scene three correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 3) && fove.Gazecast(c_YellowSphere) == true) { return "scene three correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 3) && fove.Gazecast(c_PurpleCube) == false && fove.Gazecast(c_YellowSphere) == false) { return "scene three incorect object"; }

        //scene 4
        if (sceneOBJ.transform.position == new Vector3(0, 20, 4) && fove.Gazecast(c_PurpleCube) == true) { return "scene four correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 4) && fove.Gazecast(c_YellowSphere) == true) { return "scene four correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 4) && fove.Gazecast(c_PurpleCube) == false && fove.Gazecast(c_YellowSphere) == false) { return "scene four incorect object"; }

        //scene 5
        if (sceneOBJ.transform.position == new Vector3(0, 20, 5) && fove.Gazecast(c_BlackSphere) == true) { return "scene five correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 5) && fove.Gazecast(c_YellowSphere) == true) { return "scene five correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 5) && fove.Gazecast(c_BlackSphere) == false && fove.Gazecast(c_YellowSphere) == false) { return "scene five incorect object"; }

        //scene 6
        if (sceneOBJ.transform.position == new Vector3(0, 20, 6) && fove.Gazecast(c_GreenCube) == true) { return "scene six correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 6) && fove.Gazecast(c_RedCube) == true) { return "scene six correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 6) && fove.Gazecast(c_GreenCube) == false && fove.Gazecast(c_RedCube) == false) { return "scene six incorect object"; }

        //scene 7
        if (sceneOBJ.transform.position == new Vector3(0, 20, 7) && fove.Gazecast(c_YellowSphere) == true) { return "scene seven correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 7) && fove.Gazecast(c_PurpleCube) == true) { return "scene seven correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 7) && fove.Gazecast(c_YellowSphere) == false && fove.Gazecast(c_PurpleCube) == false) { return "scene seven incorect object"; }

        //scene 8
        if (sceneOBJ.transform.position == new Vector3(0, 20, 8) && fove.Gazecast(c_YellowSphere) == true) { return "scene eight correct object 1"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 8) && fove.Gazecast(c_OrangeCylander) == true) { return "scene eight correct object 2"; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 8) && fove.Gazecast(c_YellowSphere) == false && fove.Gazecast(c_OrangeCylander) == false) { return "scene eight incorect object"; }

        //should never hit else
        else { return "false"; }
    }

    public string whichobj() // 
    {
        if (fove.Gazecast(c_GreenCube) == true){ return "Green Cube";}
        if (fove.Gazecast(c_YellowSphere) == true) { return "Yellow Sphere"; }
        if (fove.Gazecast(c_GreyCapsule) == true) { return "Grey Capsule"; }
        if (fove.Gazecast(c_CyanCylander) == true) { return "Cyan Cylander"; }
        if (fove.Gazecast(c_RedCube) == true) { return "Red Cube"; }
        if (fove.Gazecast(c_PurpleCube) == true) { return "Purple Cube"; }
        if (fove.Gazecast(c_BlackSphere) == true) { return "Black Sphere"; }
        if (fove.Gazecast(c_BrownSphere) == true) { return "Brown Sphere"; }
        if (fove.Gazecast(c_PinkCapsule) == true) { return "Pink Capsule"; }
        if (fove.Gazecast(c_OrangeCylander) == true) { return "Orange Cylander"; }
        else{return "no object";}
    }

    public Vector3 findShapeLocation()/*1493*/
    {
        if (fove.Gazecast(c_GreenCube) == true){return GO_GreenCube.transform.position;}
        if (fove.Gazecast(c_YellowSphere) == true) { return GO_YellowSphere.transform.position; }
        if (fove.Gazecast(c_GreyCapsule) == true) { return GO_GreyCapsule.transform.position; }
        if (fove.Gazecast(c_CyanCylander) == true) { return GO_CyanCylander.transform.position; }
        if (fove.Gazecast(c_RedCube) == true) { return GO_RedCube.transform.position;}
        if (fove.Gazecast(c_PurpleCube) == true) { return GO_PurpleCube.transform.position; }
        if (fove.Gazecast(c_BlackSphere) == true) { return GO_BlackSphere.transform.position; }
        if (fove.Gazecast(c_BrownSphere) == true) { return GO_BrownSphere.transform.position; }
        if (fove.Gazecast(c_PinkCapsule) == true) { return GO_PinkCapsule.transform.position; }
        if (fove.Gazecast(c_OrangeCylander) == true) { return GO_OrangeCylander.transform.position; }
        else { return Vector3.zero; }
    }

    public int findTestNumber()
    {
        int scenenum = testNum;
        if (sceneOBJ.transform.position == new Vector3(0, 20, 0)) { return 0; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 1)) { return 1; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 2)) { return 2; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 3)) { return 3; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 4)) { return 4; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 5)) { return 5; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 6)) { return 6; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 7)) { return 7; }
        if (sceneOBJ.transform.position == new Vector3(0, 20, 8)) { return 8; }
        else { return 0; }

    }

   [Serializable]
    public struct RecordingPrecision_struct
    {
        [Tooltip("How many digits of decimal precision to record")]
        public int timePrecision;

        [Tooltip("How many digits of decimal precision to use when writing vector data")]
        public int vectorPrecision;
        [Tooltip("Forces unused decimal precision to be written out with zeros, for instance, 4 rpecision digits " +
                 "and a value of 0.12 would be written \"0.1200\"")]
        public int BooleanPrecision;
        public bool forcePrecisionDigits;
    }

    public RecordingPrecision_struct recordingPrecision = new RecordingPrecision_struct
    {
        timePrecision = 10,
        vectorPrecision = 3,
        BooleanPrecision = 1,
        forcePrecisionDigits = false
    };

    //=================//
    // Private members //
    //=================//

    // Pricision format strings for converting numbers to strings in the CSV
    private string tPrecision;
    private string vPrecision;

    // An internal flag to track whether we should be recording or not
    private bool recordingStopped = true;

    // A struct for recording in one place all the information that needs to be recorded for each frame
    // If you need more data recorded, you can add more fields here. Just be sure to write is out as well later on.

    public Boolean isLookingAtObject;/*1493*/
    public Vector3 shapeLocation;/*1493*/
    public string shapeName;/*1493*/
    public int testNum;/*1493*/
    public string indicatedselection;
    public string correctobj;
    class RecordingDatum
    {
        public float frameTime;
        public Ray leftGaze;
        public Ray rightGaze;
        public Boolean isLookingAtObject = false; /*1493 check if looking at object*/
        public Vector3 shapeLocation = new Vector3(0,0,0); /*1493 check object location*/
        public string shapeName = "no object" ; /*1493 check object identification*/
        public int testNum;/*1493 returns the scene number*/
        public string indicatedselection;
        public string correctobj;
    }

    // A list for storing the recorded data from many frames
    private List<RecordingDatum> dataSlice; 

    // This reference to a list is used by the writing thread. Essentially, one list is being populated (above)
    // while another can be writing out to disk asynchronously (this one).
    private List<RecordingDatum> dataToWrite = null;

    // This mutex is used to prevent the main thread from changing the "dataToWrite" variable if it's currently
    // being used by the writing thread. This should not cause a conflict in most cases unless the write interval
    // is too large for the data being written out.
    private Mutex writingDataMutex = new Mutex(false);

    private EventWaitHandle threadWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

    // Track whether or not the write thread should live.
    private bool threadShouldLive = true;

    // The thread object which we will call into the write thread function.
    private Thread writeThread;

    // Use this for initialization.
    void Start()
    {

        // Check to make sure that the FOVE interface variable is assigned. This prevents a ton of errors
        // from filling your log if you forget to assign the interface through the inspector.
        if (fove == null)
        {
            Debug.LogWarning("Forgot to assign a Fove interface to the FOVERecorder object.");
            enabled = false;
            return;
        }

        // We set the initial data slice capacity to the expected size + 1 so that we never waste time reallocating and
        // copying data under the hood. If the system ever requires more than a single extra entry, there is likely
        // a severe problem causing delays which should be addressed.
        dataSlice = new List<RecordingDatum>((int)(writeAtDataCount + 1));

        // If overwrite is not set, then we need to make sure our selected file name is valid before proceeding.
        {
            string testFileName = fileName + ".csv";
            if (!overwriteExistingFile)
            {
                int counter = 1;
                while (File.Exists(testFileName))
                {
                    testFileName = fileName + "_" + (counter++) + ".csv"; // e.g., "results_12.csv"
                }
            }
            fileName = testFileName;

            Debug.Log("Writing data to " + fileName);
        }

        try
        {
            File.WriteAllText(fileName, "frameTime," +
                                        "leftGaze origin x,leftGaze origin y,leftGaze origin z," +
                                        "leftGaze direction x,leftGaze direction y,leftGaze direction z," +
                                        "rightGaze origin x,rightGaze origin y,rightGaze origin z," +
                                        "rightGaze direction x,rightGaze direction y,rightGaze direction z," +
                                        "is looking at object ,object identification ,object location, scene number, indicating selection,   \n");/*1493 added in extra colums to the file on application start*/
        }
        catch (Exception e)
        {
            Debug.LogError("Error writing header to output file:\n" + e);
            enabled = false;
            return;
        }

        // Setup the significant digits argument strings used when serializing numbers to text for the CSV
        char precisionChar = recordingPrecision.forcePrecisionDigits ? '0' : '#';
        vPrecision = "#0." + new string(precisionChar, recordingPrecision.vectorPrecision);
        tPrecision = "#0." + new string(precisionChar, recordingPrecision.timePrecision);

        // Coroutines give us a bit more control over when the call happens, and also simplify the code
        // structure. However they are only ever called once per frame -- they processing to happen in
        // pieces, but they shouldn't be confused with threads.
        StartCoroutine(RecordData());

        // Create the write thread to call "WriteThreadFunc", and then start it.
        writeThread = new Thread(WriteThreadFunc);
        writeThread.Start();
    }



    // Unity's standard Update function, here used only to listen for input to toggle data recording
    void Update()
    {
        // If you press the assigned key, it will toggle the "recordingStopped" variable.
        if (Input.GetKeyDown(toggleRecordingKeyCode))
        {
            recordingStopped = !recordingStopped;
            Debug.Log(recordingStopped ? "Stopping" : "Starting" + " data recording...");
        }
    }

    // This is called when the program quits, or when you press the stop button in the editor (if running from there).
    void OnApplicationQuit()
    {
        if (writeThread == null)
            return;

        // Get a lock to the mutex to make sure data isn't being written. Wait up to 200 milliseconds.
        if (writingDataMutex.WaitOne(200))
        {
            // Tell the thread to end, then release the mutex so it can finish.
            threadShouldLive = false;

            CheckForNullDataToWrite();
            dataToWrite = dataSlice;
            dataSlice = null;

            writingDataMutex.ReleaseMutex();

            if (!threadWaitHandle.Set())
                Debug.LogError("Error setting the event to wake up the file writer thread on application quit");
        }
        else
        {
            // If it times out, tell the operating system to abort the thread.
            writeThread.Abort();
        }

        // Wait for the write thrtead to end (up to 1 second).
        writeThread.Join(1000);
    }

    void CheckForNullDataToWrite()
    {
        // The write thread sets dataToWrite to null when it's done, so if it isn't null here, it's likely
        // that some major error occured.
        if (dataToWrite != null)
        {
            Debug.LogError("dataToWrite was not reset when it came time to set it; this could indicate a" +
                           "serious problem in the data recording/writing process.");
        }
    }

    // The coroutine function which records data to the dataSlice List<> member
    IEnumerator RecordData()
    {
        // Inifinite loops are okay within coroutines because the "yield" statement pauses the function each time to
        // return control to the main program. Great for breaking tasks up into smaller chunks over time, or for doing
        // small amounts of work each frame but potentially outside of the normal Update cycle/call order.
        while (true)
        {
            // This statement pauses this function until Unity has finished rendering a frame. Inside the while loop,
            // this means that this function will resume from here every frame.
            yield return new WaitForEndOfFrame();

            // If recording is stopped (which is it by default), loop back around next frame.
            if (recordingStopped)
                continue;

            // The FoveInterfaceBase.EyeRays struct contains world-space rays indicating eye gaze origin and direction,
            // so you don't necessarily need to record head position and orientation just to transform the gaze vectors
            // themselves. This data is pre-transformed for you.
            var rays = fove.GetGazeRays();

            // If you add new fields, be sure to write them here.
            RecordingDatum datum = new RecordingDatum
            {
                frameTime = Time.time,
                leftGaze = rays.left,
                rightGaze = rays.right,
                isLookingAtObject = isLookingAtObj(),// 1493 check if looking at object
                shapeName = whichobj(),// 1493 check object identification
                shapeLocation = findShapeLocation(), //check object location
                testNum = findTestNumber(), //1493 gets test number
                indicatedselection = IsIndicatingSelection(),
                correctobj = IsLookingAtCorrectObj()

            };

            dataSlice.Add(datum);

            if (dataSlice.Count >= writeAtDataCount)
            {
                // Make sure we have exclusive access by locking the mutex, but only wait for up to 30 milliseconds.
                if (!writingDataMutex.WaitOne(30))
                {
                    // If we got here, it means that we couldn't acquire exclusive access within the specified time
                    // limit. Likely this means an error happened, but it could also mean that more data was being
                    // written than it took to gather another set of data -- in which case you may need to extend the
                    // timeout duration, though that will cause a noticeable frame skip in your application.

                    // For now, the best thing we can do is continue the loop and try writing data again next frame.
                    long excess = dataSlice.Count - writeAtDataCount;
                    if (excess > 1)
                        Debug.LogError("Data slice is " + excess + " entries over where it should be; this is" +
                                       "indicative of a major performance concern in the data recording and writing" +
                                       "process.");
                    continue;
                }

                CheckForNullDataToWrite();

                // Move our current slice over to dataToWrite, and then create a new slice.
                dataToWrite = dataSlice;
                dataSlice = new List<RecordingDatum>((int)(writeAtDataCount + 1));

                // Release our claim on the mutex.
                writingDataMutex.ReleaseMutex();

                if (!threadWaitHandle.Set())
                    Debug.LogError("Error setting the event to wake up the file writer thread");
            }
        }
    }

    private void WriteDataFromThread()
    {
        if (!writingDataMutex.WaitOne(10))
        {
            Debug.LogWarning("Write thread couldn't lock mutex for 10ms, which is indicative of a problem where" +
                             "the core loop is holding onto the mutex for too long, or may have not released the" +
                             "mutex.");
            return;
        }

        if (dataToWrite != null)
        {
            Debug.Log("Writing " + dataToWrite.Count + " lines");
            try
            {
                string text = "";

                foreach (var datum in dataToWrite)
                {
                    // This writes each element in the data list as a CSV-formatted line. Be sure to update this
                    // (carefully) if you add or change around the data you're using.
                    text += string.Format(
                        "\"{0}\"," +
                        "\"{1}\",\"{2}\",\"{3}\"," +
                        "\"{4}\",\"{5}\",\"{6}\"," +
                        "\"{7}\",\"{8}\",\"{9}\"," +
                        "\"{10}\",\"{11}\",\"{12}\"," +
                        "\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\"\n", // 1493 extra colums for is looking at object and object identification
                        datum.frameTime.ToString(tPrecision),
                        datum.leftGaze.origin.x.ToString(vPrecision),
                        datum.leftGaze.origin.y.ToString(vPrecision),
                        datum.leftGaze.origin.z.ToString(vPrecision),
                        datum.leftGaze.direction.x.ToString(vPrecision),
                        datum.leftGaze.direction.y.ToString(vPrecision),
                        datum.leftGaze.direction.z.ToString(vPrecision),
                        datum.rightGaze.origin.x.ToString(vPrecision),
                        datum.rightGaze.origin.y.ToString(vPrecision),
                        datum.rightGaze.origin.z.ToString(vPrecision),
                        datum.rightGaze.direction.x.ToString(vPrecision),
                        datum.rightGaze.direction.y.ToString(vPrecision),
                        datum.rightGaze.direction.z.ToString(vPrecision),
                        datum.isLookingAtObject.ToString(),// is looking at object 1493
                        datum.shapeName.ToString(), // object identification 1493
                        datum.shapeLocation.ToString(vPrecision), // object location 1493
                        datum.testNum.ToString(), // object location 1493
                        datum.indicatedselection.ToString(), // is the user indicating their selection 1493
                        datum.correctobj.ToString() // is the obbject that the user is looking at correct? 1493
                        );
                }

                File.AppendAllText(fileName, text);
            }
            catch (Exception e)
            {
                Debug.LogWarning("Exception writing to data file:\n" + e);
                threadShouldLive = false;
            }

            dataToWrite = null;
        }

        writingDataMutex.ReleaseMutex();
    }

    // This is the writing thread. By offloading file writing to a thread, we are less likely to impact peceived
    // performance inside the Unity game loop, and thus more likely to have accurate, consistent results.
    private void WriteThreadFunc()
    {
        while (threadShouldLive)
        {
            if (threadWaitHandle.WaitOne())
                WriteDataFromThread();
        }

        // Try to write one last time once the thread ends to catch any missed elements
        WriteDataFromThread();
    }
}