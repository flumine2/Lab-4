using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class MyComplex : IMyNumber<MyComplex>
    {
        private double re;
        private double im;

        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(re + that.re, im + that.im);
        }

        public MyComplex Divide(MyComplex that)
        {
            double nom_re = re * that.re + im * that.im;
            double denom = Math.Pow(that.re, 2) + Math.Pow(that.im, 2);
            double nom_im = im * that.re - that.im * re;

            return new MyComplex(nom_re / denom, nom_im / denom);
        }

        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(re * that.re - im * that.im, im * that.re + that.im * re);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(re - that.re, im - that.im);
        }

        public override string ToString()
        {
            if (im < 0)
                return re.ToString() + im.ToString() + "i";
            else
                return re.ToString() + "+" + im.ToString() + "i";
        }
    }
}
