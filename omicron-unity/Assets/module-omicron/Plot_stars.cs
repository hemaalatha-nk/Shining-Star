using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Boo.Lang;
using UnityEngine;
using UnityEngine.UIElements;
using static CVSReader;
using SysList = System.Collections.Generic.List<byte>;


public class Plot_stars : MonoBehaviour
{
    new Renderer renderer;

    public TextAsset textAssetData;

    [System.Serializable]
    public class star
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }
    public GameObject myPrefab;
    public PlayerList myPlayerList = new PlayerList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    Color IntColour(int r, int g, int b)
    {
        return new Color(r / 255f, g / 255f, b / 255f);
    }

    String[] Getcons()
    {
        using (BinaryReader reader = new BinaryReader(File.Open("Assets/module-omicron/Resources/constellationship.fab", FileMode.Open, FileAccess.Read)))
        {
          
            byte[] headerBytes = reader.ReadBytes((int)reader.BaseStream.Length); // Replace 8 with the actual header size

            string formatIdentifier = Encoding.ASCII.GetString(headerBytes, 0, (int)reader.BaseStream.Length); // Example: extract format identifier
            Debug.Log(formatIdentifier + "  " + reader);
            string[] result = formatIdentifier.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Log(result[0]);
            return result;
        }
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        Debug.Log(data.Length);
        int tablesize = data.Length / 34 - 1;
        myPlayerList.player = new Player[tablesize];
        Debug.Log(tablesize);


        //GameObject otherObject = GameObject.Find("Ground Plane");
        //Bounds bounds = otherObject.GetComponent<Renderer>().bounds;
        //float width = bounds.size.x;
        string[] conslist = Getcons();
        System.Collections.Generic.List<Vector3> myList = new System.Collections.Generic.List<Vector3>();

        for (int i = 0; i < tablesize; i++)
        {
            myPlayerList.player[i] = new Player();

          
            //parsing
            if (Regex.IsMatch(data[34 * (i + 1) + 15], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[34 * (i + 1) + 16], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[34 * (i + 1) + 17], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[34 * (i + 1) + 18], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[34 * (i + 1) + 29], @"^-?[0-9]+(?:\.[0-9]+)?$"))
            {
                myPlayerList.player[i].x = float.Parse(data[34 * (i + 1) + 16]);
                myPlayerList.player[i].y = float.Parse(data[34 * (i + 1) + 17]);
                myPlayerList.player[i].z = float.Parse(data[34 * (i + 1) + 18]);
               

                //float ra = float.Parse(data[34 * (i + 1) + 12]);
                //float dec = float.Parse(data[34 * (i + 1) + 13]);
                //double x = System.Math.Cos(ra);
                //double y = System.Math.Sin(dec);
                //double z = System.Math.Sin(ra);
                //double y_cos = System.Math.Cos(dec);
                //x *= y_cos;
                //z *= y_cos;

                //float distanceInMeters = float.Parse(data[34 * (i + 1) + 15]);
                //Vector3 displacement = new Vector3(float.Parse(data[34 * (i + 1) + 29]) * 1.01236f, float.Parse(data[34 * (i + 1) + 30]) * 1.01236f, float.Parse(data[34 * (i + 1) + 31]) * 1.01236f);
                //Vector3 objectPosition = displacement + new Vector3(0, 0.000005f, 0);
                Debug.Log("lol: "+ data[34 * (i + 1) + 29]+" "+ myPlayerList.player);
                Debug.Log("prc to foot: "+1.0123614111811E+17f / (float)Math.Pow(10, 17f));

                //GameObject prefabInstance = Instantiate(myPrefab, new Vector3((objectPosition.x / (float)Math.Pow(10, 21f)), (objectPosition.y / (float)Math.Pow(10, 21f)), (objectPosition.z / (float)Math.Pow(10, 21f))), Quaternion.identity) as GameObject;

                GameObject prefabInstance = Instantiate(myPrefab, new Vector3((float.Parse(data[34 * (i + 1) + 16])*1.01236f), (float.Parse(data[34 * (i + 1) + 17]) * 1.01236f), (float.Parse(data[34 * (i + 1) + 18]) * 1.01236f)), Quaternion.identity) as GameObject;
                //prefabInstance.transform.Translate(Vector3.up * 2 * Time.deltaTime, Space.World);

                //prefabInstance.transform.position = displacement;

                //Vector3 objectPosition = prefabInstance.transform.position - displacement;

                //float distance = objectPosition.magnitude;
                //Debug.Log("lol2: " + objectPosition+" "+distance+" "+ Time.deltaTime);

                //float moveAmount = 100f * Time.deltaTime;
                //var o = Mathf.PingPong(Time.time * 2, 1);
                //transform.position = Vector3.Lerp(transform.position, displacement, o);
                //if (moveAmount >= distance)
                //{
                //    Debug.Log("lol3: " + moveAmount + " " + distance);
                //    prefabInstance.transform.Translate(objectPosition, Space.World);
                //}
                //else
                //{
                //    Debug.Log("lol4: " + moveAmount + " " + distance);
                //    prefabInstance.transform.Translate(objectPosition.normalized * moveAmount, Space.World);
                //}

                //Access material and modify emission
                Renderer instanceRenderer = prefabInstance.GetComponent<Renderer>();
                Material instanceMaterial = instanceRenderer.material;
                //GameObject go = prefabInstance.GetComponent<GameObject>();
                //prefabInstance.transform.position = new Vector3(0, 0, 0);

                renderer = GetComponent<Renderer>();
          


                //Vector3 newra = new Vector3( float.Parse(data[34 * (i + 1) + 16]);

                // OBAFGKM colours from: 
                Color[] col = new Color[9];
                col[0] = IntColour(0x5c, 0x7c, 0xff); // O1
                col[1] = IntColour(0x5d, 0x7e, 0xff); // B0.5
                col[2] = IntColour(0x79, 0x96, 0xff); // A0
                col[3] = IntColour(0xb8, 0xc5, 0xff); // F0
                col[4] = IntColour(0xff, 0xef, 0xed); // G1
                col[5] = IntColour(0xff, 0xde, 0xc0); // K0
                col[6] = IntColour(0xff, 0xa2, 0x5a); // M0
                col[7] = IntColour(0xff, 0x7d, 0x24); // M9.5
                col[8] = Color.white;

                char spectral_type = data[34 * (i + 1) + 32][0];

                int col_idx = -1;
                if (spectral_type == 'O')
                {
                    col_idx = 0;
                }
                else if (spectral_type == 'B')
                {
                    col_idx = 1;
                }
                else if (spectral_type == 'A')
                {
                    col_idx = 2;
                }
                else if (spectral_type == 'F')
                {
                    col_idx = 3;
                }
                else if (spectral_type == 'G')
                {
                    col_idx = 4;
                }
                else if (spectral_type == 'K')
                {
                    col_idx = 5;
                }
                else if (spectral_type == 'M')
                {
                    col_idx = 6;
                }

                // If unknown, make white.
                if (col_idx == -1)
                {
                    col_idx = 8;
                }

                Debug.Log(col[col_idx]);              //instanceMaterial.SetColor("_Color", col[col_idx]);
                instanceMaterial.SetColor("_BaseColor", col[col_idx]);
                instanceMaterial.SetColor("_EmissionColor", col[col_idx] * Mathf.LinearToGammaSpace(2f));
                instanceMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

                //prefabInstance.transform.position = new Vector3(1.0f, 1.0f, 1.0f);
                prefabInstance.transform.Translate(Vector3.up * 10f * Time.deltaTime);


                //DynamicGI.UpdateEnvironment();

                // Makes the renderer update the emission and albedo maps of our material.
                //RendererExtensions.UpdateGIMaterials(renderer);

                // Inform Unity's GI system to recalculate GI based on the new emission map.
                DynamicGI.SetEmissive(renderer, col[col_idx]);
                DynamicGI.UpdateEnvironment();

                //string[] constel = conslist[0].Split(' ');
                System.Collections.Generic.List<string> constel = new System.Collections.Generic.List<string>(conslist[0].Split(' ') );
                constel.RemoveAt(0);
                constel.RemoveAt(1);
                Debug.Log(constel);
                if (data[34 * (i + 1) + 4] != "")
                {
                    //Debug.Log("hemna: "+ constel.Contains( conslist[0].Split(' ').ToString());
                    //foreach (string u in conslist[0].Split(' ')){
                    //    Debug.Log("hemna: " + u);
                    //}
                    bool result= constel.Contains(data[34 * (i + 1) + 3]);
                    Debug.Log("hemna: " + result+" "+ constel+" "+data[34 * (i + 1) + 4]+" "+ data[34 * (i + 1) + 3]+" "+ data[34 * (i + 1) + 5]);

                    if (result)
                    {
                        //Debug.Log("hemna: " + data[34 * (i + 1) + 16] + " " + data[34 * (i + 1) + 10] + " " + data[34 * (i + 1) + 5] + " " + data[34 * (i + 1) + 4] + " " + result + " " + conslist[0]);
                        Debug.Log("hemna: " + result);
                        myList.Add(new Vector3(float.Parse(data[34 * (i + 1) + 16]) * 1.01236f, float.Parse(data[34 * (i + 1) + 17]) * 1.01236f, float.Parse(data[34 * (i + 1) + 18]) * 1.01236f));
                    }
                }
                //Instantiate(myPrefab, new Vector3(objectPosition.x / (float)Math.Pow(10, 21f), objectPosition.y / (float)Math.Pow(10, 21f), objectPosition.z / (float)Math.Pow(10, 21f)), Quaternion.identity) ;
            }
            else
            {
                //Debug.Log("its wrong");
            }
        }
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = myList.Count;
        lineRenderer.startWidth = lineRenderer.endWidth = 10f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.blue;
        Debug.Log("hemna: "+myList.Count);

        //LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = myList.Count; // Set the number of positions

        for (int i = 0; i < myList.Count - 1; i++)
        {
            lineRenderer.SetPosition(i, myList[i]); // Set start point
            lineRenderer.SetPosition(i + 1, myList[i + 1]); // Set end point
            //DrawLine(myList[i], myList[i+1], Color.red, 10f);

        }
        //for (int i = 0; i < myList.Count - 1; i++)
        //{
        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawLine(myList[i], myList[i + 1]);
        //}
    }
    public static Texture2D lineTex;

    public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
    {
        pointA.x = (int)pointA.x; pointA.y = (int)pointA.y;
        pointB.x = (int)pointB.x; pointB.y = (int)pointB.y;

        if (!lineTex) { lineTex = new Texture2D(1, 1); }
        Color savedColor = GUI.color;
        GUI.color = color;

        Matrix4x4 matrixBackup = GUI.matrix;

        float angle = Mathf.Atan2(pointB.y - pointA.y, pointB.x - pointA.x) * 180f / Mathf.PI;
        float length = (pointA - pointB).magnitude;
        GUIUtility.RotateAroundPivot(angle, pointA);
        GUI.DrawTexture(new Rect(pointA.x, pointA.y, length, width), lineTex);

        GUI.matrix = matrixBackup;
        GUI.color = savedColor;
    }
    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;
    }
}
