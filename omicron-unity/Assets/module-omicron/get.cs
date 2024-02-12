using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class get : MonoBehaviour
{

    public TextAsset textAssetData;
    public GameObject myPrefab;

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
        string[] data = textAssetData.text.Split(new string[] {"\n" }, StringSplitOptions.None);
        Debug.Log("helo: "+data.Length);
        int tablesize = data.Length / 5;

        string[] conslist = Getcons();
        System.Collections.Generic.List<string> constel = new System.Collections.Generic.List<string>(conslist[0].Split(' '));
        //constel.RemoveAt(0);
        //constel.RemoveAt(1);
        //constel.RemoveAt(2);
        Debug.Log("constel "+constel.Count);
        for (int i=3;i< constel.Count;i++ )
        {
            Debug.Log("constel " + constel[i]);
        }
            System.Collections.Generic.List<Vector3> myList = new System.Collections.Generic.List<Vector3>();
        for (int i = 1; i < data.Length-1; i++)
        {
            string[] data2 = data[i].Split(new string[] { "," }, StringSplitOptions.None);
            //Debug.Log(data2.Length+" " + data2[0]+" "+data2[1] + " " + data2[2] + " " + data2[3] + " " + data2[4]);
            //Debug.Log(data[4 * (i + 1) + 1]+" "+ data[4 * (i + 1) + 2]+" "+ data[4 * (i + 1) + 3]);
            //if (Regex.IsMatch(data[4 * (i + 1) + 1], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[4 * (i + 1) + 2], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[4 * (i + 1) + 3], @"^-?[0-9]+(?:\.[0-9]+)?$") && Regex.IsMatch(data[4 * (i + 1) + 0], @"^-?[0-9]+(?:\.[0-9]+)?$"))
            //{
            //    GameObject prefabInstance = Instantiate(myPrefab, new Vector3((float.Parse(data[4 * (i + 1) + 1]) * 1.01236f), (float.Parse(data[4 * (i + 1) + 2]) * 1.01236f), (float.Parse(data[4 * (i + 1) + 3]) * 1.01236f)), Quaternion.identity) as GameObject;

            //}
            //else{
            //    Debug.Log("data: "+data[4 * (i + 1) + 1] + " " + data[4 * (i + 1) + 2] + " " + data[4 * (i + 1) + 3]);

            //}
            foreach (string d in data2)
            {
                Debug.Log("data2: " + d+" "+data2.Length);
            }
            GameObject prefabInstance = Instantiate(myPrefab, new Vector3((float.Parse(data2[1]) * 1.01236f), (float.Parse(data2[2]) * 1.01236f), (float.Parse(data2[3]) * 1.01236f)), Quaternion.identity) as GameObject;
            for (int j = 3; j < constel.Count; j++)
            {
                Debug.Log("constel " + constel[j]);
                if(constel[j] == ((int)Math.Floor(float.Parse(data2[0]))).ToString()){
                    myList.Add(new Vector3((float.Parse(data2[1]) * 1.01236f), (float.Parse(data2[2]) * 1.01236f), (float.Parse(data2[3]) * 1.01236f)));
                }
            }

            //Debug.Log("jkk: " + data2[0]+" "+ float.Parse(data2[0])+" " + (int)Math.Floor(float.Parse(data2[0])));

            //bool result = constel.Contains(((int)Math.Floor(float.Parse(data2[0]))).ToString());
            //Debug.Log("jkk: " + int.Parse(data2[0]).ToString());
            //for (int k = 3; k < constel.Count; k=k++)
            //{
            //        Debug.Log("jkconstel: " + constel[k]);
            //        if(constel[k] == ((int)Math.Floor(float.Parse(data2[0]))).ToString())
            //        {

            //            Debug.Log("jkconstel: " + data2[0] + " " + float.Parse(data2[0]) + " " + (int)Math.Floor(float.Parse(data2[0])));

            //            myList.Add(new Vector3((float.Parse(data2[1]) * 1.01236f), (float.Parse(data2[2]) * 1.01236f), (float.Parse(data2[3]) * 1.01236f)));
            //        }
            //    }
            //    if (result)
            //{
            //    //Debug.Log("hemna: " + data[34 * (i + 1) + 16] + " " + data[34 * (i + 1) + 10] + " " + data[34 * (i + 1) + 5] + " " + data[34 * (i + 1) + 4] + " " + result + " " + conslist[0]);
            //    Debug.Log("hemna: " + result);
            //        Debug.Log("jkk: " + data2[0] + " " + float.Parse(data2[0]) + " " + (int)Math.Floor(float.Parse(data2[0])));

            //        myList.Add(new Vector3((float.Parse(data2[1]) * 1.01236f), (float.Parse(data2[2]) * 1.01236f), (float.Parse(data2[3]) * 1.01236f)));
            //}



        }
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = myList.Count;
        lineRenderer.startWidth = lineRenderer.endWidth = 10f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.blue;
        Debug.Log("myList: " + myList.Count);

        //LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = myList.Count; // Set the number of positions

        for (int i = 0; i < myList.Count - 1; i++)
        {
            lineRenderer.SetPosition(i, myList[i]); // Set start point
            lineRenderer.SetPosition(i + 1, myList[i + 1]); // Set end point
            //DrawLine(myList[i], myList[i+1], Color.red, 10f);

        }

    }
    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = 60;
    }
}
