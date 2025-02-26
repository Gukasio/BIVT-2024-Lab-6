namespace Lab6{

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
                Array.Copy(_penaltytimes, p , _penaltytimes.Length);
                /*for(int i =0;i<_penaltytimes.Length;i++){
                    p[i] = _penaltytimes[i];
                }*/
                return p;
            }
            
        }
        public int TotalTime{
            get{
                if(_penaltytimes == null || _penaltytimes.Length==0) return 0;
                int s=0;
                for (int i =0;i<_penaltytimes.Length;i++){
                    s+=_penaltytimes[i];
                }
                return s;
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
            _penaltytimes = new int[10];
        }
        public void PlayMatch(int time)
            {
                if (_penaltytimes == null) return;
                if (_penaltytimes.Length == 0)
                {
                    int[] p = new int[1];
                    p[0] = time;
                    _penaltytimes = new int[1];
                    Array.Copy(p, _penaltytimes, p.Length);
                }
                int[] pcopy = new int[_penaltytimes.Length + 1];
                Array.Copy(_penaltytimes, pcopy,_penaltytimes.Length);
                pcopy[pcopy.Length - 1] = time;
                _penaltytimes = pcopy;
            }
        public static void Sort(Participant[] array){
            if (array == null || array.Length == 0) return;
            for(int i=1, next=2 ;i< array.Length;i++){
                if(i==0 || array[i].TotalTime <= array[i+1].TotalTime){
                    i=next;
                    next++;
                }else{
                    (array[i],array[i+1])=(array[i+1],array[i]);
                    i--;
                }
            }
        }
        public void Print(){
            Console.WriteLine($"{Name} {Surname} - {TotalTime}");
        }
    }
}
}