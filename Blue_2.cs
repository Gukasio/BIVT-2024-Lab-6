using System.Reflection.Metadata.Ecma335;

namespace Lab6{

public class Blue_2
{
    public struct Participant{
        private string _name;
        private string _surname;
        private int[,] _marks;
        public string Name => _name;
        public string Surname => _surname;
        public int[,] Marks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) != _marks.GetLength(1)) return default(int[,]);
                int[,] copy = new int[_marks.GetLength(0),_marks.GetLength(1)];
                Array.Copy(_marks, copy,_marks.GetLength(0));
                return copy;
            }
        }
        public int TotalScore{
            get{
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
            _marks = new int[,]{{0,0,0,0,0},{0,0,0,0,0}};
        }
        public void Jump(int[] result)
        {
            if (result == null) return;
            for(int i=0;i<_marks.GetLength(0);i++){
                if (_marks[i,0]==0){
                    for (int j=0;j<_marks.GetLength(1);j++) {
                        _marks[i,j]= result[j];
                    }
                    break;
                }
            }
        }
        public static void Sort(Participant[] array)
        {
            if (array == null) return;
            for(int i=1, next=2 ;i< array.Length;i++){
                if(i==0 || array[i-1].TotalScore >=array[i].TotalScore){
                    i=next;
                    next++;
                }else{
                    (array[i-1],array[i])=(array[i],array[i-1]);
                    i--;
                }
            }
        }
        public void Print(){
            Console.WriteLine($"{Name} {Surname} - {TotalScore}");
        }
    }
}
}