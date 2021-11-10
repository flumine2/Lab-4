using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger nom;
        private BigInteger denom;

        public MyFrac(int nom, int denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException();
            }
            this.nom = nom;
            this.denom = denom;
        }

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException();
            }
            this.nom = nom;
            this.denom = denom;
        }

        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
        }

        public MyFrac Divide(MyFrac that)
        {
            if (that.nom == 0)
            {
                throw new DivideByZeroException();
            }
            return new MyFrac(nom * that.denom, denom * that.nom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, denom * that.denom);
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(nom * that.denom - that.nom * denom, denom * that.denom);
        }

        private void Normalise()
        {
            BigInteger n = nom, d = denom;
            while (n % 2 == 0 && d % 2 == 0)
            {
                n = n / 2;
                d = d / 2;
            }
            if (d % n == 0)
            {
                d = d / n;
                n = 1;
            }
            nom = n;
            denom = d;
        }

        public override string ToString()
        {
            Normalise();
            return nom.ToString() + "/" + denom.ToString();
        }

        public int CompareTo(MyFrac other)
        {
            if (nom.CompareTo(other.nom) == 0)
            {
                if (denom.CompareTo(other.denom) == 0)
                {
                    return 0;
                }
                else if (denom.CompareTo(other.denom) == 1)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (nom.CompareTo(other.nom) == 1)
            {
                if (denom.CompareTo(other.denom) <= 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (denom.CompareTo(other.denom) >= 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
