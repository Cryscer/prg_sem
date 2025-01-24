using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Circle : Shapes2D
    {
        float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public override void CalculateArea()
        {
            float value = (float)Math.PI * radius * radius;
            Console.Write("the total area is " + value);

        }

        public override void ContainsPoint(float x, float y)
        {
            if (Math.Sqrt(x*x + y*y) <= radius) Console.WriteLine("yes, this point is located inside the circle");
            else Console.WriteLine("no, this point isn't located inside the circle");
        }
    }
}
