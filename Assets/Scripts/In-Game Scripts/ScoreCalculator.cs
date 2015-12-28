using UnityEngine;
using System.Collections;
using System.Timers;

public class ScoreCalculator : MonoBehaviour {
    public static int GetScoreFor (int numError,int level) {
        int[,] table ={ {0,0,0,0,0,0},  		//1
                        {0,0,0,0,0,0},		//2
                        {60,50,40,30,20,0},	//3
                        {65,55,45,35,25,0},	//4
                        {70,60,50,40,30,0},	//5
                        {75,65,55,45,35,0},	//6
                        {80,70,60,50,40,0},	//7
                        {85,75,65,55,45,0},	//8
                        {90,80,70,60,50,0},	//9
                        {95,85,75,65,55,0},	//10
                        {100,90,80,70,60,0},	//11
                        {105,95,85,75,65,0},	//12
                        {110,100,90,80,70,0},	//13
                        {120,110,100,90,80,0}};	//14
                        
        int score=0;
        int error = numError - 1;
        if (error < 0)
            error = 0;
        score = table[level-1,numError];
	return score;        
    }
}