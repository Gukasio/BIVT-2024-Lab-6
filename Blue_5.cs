namespace Lab_6{

public class Blue_5
{
    public struct Sportsman{
        private string _name;
        private string _surname;
        private int _place;
        public string Name => _name;
        public string Surname => _surname;
        public int Place => _place;
        public Sportsman(string name, string surname){
            _name = name;
            _surname = surname;
            _place = 0;
        }
        public void SetPlace(int place){
            if (_place != 0) return;
            this._place = place;
        }
        public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - {Place}");
            }
    }
    public struct Team{
        private string _name;
        private Sportsman[] _sportsmen;
        private int _count;
        public string Name => _name;
        private int Count  =>_count;
        public Sportsman[] Sportsmen {
            get{
                if (_sportsmen == null) return null;
                Sportsman[] sp = new Sportsman[_sportsmen.Length];
                for (int i=0;i<_sportsmen.Length;i++){
                    sp[i] = _sportsmen[i];
                    
                }
                return sp;
            }
        }
        public int SummaryScore{
            get{
                if (_sportsmen == null || _sportsmen.Length == 0) return 0;
                int s=0;
                for (int i=0;i<_sportsmen.Length;i++){
                    if (_sportsmen[i].Place == 1) {s+=5;}
                    if (_sportsmen[i].Place == 2) {s+=4;}
                    if (_sportsmen[i].Place == 3) {s+=3;}
                    if (_sportsmen[i].Place == 4) {s+=2;}
                    if (_sportsmen[i].Place == 5) {s+=1;}
                }
                return s;
            }
        }
        public int TopPlace{
            get{
            if (_sportsmen == null || _sportsmen.Length == 0) return 0;
            int m=18;
            
            for(int i=0;i<_sportsmen.Length;i++){
                if (_sportsmen[i].Place < m && _sportsmen[i].Place > 0){
                    m=_sportsmen[i].Place;
                }
            }
            return m;
            }

        }
        public Team(string name){
            _name=name;
            Sportsman[] _sportsmen = new Sportsman[6];
            _count=0;
        }
        public void Add(Sportsman sportsman){
            if (_sportsmen == null || _sportsmen.Length==0) return;
            if(_count < _sportsmen.Length){
                _sportsmen[_count] = sportsman;
                _count++;
            }
        }
        public void Add(Sportsman[] sportsman){
            if (_sportsmen == null || _sportsmen.Length==0) return;
            int i=0;
            if(_count < _sportsmen.Length){
                _sportsmen[_count] = sportsman[i];
                i++;
                _count++;
            }
        }
        public static void Sort(Team[] teams){
            if (teams == null || teams.Length == 0) return;
            for (int i=1,j=2;i<teams.Length;){
                if (i ==0 || teams[i-1].SummaryScore > teams[i].SummaryScore){
                    i=j;
                    j++;
                }else if(teams[i-1].SummaryScore == teams[i].SummaryScore && teams[i-1].TopPlace < teams[i].TopPlace){
                    i=j;
                    j++;
                }else{
                    (teams[i-1],teams[i])= (teams[i],teams[i-1]);              
                    }
            }
        }
        public void Print()
            {
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    Console.WriteLine($"{Name} {SummaryScore} {TopPlace}");
                }
            }

    }
}
}
