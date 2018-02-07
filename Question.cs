using UnityEngine;
using System.Collections;

/**
 * 
 * Format des couleurs :
 * 0:Rouge
 * 1:Vert
 * 2:Bleu
 * 3:Blanc
 * 4:Jaune
 * 
 * 
 * Format des Sides
 * 0:Gauche
 * 1:Haut
 * 2:Droite
 * 3:Bas
 * 
 **/


public class Question{
   
    public Question(string questionText,string colors,string correctSide)
    {
        this.questionText = questionText;
        this.colors = colors;
        this.correctSide = correctSide;
    }
   

    public string getQuestionText()
    {
        return this.questionText;
    }

    public Color getColorById(int id)
    {
        return this.availableColor[(int)char.GetNumericValue(this.colors[id])];
    }

    public int[] getCorrectSide()
    {
        int[] toReturn = new int[correctSide.Length];
        for(int i = 0; i < correctSide.Length; i++)
        {
            toReturn[i] = (int)char.GetNumericValue(this.correctSide[i]);
        }

        return toReturn;
    }

    //Variables 
    private string questionText;
    private string colors;
    private string correctSide;
    private Color[] availableColor = new Color[] { Color.red, Color.green, Color.blue, Color.white, Color.yellow };
}
