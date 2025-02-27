using System.Reflection.Metadata.Ecma335;

namespace Lab_6{

public class Blue_2
{
    public struct Participant{
        private string _name;
        private string _surname;
        private int[,] _marks;
        private int _count;

        public string Name => _name;
        public string Surname => _surname;
        public int[,] Marks
        {
            get
            {
                if (_marks == null) return null;
                int[,] r = new int[_marks.GetLength(0), _marks.GetLength(1)];
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        r[i, j] = _marks[i, j];
                    }
                }
                return r;
                
            }
        }
        public int TotalScore{
            get{
                if (_marks == null ) return 0;
                int k = 0;
                for(int i=0;i<_marks.GetLength(0);i++)  {
                    for(int j=0;j<_marks.GetLength(1) ;j++) {
                        k += _marks[i,j];
                    }
                }
                return  k;
            }
            
        }
        public Participant(string name,string surname)
        {
            _name = name;
            _surname = surname;
            _marks = new int[2,5];
            _count=0;
        }
        public void Jump(int[] result)
        {
            if (result == null || result.Length == 0|| _count>1) return;
            if (_marks == null || _marks.GetLength(0) == 0) return;
            for (int i = 0; i < 5; i++)
            {
                _marks[_count, i] = result[i];
            }
            _count++;
        }
        public static void Sort(Participant[] array)
        {
            if (array == null || array.Length == 0) return;
            for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
        }

        
        public void Print(){
            Console.WriteLine($"{Name} {Surname} - {TotalScore}");
        }
    }
}
}
