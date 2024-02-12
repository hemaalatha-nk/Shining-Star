using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Boo.Lang;
using System.Text.RegularExpressions;

public class CVSReader : MonoBehaviour
{
    public TextAsset textAssetData;
   

  
    [System.Serializable]

    public class Player
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
    //Color IntColour(int r, int g, int b)
    //{
    //    return new Color(r / 255f, g / 255f, b / 255f);
    //}
    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        Debug.Log(data.Length);

        int tablesize = data.Length / 34 - 1;
        myPlayerList.player = new Player[tablesize];
        Debug.Log(tablesize);

        for (int i = 0; i < tablesize; i++)
        {
            myPlayerList.player[i] = new Player();
      
            //Debug.Log(data[34 * (i + 1)+32]);
            //Debug.Log(data[34 * (i + 1)+16]);
            //Debug.Log(data[34 * (i + 1) + 17]);
            //Debug.Log((data[34 * (i + 1) + 18]));
            //Debug.Log(Regex.IsMatch(data[34 * (i + 1) + 15], @"^-?[0-9]+(?:\.[0-9]+)?$"));
            //Debug.Log(Regex.IsMatch(data[34 * (i + 1) + 16], @"^-?[0-9]+(?:\.[0-9]+)?$"));
            //Debug.Log(Regex.IsMatch(data[34 * (i + 1) + 17], @"^-?[0-9]+(?:\.[0-9]+)?$"));
            //Debug.Log(Regex.IsMatch(data[34 * (i + 1) + 18], @"^-?[0-9]+(?:\.[0-9]+)?$"));
            if (Regex.IsMatch(data[34 * (i + 1) + 15], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[34 * (i + 1) + 16], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[34 * (i + 1) + 17], @"^-?[0-9]+(?:\.[0-9]+)?$")  && Regex.IsMatch(data[34 * (i + 1) + 18], @"^-?[0-9]+(?:\.[0-9]+)?$")  )
            {
                myPlayerList.player[i].x = float.Parse(data[34 * (i + 1) + 16]);
                //17
                myPlayerList.player[i].y = float.Parse(data[34 * (i + 1) + 17]);
                myPlayerList.player[i].z = float.Parse(data[34 * (i + 1) + 18]);

                float distanceInMeters = float.Parse(data[34 * (i + 1) + 15]) * 3.08568f * (float)Math.Pow(10, 18f);
                Vector3 displacement = new Vector3(myPlayerList.player[i].x * distanceInMeters, myPlayerList.player[i].y * distanceInMeters, myPlayerList.player[i].z * distanceInMeters);
                Vector3 objectPosition = displacement + new Vector3(0, 0.000005f, 0);
                Debug.Log(objectPosition.x / Math.Pow(10, 22f));

                //float rho = Mathf.Sqrt(myPlayerList.player[i].x * myPlayerList.player[i].x + myPlayerList.player[i].y * myPlayerList.player[i].y + myPlayerList.player[i].z * myPlayerList.player[i].z);
                //float theta = Mathf.Atan2(myPlayerList.player[i].y, myPlayerList.player[i].x);
                //if (myPlayerList.player[i].x < 0f && myPlayerList.player[i].y >= 0f)
                //{
                //    theta += Mathf.PI;
                //}

                //if (myPlayerList.player[i].x < 0f && myPlayerList.player[i].y < 0f)
                //{
                //    theta += Mathf.PI;
                //}
                //float phi = Mathf.Acos(myPlayerList.player[i].z / rho);
                //float new_x = rho * Mathf.Sin(phi) * Mathf.Cos(theta);
                //float new_y = rho * Mathf.Sin(phi) * Mathf.Sin(theta);
                //float new_z = rho * Mathf.Cos(phi);
                // Create a prefab instance
                GameObject prefabInstance = Instantiate(myPrefab, new Vector3(objectPosition.x / (float)Math.Pow(10, 21f), objectPosition.y / (float)Math.Pow(10, 21f), objectPosition.z / (float)Math.Pow(10, 21f)), Quaternion.identity) as GameObject;
                //Access material and modify emission
                //Renderer instanceRenderer = prefabInstance.GetComponent<Renderer>();
                //Material instanceMaterial = instanceRenderer.material;

                // OBAFGKM colours from: 
                //Color[] col = new Color[9];
                //col[0] = IntColour(0x5c, 0x7c, 0xff); // O1
                //col[1] = IntColour(0x5d, 0x7e, 0xff); // B0.5
                //col[2] = IntColour(0x79, 0x96, 0xff); // A0
                //col[3] = IntColour(0xb8, 0xc5, 0xff); // F0
                //col[4] = IntColour(0xff, 0xef, 0xed); // G1
                //col[5] = IntColour(0xff, 0xde, 0xc0); // K0
                //col[6] = IntColour(0xff, 0xa2, 0x5a); // M0
                //col[7] = IntColour(0xff, 0x7d, 0x24); // M9.5
                //col[8] = Color.white;

                //char spectral_type = data[34 * (i + 1) + 32][0];

                //int col_idx = -1;
                //if (spectral_type == 'O')
                //{
                //    col_idx = 0;
                //}
                //else if (spectral_type == 'B')
                //{
                //    col_idx = 1;
                //}
                //else if (spectral_type == 'A')
                //{
                //    col_idx = 2;
                //}
                //else if (spectral_type == 'F')
                //{
                //    col_idx = 3;
                //}
                //else if (spectral_type == 'G')
                //{
                //    col_idx = 4;
                //}
                //else if (spectral_type == 'K')
                //{
                //    col_idx = 5;
                //}
                //else if (spectral_type == 'M')
                //{
                //    col_idx = 6;
                //}

                //// If unknown, make white.
                //if (col_idx == -1)
                //{
                //    col_idx = 8;
                //}
                //instanceMaterial.SetColor("_Color", col[col_idx]); 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
