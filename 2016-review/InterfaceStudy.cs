using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2016_review
{
    interface IDraw3D
    {
        void Draw3D(TextBox tboxTest);
    }
    interface IDrawToForm
    {
        void Draw(TextBox tboxTest);
    }
    interface IDrawToMemory
    {
        void Draw(TextBox tboxTest);
    }
    interface IDrawToPrinter
    {
        void Draw(TextBox tboxTest);
    }
}
