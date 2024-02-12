using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Boo.Lang;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;
using UnityScript.Steps;
using List = System.Collections.Generic.List<byte[]>;

using SysList = System.Collections.Generic.List<byte>;

public class constellations : MonoBehaviour
{

    public FileStream constellationTextAssetData;
    //Stream s = new FileStream("Assets//testbinary.bin", FileMode.Open);


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(constellationTextAssetData);
        byte[] fileBytes = File.ReadAllBytes("Assets/module-omicron/Resources/constellationship.fab");
        int i = 8;
        //BinaryReader reader = new BinaryReader(File.Open("Assets/module-omicron/Resources/constellationship.fab", FileMode.Open, FileAccess.Read));
        //Debug.Log(fileBytes.Length+" "+ reader.BaseStream.Length);
        //int length = (int)reader.BaseStream.Length;
        using (BinaryReader reader = new BinaryReader(File.Open("Assets/module-omicron/Resources/constellationship.fab", FileMode.Open, FileAccess.Read)))
        {
            List lines = new List();
            byte currentByte;
            SysList currentLine = new SysList();
            //Debug.Log(reader.ReadByte());
            var j = 0;
            byte[] text;
            byte[] headerBytes = reader.ReadBytes((int)reader.BaseStream.Length); // Replace 8 with the actual header size
            
            string formatIdentifier = Encoding.ASCII.GetString(headerBytes, 0, (int)reader.BaseStream.Length); // Example: extract format identifier
            Debug.Log(formatIdentifier + "  " + reader);
            string[] result = formatIdentifier.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Log(result[0]);
            foreach (string r in result)
            {
                Debug.Log(r);
            }
            //do
            //{
            //    text = reader.ReadBytes(4);
            //    //Console.WriteLine(text);
            //    string formatIdentifier = Encoding.ASCII.GetString(text, 0,8); // Example: extract format identifier
            //    Debug.Log(formatIdentifier+"  ");
            //    print(text);
            //} while (text != null);


            //while ((currentByte = reader.ReadByte()) != -1)
            //{
            //    // Identify delimiter (replace with your specific delimiter check)
            //    if (currentByte == 0x0A || currentByte == 0x0D) // Example: checking for '\n' or '\r'
            //    {
            //        lines.Add(currentLine.ToArray());
            //        currentLine.Clear();
            //    }
            //    else
            //    {
            //        currentLine.Add(currentByte);
            //    }
            //}

            // Handle the last line if it doesn't end with a delimiter
            //if (currentLine.Any())
            //{
            //    lines.Add(currentLine.ToArray());
            //}

            //// Process each line in the "lines" list
            //foreach (var line in lines)
            //{
            //    string formatIdentifier = Encoding.ASCII.GetString(line, 2, 4);
            //    Debug.Log(formatIdentifier);

            //}
        }
      

        //while (reader.BaseStream.Position != length)
        //{
        //    int bytesToRead = reader.ReadInt32();
        //    byte[] v = reader.ReadBytes(bytesToRead);
        //    Debug.Log(v.Length);
        //    //Dictionary<string, object[]> row = FromByteArray(v);
        //}
        //foreach (byte b in fileBytes)
        //{
        //    Debug.Log(b);
        //    //string formatIdentifier = Encoding.ASCII.GetString(b, 2, 4);
        //    //Debug.Log(formatIdentifier);

        //}
        //while (true) {
        //    string formatIdentifier = Encoding.ASCII.GetString(fileBytes, 0, i);
        //    Debug.Log(formatIdentifier);
        //    i = i + 8;




        //foreach (byte b in fileBytes)
        //{
        //    Debug.Log(b);
        //    string formatIdentifier = Encoding.ASCII.GetString(b, 0, 4);
        //}
        //using (BinaryReader reader = new BinaryReader(File.Open("Assets/module-omicron/Resources/constellationship.fab", FileMode.Open, FileAccess.Read)))
        //{
        //    // 3. Read the file header (modify based on your file format)
        //    // Example: Read bytes for format identifier, version, data size, etc.

        //    foreach (byte b in reader.ReadBytes())
        //    {

        //    }
        //        byte[] headerBytes = reader.ReadBytes(8); // Replace 8 with the actual header size
        //    string formatIdentifier = Encoding.ASCII.GetString(headerBytes, 0, 4); // Example: extract format identifier
        //    Debug.Log(formatIdentifier+"  "+ reader);


        //}
        //    //BinaryReader reader = new BinaryReader(File.Open("Assets/module-omicron/Resources/constellationship.fab", FileMode.Open, FileAccess.Read));
        //byte[] headerBytes = reader.ReadBytes(8);
        //string formatIdentifier = Encoding.ASCII.GetString(headerBytes, 0, 4); // Example: extract format identifier
        //Debug.Log("content: "+ formatIdentifier);

        //var content = Resources.Load("constellationship");
        //Debug.Log("content: ", content);
        //foreach (PropertyInfo car in content.GetType().GetProperties())
        //{
        //    Debug.Log(car.PropertyType);
        //}
        //IEnumerator EmpEnumerator = content.GetEnumerator();
        //EmpEnumerator.Reset();
        //while (EmpEnumerator.MoveNext())
        //{


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
