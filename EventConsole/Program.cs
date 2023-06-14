using EventConsole;
using System.Diagnostics;

var sw = new Stopwatch();
var ps = new ParSummator(2000000000);

void ShowResult()
{
    sw.Stop();
    Console.WriteLine("{0} за {1} мс.", ps.Result, sw.ElapsedMilliseconds);
}

var ss = new SeqSummator(2000000000);
sw.Start();
ss.Sum();
sw.Stop();
Console.WriteLine("{0} за {1} мс.", ss.Result, sw.ElapsedMilliseconds);
Console.WriteLine();
Console.WriteLine();

ps.Finish += ShowResult; // подписка на событие (передали ссылку на функцию).
                         // Воспринимать такое событие может несколько слушателей.
                         // Подписаться можем из разных мест и событие будет транслироваться
                         // во все эти места.
                         // Обращение в функции без скобок: ShowResult, создает ссылку на неё
                         // Вызов ShowResult будет в классе ParSummator, но не тут
sw.Restart();
ps.Sum();