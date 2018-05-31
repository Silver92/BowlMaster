using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    public static List<int> ScoreCumulative (List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;
        
        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    // calculate the single frame of scores
    public static List<int> ScoreFrames (List<int> rolls) {
        List<int> frameList = new List<int>();

        // Index i points to 2nd bowl of frame
        for (int i = 1; i < rolls.Count; i+=2) {

            if (frameList.Count == 10) { break; }               // Prevents 11th frame score
            
            if (rolls[i-1] + rolls[i] < 10) {
                frameList.Add(rolls[i - 1] + rolls[i]);         // Normal "open" frame
            }
                
            if (rolls.Count - i <= 1) {break;}                  // Ensure at least 1 look-ahead available

            if (rolls[i - 1] == 10){                            // STRIKE
                i--;                                            // Strike frame has just one bowl
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
            } else if (rolls[i - 1] + rolls[i] == 10) {         // Calculate Spare bonus
                frameList.Add(10 + rolls[i + 1]);
            }
        }

        return frameList;
    }
    
    
    public static List<int> ScoreFrames2 (List<int> rolls) {
        List<int> frameList = new List<int>();
        int singleFrame = 0;
        int spare = 0;
        int index = 0;

        for (int i = 1; i <= rolls.Count; i++)
        {

            index++;
            singleFrame += rolls[i - 1];

            if (index >= 19) {

                if (spare > 0) {
                    frameList.Add(singleFrame);
                    singleFrame -= 10;
                    spare--;
                }
                if (i == rolls.Count) {
                    frameList.Add(singleFrame);
                    break;
                }
                
                continue;
            }

            if((singleFrame % 10 == 0) && (singleFrame != 0) && (index % 2 != 0)){
                if (index % 2 != 0) {
                    index ++;
                    spare ++;
                }
                if (spare <= 2) { 
                    continue;
                }
            }

            if ((spare == 0) && (singleFrame > 10)) {
                frameList.Add(singleFrame);
                singleFrame -= 10;
            }

            if ((index % 2 == 0) || (singleFrame > 20)) {
                if(spare > 0) {
                    frameList.Add(singleFrame);
                    singleFrame -= 10;
                    spare--;
                } 
                if (spare == 0) {
                    frameList.Add(singleFrame);
                    singleFrame = 0;
                }
            }
        }
        
        return frameList;
    }
}
