using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace Lab6{

public class Blue_1
{
    public struct Response
    {
        private string _name;
        private string _surname;
        private int _votes;
        public string Name => _name;
        public string Surname => _surname;
        public int Votes => _votes;
        public Response (string name, string surname)
        {
            _name=name;
            _surname=surname;
            _votes=0;
        }
        public int CountVotes(Response[] responses)
        {
            if (responses.Length == 0 || responses == null) return 0;
            int count = 0;
            foreach(Response r in responses){
                if (r.Name == _name && r.Surname == _surname){
                    count++;
                }

            }
            _votes = count;
            return count;
        }
        public void Print()
        {
            Console.WriteLine($"Имя: {Name}, Фамилия: {Surname}, Голосов: {Votes}");
        }
    }
}
}
