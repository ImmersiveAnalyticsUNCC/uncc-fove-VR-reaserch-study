using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class ObjectMovementScript : MonoBehaviour {

    public GameObject desk;             //game objects
    public GameObject GreenCube;
    public GameObject YellowSphere;
    public GameObject GreyCapsule;
    public GameObject CyanCylander;
    public GameObject RedCube;
    public GameObject PurpleCube;
    public GameObject BlackSphere;
    public GameObject BrownSphere;
    public GameObject PinkCapsule;
    public GameObject OrangeCylander;

    public Collider c_GreenCube;            //game object colliders for detection of objects for recording
    public Collider c_YellowSphere;
    public Collider c_GreyCapsule;
    public Collider c_CyanCylander;
    public Collider c_RedCube;
    public Collider c_PurpleCube;
    public Collider c_BlackSphere;
    public Collider c_BrownSphere;
    public Collider c_PinkCapsule;
    public Collider c_OrangeCylander;

    public GameObject l_GreenCube;
    public GameObject l_YellowSphere;
    public GameObject l_GreyCapsule;
    public GameObject l_CyanCylander;
    public GameObject l_RedCube;
    public GameObject l_PurpleCube;
    public GameObject l_BlackSphere;

    public FoveInterfaceBase fove;
    public int scenenum;
    public Vector3 in1;
    public Vector3 in2 = new Vector3(0, 20, 0);
    public Vector3 in3 = new Vector3(0, 0, 0);


    public int selectable_spot;


    public Vector3 origin = new Vector3(0, 0, 0);
    public Vector3 position1 = new Vector3(0, 20, 0);
    
    public FoveInterfaceBase foVe;

    public GameObject sceneOBJ;
    public KeyCode SceneChangingButton = KeyCode.Mouse1;

    public TextMesh instructions;
    public TextMesh calibration;
    public TextMesh directions;



    // Use this for initialization
    void Start () {

        scenenum = 0;

        desk.SetActive(true);
        desk.transform.position = position1;

        GreenCube.SetActive(true);
        GreenCube.transform.position = position1;

        YellowSphere.SetActive(true);
        YellowSphere.transform.position = position1;

        GreyCapsule.SetActive(true);
        GreyCapsule.transform.position = position1;

        CyanCylander.SetActive(true);
        CyanCylander.transform.position = position1;

        RedCube.SetActive(true);
        RedCube.transform.position = position1;

        PurpleCube.SetActive(true);
        PurpleCube.transform.position = position1;

        BlackSphere.SetActive(true);
        BlackSphere.transform.position = position1;

        BrownSphere.SetActive(true);
        BrownSphere.transform.position = position1;

        PinkCapsule.SetActive(true);
        PinkCapsule.transform.position = position1;

        OrangeCylander.SetActive(true);
        OrangeCylander.transform.position = position1;

        l_BlackSphere.SetActive(true);
        l_CyanCylander.SetActive(true);
        l_GreenCube.SetActive(true);
        l_GreyCapsule.SetActive(true);
        l_PurpleCube.SetActive(true);
        l_RedCube.SetActive(true);
        l_YellowSphere.SetActive(true);

        //eyeCursorR.SetActive(false);
        //eyeCursorL.SetActive(false);

        sceneOBJ.transform.position = new Vector3(0, 20, 0);

        
    }
	
	// Update is called once per frame
	void Update () {

        

        if (Input.GetKeyDown(SceneChangingButton) == true)
        {
            scenenum++;

            if (scenenum == 1)
            {
                l_BlackSphere.SetActive(false);
                l_CyanCylander.SetActive(false);
                l_GreenCube.SetActive(false);
                l_GreyCapsule.SetActive(false);
                l_PurpleCube.SetActive(false);
                l_RedCube.SetActive(false);
                l_YellowSphere.SetActive(false);

                in1 = new Vector3(-0.019f, 0.461f, -2.146f);
                desk.transform.position = in1;//placing object
                desk.transform.localScale = new Vector3(123, 50, 180);

                in1 = new Vector3(-1.4f, 1.137f, -1.18f);
                GreenCube.transform.position = in1;//placing object

                in1 = new Vector3(-0.01f, 1.124f, -1.84f);
                YellowSphere.transform.position = in1;//placing object

                GreyCapsule.transform.position = in2;//on standby

                CyanCylander.transform.position = in2;//on standby

                in1 = new Vector3(-0.581f, 1.137f, -0.859f);
                RedCube.transform.position = in1;//placing object

                in1 = new Vector3(0.34f, 1.137f, -1.085f);
                PurpleCube.transform.position = in1;//placing object

                in1 = new Vector3(1.08f, 1.148f, -1.393f);
                BlackSphere.transform.position = in1;//placing object

                BrownSphere.transform.position = in2;//on standby

                PinkCapsule.transform.position = in2;//on standby

                OrangeCylander.transform.position = in2;//on standby

                sceneOBJ.transform.position = new Vector3(0, 20, 1);

                instructions.text = " ";

                calibration.text = "- Select the object that is farthest away from your position" + System.Environment.NewLine + "- Select the object that is closest to your position";

            }

            if (scenenum == 2)
            {
                in1 = new Vector3(-0.036f, 0.505f, -1.88f);
                desk.transform.position = in1;//Placing object
                desk.transform.localScale = new Vector3(136.8375f, 50, 180);

                in1 = new Vector3(0.65f, 1.137f, -1.071f);
                GreenCube.transform.position = in1;

                in1 = new Vector3(-0.341f, 1.13f, -1.27f);
                YellowSphere.transform.position = in1;

                in1 = new Vector3(-1.802f, 1.295f, -1.065f);
                GreyCapsule.transform.position = in1;

                in1 = new Vector3(1.623f, 1.16f, -1.59f);
                CyanCylander.transform.position = in1;

                in1 = new Vector3(-0.839f, 1.137f, -0.783f);
                RedCube.transform.position = in1;

                in1 = new Vector3(-0.014f, 1.14f, -0.387f);
                PurpleCube.transform.position = in1;

                in1 = new Vector3(1.242f, 1.142f, -1.29f);
                BlackSphere.transform.position = in1;

                in1 = new Vector3(0.276f, 1.145f, -1.41f);
                BrownSphere.transform.position = in1;

                in1 = new Vector3(1.187f, 1.269f, -0.596f);
                PinkCapsule.transform.position = in1;

                in1 = new Vector3(-1.162f, 1.16f, -1.68f);
                OrangeCylander.transform.position = in1;

                sceneOBJ.transform.position = new Vector3(0, 20, 2);
            }

            if (scenenum == 3)
            {
                in1 = new Vector3(0.07f, 0.48f, 0.371f);
                desk.transform.position = in1;
                desk.transform.localScale = new Vector3(123, 50, 284.201f);

                in1 = new Vector3(-0.432f, 1.137f, 2.252f);
                GreenCube.transform.position = in1;

                in1 = new Vector3(0.108f, 1.15f, 0.83f);
                YellowSphere.transform.position = in1;


                GreyCapsule.transform.position = in2;


                CyanCylander.transform.position = in2;

                in1 = new Vector3(-1.063f, 1.137f, 1.805f);
                RedCube.transform.position = in1;

                in1 = new Vector3(0.775f, 1.137f, 2.7f);
                PurpleCube.transform.position = in1;

                in1 = new Vector3(1.147f, 1.15f, 1.5879f);
                BlackSphere.transform.position = in1;


                BrownSphere.transform.position = in2;


                PinkCapsule.transform.position = in2;


                OrangeCylander.transform.position = in2;

                sceneOBJ.transform.position = new Vector3(0, 20, 3);
            }

            if (scenenum == 4)
            {
                in1 = new Vector3(0.072f, 0.48f, 1.67f);
                desk.transform.position = in1;
                desk.transform.localScale = new Vector3(141.8868f, 50, 209.581f);

                in1 = new Vector3(-0.635f, 1.137f, 2.492f);
                GreenCube.transform.position = in1;

                in1 = new Vector3(-0.26f, 1.133f, 2.091f);
                YellowSphere.transform.position = in1;

                in1 = new Vector3(-1.66f, 1.295f, 2.752f);
                GreyCapsule.transform.position = in1;

                in1 = new Vector3(1.748f, 1.16f, 2.364f);
                CyanCylander.transform.position = in1;

                in1 = new Vector3(-1.301f, 1.137f, 2.373f);
                RedCube.transform.position = in1;

                in1 = new Vector3(0.134f, 1.137f, 3.575f);
                PurpleCube.transform.position = in1;

                in1 = new Vector3(0.583f, 1.133f, 3.013f);
                BlackSphere.transform.position = in1;

                in1 = new Vector3(-1.107f, 1.133f, 3.162f);
                BrownSphere.transform.position = in1;

                in1 = new Vector3(1.447f, 1.269f, 3.073f);
                PinkCapsule.transform.position = in1;

                in1 = new Vector3(0.931f, 1.16f, 2.501f);
                OrangeCylander.transform.position = in1;

                sceneOBJ.transform.position = new Vector3(0, 20, 4);
            }

            if (scenenum == 5)
            {
                desk.transform.position = in2;

                in1 = new Vector3(-1.639f, 2.162f, -1.225f);
                GreenCube.transform.position = in1;

                in1 = new Vector3(0.004000038f, 1.631f, 0.016f);
                YellowSphere.transform.position = in1;

                GreyCapsule.transform.position = in2;

                CyanCylander.transform.position = in2;

                in1 = new Vector3(0.53500001f, 1.5f, -0.74f);
                RedCube.transform.position = in1;

                in1 = new Vector3(1.215f, 1.854f, -1.19f);
                PurpleCube.transform.position = in1;

                in1 = new Vector3(-0.6029999f, 1.349f, -1.794f);
                BlackSphere.transform.position = in1;

                BrownSphere.transform.position = in2;

                PinkCapsule.transform.position = in2;

                OrangeCylander.transform.position = in2;

                sceneOBJ.transform.position = new Vector3(0, 20, 5);
            }

            if (scenenum == 6)
            {
                desk.transform.position = in2;

                in1 = new Vector3(-1.269f, 1.62f, -2.522f);
                GreenCube.transform.position = in1;

                in1 = new Vector3(-0.271f, 1.28f, -2.04f);
                YellowSphere.transform.position = in1;

                in1 = new Vector3(1.387f, 1.492208f, -2.082f);
                GreyCapsule.transform.position = in1;

                in1 = new Vector3(-0.78f, 1.991f, -1.78f);
                CyanCylander.transform.position = in1;

                in1 = new Vector3(1.174f, 1.495f, -1.04f);
                RedCube.transform.position = in1;

                in1 = new Vector3(0.45f, 1.854f, -2.082f);
                PurpleCube.transform.position = in1;

                in1 = new Vector3(-0.878f, 1.349f, -2.311f);
                BlackSphere.transform.position = in1;

                in1 = new Vector3(0.12f, 1.631f, -2.221f);
                BrownSphere.transform.position = in1;

                in1 = new Vector3(2.09f, 1.492208f, -1.83f);
                PinkCapsule.transform.position = in1;

                in1 = new Vector3(1.44f, 2.2f, -1.58f);
                OrangeCylander.transform.position = in1;

                sceneOBJ.transform.position = new Vector3(0, 20, 6);
            }

            if (scenenum == 7)
            {
                desk.transform.position = in2;

                in1 = new Vector3(0.718f, 1.852f, 1.493f);
                GreenCube.transform.position = in1;

                in1 = new Vector3(-0.09900001f, 1.631f, 2.157f);
                YellowSphere.transform.position = in1;

                GreyCapsule.transform.position = in2;

                CyanCylander.transform.position = in2;

                in1 = new Vector3(-1.737f, 1.727f, 1.822f);
                RedCube.transform.position = in1;

                in1 = new Vector3(1.18f, 1.231f, 0.791f);
                PurpleCube.transform.position = in1;

                in1 = new Vector3(-0.897f, 1.349f, 1.644f);
                BlackSphere.transform.position = in1;

                BrownSphere.transform.position = in2;

                PinkCapsule.transform.position = in2;

                OrangeCylander.transform.position = in2;

                sceneOBJ.transform.position = new Vector3(0, 20, 7);
            }

            if (scenenum == 8)
            {
                desk.transform.position = in2;

                in1 = new Vector3(-1.064f, 0.971f, -0.267f);
                GreenCube.transform.position = in1;

                in1 = new Vector3(1.167f, 1.808f, -1.06f);
                YellowSphere.transform.position = in1;

                in1 = new Vector3(-1.738f, 1.373f, -0.264f);
                GreyCapsule.transform.position = in1;

                in1 = new Vector3(0.997f, 1.029f, -0.245f);
                CyanCylander.transform.position = in1;

                in1 = new Vector3(-1.924f, 1.376f, 1.237f);
                RedCube.transform.position = in1;

                in1 = new Vector3(0.707f, 1.734792f, 0.079f);
                PurpleCube.transform.position = in1;

                in1 = new Vector3(-0.289f, 1.895f, 0.946f);
                BlackSphere.transform.position = in1;

                in1 = new Vector3(-0.264f, 1.28f, 0.218f);
                BrownSphere.transform.position = in1;

                in1 = new Vector3(1.875f, 0.969f, 0.337f);
                PinkCapsule.transform.position = in1;

                in1 = new Vector3(-1.107f, 1.239f, 2f);
                OrangeCylander.transform.position = in1;

                sceneOBJ.transform.position = new Vector3(0, 20, 8);
            }

            if (scenenum > 8) //reset the scene to default 1 **old**
            {
                /*scenenum = 1;
                in1 = new Vector3(-0.49f, 0.461f, -2.146f);
                desk.transform.position = in1;//placing object

                in1 = new Vector3(-1.4f, 1.137f, -1.18f);
                GreenCube.transform.position = in1;//placing object

                in1 = new Vector3(-0.48f, 1.124f, -1.84f);
                YellowSphere.transform.position = in1;//placing object

                GreyCapsule.transform.position = in2;//on standby

                CyanCylander.transform.position = in2;//on standby

                in1 = new Vector3(-0.75f, 1.137f, -0.6f);
                RedCube.transform.position = in1;//placing object

                in1 = new Vector3(-0.31f, 1.137f, -1.17f);
                PurpleCube.transform.position = in1;//placing object

                in1 = new Vector3(0.33f, 1.148f, -1.38f);
                BlackSphere.transform.position = in1;//placing object

                BrownSphere.transform.position = in2;//on standby

                PinkCapsule.transform.position = in2;//on standby

                OrangeCylander.transform.position = in2;//on standby

                sceneOBJ.transform.position = new Vector3(0, 20, 8);*/
                Application.Quit(); //after the last scene is done the application will close 
            }
        }
    }
}
