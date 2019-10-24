using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Coins
    {
        private int _id;
        private string _genstand;
        private int _bud;
        private string _navn;

        public Coins(int id, string genstand, int bud, string navn)
        {
            _id = id;
            _genstand = genstand;
            _bud = bud;
            _navn = navn;
        }

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public int Bud
        {
            get { return _bud; }
            set { _bud = value; }
        }

        public string Genstand
        {
            get { return _genstand; }
            set { _genstand = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Navn)}: {Navn}, {nameof(Bud)}: {Bud}, {nameof(Genstand)}: {Genstand}, {nameof(Id)}: {Id}";
        }
    }
}
