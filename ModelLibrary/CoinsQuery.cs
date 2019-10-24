using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class CoinsQuery
    {
        private int _minBud;
        private int _maxBud;


        public CoinsQuery(int minBud, int maxBud)
        {
            _minBud = minBud;
            _maxBud = maxBud;
        }

        public CoinsQuery()
        {
            
        }

        public int MaxBud
        {
            get { return _maxBud; }
            set { _maxBud = value; }
        }

        public int MinBud
        {
            get { return _minBud; }
            set { _minBud = value; }
        }

        public override string ToString()
        {
            return $"{nameof(MaxBud)}: {MaxBud}, {nameof(MinBud)}: {MinBud}";
        }
    }
}
