namespace Lab_6{

public class Blue_4
{
    public struct Team{
        private string _name;
        private int[] _scores;
        public string Name => _name;
        
        public int[] Scores{
            get{
                if (_scores == null) return null;
                
                int[] sc= new int[_scores.Length];
                Array.Copy(_scores,sc,_scores.Length);
                return sc;
            }
        }
        public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int k = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        k += _scores[i];
                    }
                    return k;
                }
            }
        public Team(string name){
            _name=name;
            _scores = new int[0];
        }
        public void PlayMatch(int result)
            {
                if (_scores == null) return;
                int[] copy = new int[_scores.Length + 1];
                Array.Copy(_scores, copy,_scores.Length);
                copy[copy.Length - 1] = result;
                _scores = copy;
                
            }
        public void Print(){
            Console.WriteLine($"{Name} - {Scores}");
        }
    }

    public struct Group{
        private string _name;
        private Team[] _teams;
        private int _teamid;
        public string Name => _name;
        public int TeamId => _teamid;
        public Team[] Teams => _teams;

            
        
        public Group(string name){
            _name=name;
            _teams = new Team[12];
            _teamid = 0;
        }
        public void Add(Team team){
            if (_teams == null || _teams.Length == 0 || _teamid >= _teams.Length) return;
            if(_teamid < _teams.Length){
                _teams[_teamid] = team;
                _teamid++;
            }
        }
        public void Add(Team[] teams)
            {
                if (_teams == null || teams == null || teams.Length == 0) return;
                int i = 0;
                while (_teamid < _teams.Length && i < teams.Length)
                {
                    _teams[_teamid] = teams[i];
                    _teamid++;
                    i++;
                }
            }
        public void Sort(){
            if (_teams == null) return;
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
        }
        public static Group Merge(Group group1, Group group2, int size){
            Group fin = new Group("Финалисты");
            int c = size/2;
            int i=0;
            int j=0;
            while(i<c && j<c){
                if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore){
                    fin.Add(group1.Teams[i]);
                    i++;
                }else{
                    fin.Add(group2.Teams[j]);
                    j++;
                }

            }
            while (i<c){
                fin.Add(group1.Teams[i]);
                i++;
            }
            while(j<c){
                fin.Add(group2.Teams[j]);
                j++;
            }
            return fin;
        }
        public void Print()
            {
                Console.WriteLine(_name);
                for (int k = 0; k < _teamid; k++)
                {
                    _teams[k].Print();
                }
            }
    }
}
}