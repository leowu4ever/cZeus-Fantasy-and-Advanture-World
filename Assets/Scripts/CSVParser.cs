using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class CSVParser : MonoBehaviour
{

	public struct Packet
	{
		//public double x, y, z;
		public List<string> displayData; //= new List<List<string>>();
		public List<string> answerData; //= new List<List<string>>();
		public int rowSize;
		public int columnSize;
		public string index;
		public bool isLShape;
	}

	public class ParseCSV
	{
		public static Packet generateData (string level)
		{	
			//https://www.google.co.uk/search?client=safari&rls=en&q=unity+resource+csv+iphone&oq=unity+resource+csv+iphone&gs_l=serp.12...0.0.0.263760.0.0.0.0.0.0.0.0..0.0....0...1c..64.serp..0.0.0.V6kbAgaRCsM
			//http://docs.unity3d.com/Manual/LoadingResourcesatRuntime.html
			//http://answers.unity3d.com/questions/963335/reading-from-csv-work-on-editor-and-no-data-on-dev.html
			//http://answers.unity3d.com/questions/854658/android-persistent-data-loading-fails.html
			string filepath = "Assets/CSV/level" + level + ".csv";
            //System.IO.StreamReader data = new System.IO.StreamReader (filepath);
            System.IO.StreamReader data = new System.IO.StreamReader(new System.IO.MemoryStream((Resources.Load("level" + level) as TextAsset).bytes));

            string dataline;
			string[] rawData;
			Packet packet = new Packet ();
			string readDataLine;
			int row = 0;//Row of CSV
			while (true) {//calculate number of rows
				readDataLine = data.ReadLine ();
				if (readDataLine == null)
					break;
				if (readDataLine.Substring (0, 1).Equals (",")
					|| readDataLine.Substring (0, 1).Equals (""))
					break;
				row++;
			}
			//generate random number
			int Number = Random.Range (1, row);
			data.Close ();
            //data = new System.IO.StreamReader (filepath);
            data = new System.IO.StreamReader(new System.IO.MemoryStream((Resources.Load("level" + level) as TextAsset).bytes));

            for (int j = 1; j < Number; j++) {
				dataline = data.ReadLine ();
			}
			dataline = data.ReadLine ();
			dataline = dataline.Replace (" ", "");
			rawData = dataline.Split (',');
			
			packet.displayData = new List<string> ();
			packet.answerData = new List<string> ();
			packet.index = rawData [0];
			List<string> tempData = new List<string> ();
			packet.displayData.Clear ();
			packet.answerData.Clear ();
			packet.isLShape = false;
			if (level.Equals ("1")) {
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4) {
						packet.displayData.Add ("0");
						packet.answerData.Add (rawData [i]);
					} else {
						packet.displayData.Add (rawData [i]);
						packet.answerData.Add ("0");
					}
				}
				packet.rowSize = 1;
				packet.columnSize = 1;
				
			} else if (level.Equals ("2")) {
				
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4) {
						packet.displayData.Add ("0");
						packet.answerData.Add (rawData [i]);
					} else {
						packet.displayData.Add (rawData [i]);
						packet.answerData.Add ("0");
					}
				}
				packet.rowSize = 1;
				packet.columnSize = 1;

			} else if (level.Equals ("3")) {
				
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4 || i == 7) {
						packet.displayData.Add ("0");
						packet.answerData.Add (rawData [i]);
					} else {
						packet.displayData.Add (rawData [i]);
						packet.answerData.Add ("0");
					}
					
				}
				packet.rowSize = 1;
				packet.columnSize = 1;
			} else if (level.Equals ("4")) {
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4 || i == 7 || i == 10) {
						packet.displayData.Add ("0");
						packet.answerData.Add (rawData [i]);
					} else {
						packet.displayData.Add (rawData [i]);
						packet.answerData.Add ("0");
					}
				}
				packet.rowSize = 1;
				packet.columnSize = 1;
			} else {
				packet.rowSize = int.Parse (rawData [1].ToString ());
				packet.columnSize = int.Parse (rawData [2].ToString ());
				
				int R = packet.rowSize;
				int C = packet.columnSize;
				
				int RawDisplayDataSize = (R * C) + (2 * R * (C - 1)) + (2 * (R - 1) * C) + 2 * (R - 1) * (C - 1);
				int RawAnswerDataSize = R * C;
				int m = 0, n = 0, IndexR = 0, answerIndex = 0;

				bool isAddAnswer = false;
				bool isNegativeData = false;
				
				for (int i = 0; i < RawDisplayDataSize; i++) {
					
					if (rawData [i + 7].Equals ("-1") || rawData [answerIndex + RawDisplayDataSize + 7].Equals ("-1")) {
						packet.isLShape = true;
						isNegativeData = true;
					} else {
						packet.displayData.Add (rawData [i + 7]);
					}
					n++;
					if (m == 0) {
						if ((n - 1) % 3 == 0)
							isAddAnswer = true;
						
						if (n > 3 * (C - 1)) {
							m++;
							n = 0;
						}
					}
					if (m == 3 * IndexR + 1) {
						
						if (n > 2 * (C - 1)) {
							m++;
							n = 0;
						}
					}
					if (m == 3 * IndexR + 2) {
						
						if (n > 2 * (C - 1)) {
							m++;
							n = 0;
						}
					}
					if (m == 3 * IndexR + 3) {
						if ((n - 1) % 3 == 0)
							isAddAnswer = true;
						
						if (n > 3 * (C - 1)) {
							m++;
							n = 0;
							IndexR++;
						}
					}
					if (!isNegativeData) {
						if (isAddAnswer) {
							if (!rawData [answerIndex + RawDisplayDataSize + 7].Equals ("-1"))
								packet.answerData.Add (rawData [answerIndex + RawDisplayDataSize + 7]);
							answerIndex++;
							isAddAnswer = false;
						} else
							packet.answerData.Add ("0");
					} else
						isNegativeData = false;
				}
				if (level.Equals ("5"))
					for (int i = 0; i < RawAnswerDataSize; i++) {
						packet.displayData.Add (rawData [i + RawDisplayDataSize + 7]);
						packet.displayData.Add (rawData [i + RawDisplayDataSize + 11]);
						packet.answerData.Add ("0");
						packet.answerData.Add ("0");
					}
			}
			return packet;
		}
	}
}
