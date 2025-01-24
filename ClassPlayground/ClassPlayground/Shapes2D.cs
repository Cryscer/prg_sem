using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Shapes2D
    {
        public Shapes2D() { }

        public virtual void CalculateArea()
        {
            Console.WriteLine("Undefined shape, cannot have area");
        }

        public virtual void CalculateAspectRatio() 
        {
            Console.WriteLine("Undefined shape, cannot have aspect ratio");
        }
        public virtual void ContainsPoint(float x, float y)
        {
            Console.WriteLine("Undefined shape, cannot ptocess point");
        }
    }
}
