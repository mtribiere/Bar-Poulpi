using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class QuestionDataBase{

    //Methodes
    public QuestionDataBase()
    {
        //questions.Add(new Question("Pas Bleu", new Color[] {Color.yellow,Color.blue,Color.green,Color.blue}, new int[] {0,2}));
        //questions.Add(new Question("Ni Rouge ni Blanc", new Color[] { Color.red, Color.green, Color.white, Color.yellow }, new int[] { 1,3 }));
        //questions.Add(new Question("Pas Rouge", new Color[] { Color.red, Color.red, Color.white, Color.yellow }, new int[] { 2, 3 }));
        //questions.Add(new Question("Jaune ou Bleu", new Color[] { Color.white, Color.blue, Color.red, Color.yellow }, new int[] { 1, 3 }));
        //questions.Add(new Question("Vert ou Jaune", new Color[] { Color.green, Color.white, Color.yellow, Color.green }, new int[] { 0,2, 3 }));

        questions.Add(new Question("Pas Bleu", "4212", "02"));
        questions.Add(new Question("Ni Rouge ni Blanc", "0134", "13"));
        questions.Add(new Question("Pas rouge", "0034", "23"));
        questions.Add(new Question("Jaune ou bleu", "3204", "13"));
        questions.Add(new Question("Vert ou Jaune", "1341", "023"));
        questions.Add(new Question("Ni Blanc Ni Bleu", "3012", "12"));
    }

    public Question getQuestionById(int id)
    {
        return questions[id];
    }

    public int getSize()
    {
        return questions.Count;
    }

    //Variables
    List<Question> questions = new List<Question>();
}
