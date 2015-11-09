using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class CSVParser : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{	
		Packet rawData = ParseCSV.generateData ("6");		// That is how you call a static method
		List<string> displayContent = rawData.DisplayData;		// extract the display data from raw data

		// -------------------------------- How you access info --------------------------------
		Debug.Log (rawData.rowSize + "x" + rawData.columnSize + " Puzzle: " + rawData.index + " size of " + displayContent.Count);
		string displayContentInARow = "";
		for (int a = 0; a < displayContent.Count; a++) {
			displayContentInARow = displayContent [a] + " " + displayContentInARow;
		}
		Debug.Log (displayContentInARow);
	}
	
	public struct Packet
	{
		//public double x, y, z;
		public List<string> DisplayData; //= new List<List<string>>();
		public List<string> AnswerData; //= new List<List<string>>();
		public int rowSize;
		public int columnSize;
		public string index;
		public bool LShape;
	}

	public class ParseCSV
	{
		public static Packet generateData (string level)
		{	
			string filepath = "Assets/CSV/level" + level + ".csv";
			System.IO.StreamReader data = new System.IO.StreamReader (filepath);
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
			data = new System.IO.StreamReader (filepath);
			
			for (int j = 1; j < Number; j++) {
				dataline = data.ReadLine ();
			}
			dataline = data.ReadLine ();
			dataline = dataline.Replace (" ", "");
			rawData = dataline.Split (',');
			
			packet.DisplayData = new List<string> ();
			packet.AnswerData = new List<string> ();
			packet.index = rawData [0];
			List<string> tempData = new List<string> ();
			packet.DisplayData.Clear ();
			packet.AnswerData.Clear ();
			packet.LShape = false;
			if (level.Equals ("1")) {
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4) {
						packet.DisplayData.Add ("0");
						packet.AnswerData.Add (rawData [i]);
					} else {
						packet.DisplayData.Add (rawData [i]);
						packet.AnswerData.Add ("0");
					}
				}
				packet.rowSize = 1;
				packet.columnSize = 1;
				
			} else if (level.Equals ("2")) {
				
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4) {
						packet.DisplayData.Add ("0");
						packet.AnswerData.Add (rawData [i]);
					} else {
						packet.DisplayData.Add (rawData [i]);
						packet.AnswerData.Add ("0");
					}
				}
				packet.rowSize = 1;
				packet.columnSize = 1;

			} else if (level.Equals ("3")) {
				
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4 || i == 7) {
						packet.DisplayData.Add ("0");
						packet.AnswerData.Add (rawData [i]);
					} else {
						packet.DisplayData.Add (rawData [i]);
						packet.AnswerData.Add ("0");
					}
					
				}
				packet.rowSize = 1;
				packet.columnSize = 1;
			} else if (level.Equals ("4")) {
				for (int i = 1; i < rawData.Count(); i++) {
					if (rawData [i].Equals (""))
						break;
					if (i == 1 || i == 4 || i == 7 || i == 10) {
						packet.DisplayData.Add ("0");
						packet.AnswerData.Add (rawData [i]);
					} else {
						packet.DisplayData.Add (rawData [i]);
						packet.AnswerData.Add ("0");
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
						packet.LShape = true;
						isNegativeData = true;
					} else {
						packet.DisplayData.Add (rawData [i + 7]);
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
								packet.AnswerData.Add (rawData [answerIndex + RawDisplayDataSize + 7]);
							answerIndex++;
							isAddAnswer = false;
						} else
							packet.AnswerData.Add ("0");
					} else
						isNegativeData = false;
				}
				if (level.Equals ("5"))
					for (int i = 0; i < RawAnswerDataSize; i++) {
						packet.DisplayData.Add (rawData [i + RawDisplayDataSize + 7]);
						packet.DisplayData.Add (rawData [i + RawDisplayDataSize + 11]);
						packet.AnswerData.Add ("0");
						packet.AnswerData.Add ("0");
					}
			}
			return packet;
		}
	}
}
