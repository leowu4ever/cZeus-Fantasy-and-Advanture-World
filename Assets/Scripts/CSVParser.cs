using UnityEngine;
//using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CSVParser : MonoBehaviour
{
	
	ArrayList Initialdata;
	Data GetData = new Data ();
	public class Data
	{
		public ArrayList DisplayData;
		public ArrayList DisplayDataX;
		public ArrayList DisplayDataY;
		public ArrayList Answer;
		public ArrayList AnswerX;
		public ArrayList AnswerY;
		
		public Data ()
		{
			DisplayData = new ArrayList ();
			DisplayDataX = new ArrayList ();
			DisplayDataY = new ArrayList ();
			Answer = new ArrayList ();
			AnswerX = new ArrayList ();
			AnswerY = new ArrayList ();
		}
		
		public int DimensionX;
		public int DimensionY;
		
		public void Copy (Data TempData)
		{
			DisplayData = TempData.DisplayData;
			DisplayDataX = TempData.DisplayDataX;
			DisplayDataY = TempData.DisplayDataY;
			Answer = TempData.Answer;
			AnswerX = TempData.AnswerX;
			AnswerY = TempData.AnswerY;
			DimensionX = TempData.DimensionX;
			DimensionY = TempData.DimensionY;
		}
		
	}
	// Use this for initialization
	void Start ()
	{
		string filepath = "Assets/CSV/level8.csv";
		System.IO.StreamReader reader = new System.IO.StreamReader (filepath);
		string dataline;
		int row = 0;//Row of CSV
		while ((dataline = reader.ReadLine()) != null) {//calculate number of rows
			row++;
		}
		//generate random number
		int i = Random.Range (1, row);
		//load data from csv
		reader.Close ();
		reader = new System.IO.StreamReader (filepath);
		for (int j = 1; j < i; j++) {
			dataline = reader.ReadLine ();
		}
		dataline = reader.ReadLine ();
		//Debug.Log (dataline);
		//calculate number of colum
		Initialdata = new ArrayList (dataline.Split (','));
		
		//Test data format
		//Debug.Log (row);
		GenerateData (8);
		//Debug.Log(test);
		/*for (int m = 0; m<GetData.Answer.Count; m++) {
			for (int n = 0; n<(6/GetData.Answer.Count); n++)
			{
				Debug.Log(GetData.Answer[m][n])
			}
		}
		for (int m = 0; m<GetData.DisplayData; m++) {
			for (int n = 0; n<6; n++)
			{
				Debug.Log(GetData.DisplayData[m][n])
			}
		}*/
		
	}
	//Return data according to the position
	void GenerateData (int Level)
	{
		Data TempData = new Data ();
		if (Level == 1) {
			Initialdata.RemoveAt (0);
			TempData.Answer.Add (Initialdata [0]);
			TempData.Answer.Add (Initialdata [3]);
			/*for (int m = 0; m<2; m++) {
				Debug.Log(TempData.Answer[m]);
			}*/
			Initialdata [0] = 0;
			Initialdata [3] = 0;
			TempData.DisplayData = Initialdata;
			/*for (int m = 0; m<8; m++) {
				Debug.Log(TempData.DisplayData[m]);
			}*/
			TempData.DimensionX = 1;
			TempData.DimensionY = 1;
			GetData.Copy (TempData);
		} else if (Level == 2) {
			Initialdata.RemoveAt (0);
			TempData.Answer.Add (Initialdata [0]);
			TempData.Answer.Add (Initialdata [3]);
			/*for (int m = 0; m<2; m++) {
				Debug.Log(TempData.Answer[m]);
			}*/
			Initialdata [0] = 0;
			Initialdata [3] = 0;
			TempData.DisplayData = Initialdata;
			
			TempData.DimensionX = 1;
			TempData.DimensionY = 1;
			GetData.Copy (TempData);
		} else if (Level == 3) {
			Initialdata.RemoveAt (0);
			TempData.Answer.Add (Initialdata [0]);
			TempData.Answer.Add (Initialdata [3]);
			TempData.Answer.Add (Initialdata [6]);
			/*for (int m = 0; m<2; m++) {
				Debug.Log(TempData.Answer[m]);
			}*/
			Initialdata [0] = 0;
			Initialdata [3] = 0;
			Initialdata [6] = 0;
			TempData.DisplayData = Initialdata;
			/*for (int m = 0; m<8; m++) {
				Debug.Log(TempData.DisplayData[m]);
			}*/
			TempData.DimensionX = 1;
			TempData.DimensionY = 1;
			GetData.Copy (TempData);
		} else if (Level == 4) {
			Initialdata.RemoveAt (0);
			TempData.Answer.Add (Initialdata [0]);
			TempData.Answer.Add (Initialdata [3]);
			TempData.Answer.Add (Initialdata [6]);
			TempData.Answer.Add (Initialdata [9]);
			/*for (int m = 0; m<2; m++) {
				Debug.Log(TempData.Answer[m]);
			}*/
			Initialdata [0] = 0;
			Initialdata [3] = 0;
			Initialdata [6] = 0;
			Initialdata [9] = 0;
			TempData.DisplayData = Initialdata;
			/*for (int m = 0; m<8; m++) {
				Debug.Log(TempData.Dis/layData[m]);
			}*/
			TempData.DimensionX = 1;
			TempData.DimensionY = 1;
			GetData.Copy (TempData);
		} else if (Level == 5) {
			
		} else {
			TempData.DimensionX = int.Parse (Initialdata [1].ToString ());
			//Debug.Log(TempData.DimensionX);
			//String test =Initialdata[2];
			TempData.DimensionY = int.Parse (Initialdata [2].ToString ());
			
			
			
			//Debug.Log(TempData.DimensionY);
			int R = TempData.DimensionX;
			int C = TempData.DimensionY;
			
			int RowDisplayDataSize = (R * C) + (2 * R * (C - 1)) + (2 * (R - 1) * C) + 2 * (R - 1) * (C - 1);
			int RowAnswerDataSize = R * C;
			int m = 0, n = 0, IndexR = 0, IndexC = 0;
			
			for (int i = 0; i < RowDisplayDataSize; i++) {
				TempData.DisplayData.Add (Initialdata [i + 7]);
				TempData.DisplayDataX.Add (m);
				TempData.DisplayDataY.Add (n);
				//Debug.Log(m+","+n+" " +Initialdata[i+7]);
				n++;
				if (m == 0) {
					if (n > 3 * (C - 1)) {
						m++;
						n = 0;
					}
				}
				if (m == 1 || ((IndexR) > 0 && m == 3 * IndexR + 1)) {
					if (n > 2 * (C - 1)) {
						m++;
						n = 0;
					}
				}
				if (m == 2 || (IndexR) > 0 && m == 3 * IndexR + 2) {
					if (n > 2 * (C - 1)) {
						m++;
						n = 0;
					}
				}
				if (m == 3 || (IndexR) > 0 && m == 3 * IndexR + 3) {
					if (n > 3 * (C - 1)) {
						m++;
						n = 0;
						IndexR++;
					}
				}
			}
			m = 0;
			n = 0;
			/*Debug.Log("------------------------------------------");
			for(int i = 0; i < RowDisplayDataSize; i++)
			{
				Debug.Log(TempData.DisplayDataX[i]+","+TempData.DisplayDataY[i]+" "+TempData.DisplayData[i]);
			}*/
			for (int i = 0; i < RowAnswerDataSize; i++) {
				TempData.Answer.Add (Initialdata [i + RowDisplayDataSize + 7]);
				TempData.AnswerX.Add (m);
				TempData.AnswerY.Add (n);
				//Debug.Log (m + "," + n + " " + Initialdata [i + RowDisplayDataSize + 7]);
				n++;
				if (n >= C) {
					m++;
					n = 0;
				}
			}
			/*Debug.Log("------------------------------------------");
			for(int i = 0; i < RowAnswerDataSize; i++)
			{
				Debug.Log(TempData.AnswerX[i]+","+TempData.AnswerY[i]+" "+TempData.Answer[i]);
			}*/
			GetData.Copy (TempData);
			Debug.Log ("------------------------------------------");
			for (int i = 0; i < RowDisplayDataSize; i++) {
				//Debug.Log (GetData.DisplayDataX [i] + "," + GetData.DisplayDataY [i] + " " + GetData.DisplayData [i]);
				Debug.Log (GetData.DisplayData [i]);
			}
			/*
			Debug.Log("------------------------------------------");
			for(int i = 0; i < RowAnswerDataSize; i++)
			{
				Debug.Log(GetData.AnswerX[i]+","+GetData.AnswerY[i]+" "+GetData.Answer[i]);
			}*/
		}
	}

}