namespace Lab_6{

public class Blue_3
{
    public struct Participant{
        private string _name;
        private string _surname;
        private int[] _penaltytimes;
        public string Name => _name;
        public string Surname => _surname;
        public int[] PenaltyTimes{
            get{
                if (_penaltytimes== null) return null;
                if (_penaltytimes.Length==0) return _penaltytimes;
                int[] p =new int[_penaltytimes.Length];
                Array.Copy(_penaltytimes, p, _penaltytimes.Length);
                /*for(int i =0;i<_penaltytimes.Length;i++){
                    p[i] = _penaltytimes[i];
                }*/
                return p;
            }
            
        }
        public int TotalTime{
            get{
                if (_penaltytimes == null || _penaltytimes.Length == 0) return 0;
                    return _penaltytimes.Sum();
            }
        }
        public bool IsExpelled{
            get{
                if (_penaltytimes == null || _penaltytimes.Length==0) return true;
                for (int i =0;i<_penaltytimes.Length;i++){
                    if (_penaltytimes[i] == 10)
                    {
                        return true;
                    }
                    
                }
                return false;
            }
        }
        public Participant(string name, string surname){
            _name = name;
            _surname = surname;
            _penaltytimes = new int[0];
        }
        public void PlayMatch(int time)
            {
                if (_penaltytimes== null) return;
                int[] p = new int[_penaltytimes.Length+1];
                for (int i=0; i<p.Length-1; i++)
                {
                    p[i] = _penaltytimes[i];
                }
                p[p.Length-1] = time;
                _penaltytimes = p;
            }
        public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
        public void Print(){
            Console.WriteLine($"{Name} {Surname} - {TotalTime}");
        }
    }
}
}