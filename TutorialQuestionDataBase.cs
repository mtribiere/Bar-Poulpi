using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TutorialQuestionDataBase {

    public TutorialQuestionDataBase()
    {
        questions.Add(new Question("Bleu", "0002", "3"));
        questions.Add(new Question("Pas rouge", "0103", "13"));
        questions.Add(new Question("Ni rouge ni bleu", "0243", "23"));
        questions.Add(new Question("Ni bleu ni vert", "0421", "01"));
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
