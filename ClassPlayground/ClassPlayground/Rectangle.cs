using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Rectangle
    {
        public float width, height;

        public Rectangle(float width, float height) 
        {
            if (width < 0) width = -1 * width;
            if (height < 0) height = -1 * height;  
            this.height = height;
            this.width = width;
        }

        public void CalculateArea()
        {
            float value = width * height;
            Console.Write("the total area is " + value);
            
        }

        public void CalculateAspectRatio()
        {
            float aspectRatio = (width / height);
            if (aspectRatio > 1) Console.WriteLine(" wide");
            else if (aspectRatio < 1) Console.WriteLine(" tall");
            else Console.WriteLine(" and it is a square");           
        }

        public void ContainsPoint(float x, float y)
        {
            if (x < width || y < height) Console.WriteLine("yes, this point is located inside the rectangle");
            else Console.WriteLine("no, this point isn't located inside the rectangle");
        } 
    }
}
