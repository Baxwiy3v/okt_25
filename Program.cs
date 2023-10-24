using ConsoleApp231231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp231231
{
    internal class Program
    {
        static List<Quiz> quizzes = new List<Quiz>();
        

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("***Menyu***");
                Console.WriteLine("1. yeni quiz");
                Console.WriteLine("2. Solve a quiz");
                Console.WriteLine("3. Show quizzes");
                Console.WriteLine("0. Quit");
                Console.Write("Sechim ed: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateNewQuiz();
                            break;
                        case 2:
                            SolveQuiz();
                            break;
                        case 3:
                            ShowQuizzes();
                            break;
                        case 0:
                            Console.WriteLine("Proqramdan cıxılır.");
                            break;
                        default:
                            Console.WriteLine("sehv secim");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("sehv secim.");
                }

            } while (choice != 0);
        }
        static void ShowQuizzes()
        {
           
            if (quizzes.Count == 0)
            {

                Console.WriteLine(" hecbir quiz mövcud deyil.");
                
            }
            else
            {
                Console.WriteLine("Movcud Quizlər:");
                for (int i = 0; i < quizzes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {quizzes[i].Name}");
                }
            }
        }

       



        static void CreateNewQuiz()
        {
            Console.Write("Quizin adını daxil edin: ");
            string quizName = Console.ReadLine();

            Console.Write("Quizdə neçə sual olmalıdır: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfQuestions))
            {
                List<Question> questions = new List<Question>();

                for (int i = 1; i <= numberOfQuestions; i++)
                {
                    Console.WriteLine($"Sual {i} üçün məlumatları daxil edin:");
                    Console.Write("Sualın mətni: ");
                    string questionText = Console.ReadLine();

                    List<string> answerOptions = new List<string>();
                    Console.Write("Variantları daxil edin (növbəti variantı daxil etmək üçün Enter düyməsinə basın): ");
                    string answerOption;
                   

                    Console.Write("Doğru variantın indeksini seçin (0 ilə başlayaraq): ");
                    if (int.TryParse(Console.ReadLine(), out int correctAnswerIndex) && correctAnswerIndex >= 0 && correctAnswerIndex < answerOptions.Count)
                    {
                        questions.Add(new Question(questionText, answerOptions, correctAnswerIndex));
                    }
                    else
                    {
                        Console.WriteLine("sehv indeks. Sual əlavə edilmədi.");
                    }
                }

                Quiz newQuiz = new Quiz(quizName, questions);
                quizzes.Add(newQuiz);

                Console.WriteLine("Quiz uğurla əlavə edildi.");
            }
            else
            {
                Console.WriteLine("Yanlış rəqəm. Quiz yaradılmadı.");
            }

        }



        private static void SolveQuiz()
        {
            if (quizzes.Count == 0)
            {
                Console.WriteLine("Hazırda heçbir quiz mövcud deyil.");
                return;
            }

            Console.WriteLine("Siz hansı quizi həll etmək istəyirsiniz?");
            ShowQuizzes();

            int quizId;
            if (int.TryParse(Console.ReadLine(), out quizId) && quizId >= 1 && quizId <= quizzes.Count)
            {
                Quiz selectedQuiz = quizzes[quizId - 1];
                int correctAnswers = 0;

                Console.WriteLine($"\"{selectedQuiz.Name}\" quizi başladı.");
                for (int i = 0; i < selectedQuiz.Questions.Count; i++)
                {
                    Console.WriteLine($"Sual {i + 1}: {selectedQuiz.Questions[i].Text}");
                    for (int j = 0; j < selectedQuiz.Questions[i].AnswerOptions.Count; j++)
                    {
                        Console.WriteLine($"{j}. {selectedQuiz.Questions[i].AnswerOptions[j]}");
                    }
                    Console.Write("Cavabınızı seçin (variantın nömrəsini qeyd edin): ");
                    if (int.TryParse(Console.ReadLine(), out int userAnswer) && userAnswer == selectedQuiz.Questions[i].CorrectAnswerIndex)
                    {
                        Console.WriteLine("Düzgün cavab!");
                        correctAnswers++;
                    }
                    else
                    {
                        Console.WriteLine("Səhv cavab.");
                    }
                }

                Console.WriteLine($"Düzgün cavabladığınız sualların sayı: {correctAnswers}/{selectedQuiz.Questions.Count}");
            }
            else
            {
                Console.WriteLine("sehv quiz ID..");
            }
        }

       
    }
}

















































//Quiz Console App yazırsınız.

//Menyunun elementləri 

//1. Create new quiz
//2.Solve a quiz
//3. Show quizzes
//0. Quit

//Create quiz-ə daxil olduqda

//1. Quizin adını yazmağımızı istəyir
//2. Tərkibində neçə sual olacağını qeyd etməyimizi istəyir
//3. Sualları daxil edirik:
//    a.Sualın mətnini daxil edirik
//    b. variantları daxil edirik
//    c. doğru variantı qeyd edirik

//    `Show quizzes` daxil olduqda, yaradılan bütün quizlərin `Id` və `Name`-ni ekrana çıxarır

//`Solve a quiz` daxil olduqda 

//1. daxil olmaq üçün quizin `Id`sini daxil edirik
//2. suallar bir-bir ekrana çıxır, biz cavabladıqca növbəti sual ekrana çıxır. Cavab olaraq variantın nömrəsini qeyd edirik
//3.Hamısını cavabladıqdan sonra ekrana nəticəmiz çıxır. Suallardan neçəsini doğru yazmışıq
//Hansı classlara ehtiyacınız olacaq, hansı propertilər lazımdır, özünüz düşünün.
//Tip:

//`Quiz:`

//`int Id`

//`string Name`

//`List<Question> Questions`

//`Question:`

//`int Id`

//`string Text`

//`List<string> Variants`

//`int CorrectVariant`