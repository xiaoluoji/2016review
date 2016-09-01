using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace _2016_review
{
    class ClassTest
    {
        public class MyClass
        {
        }
    }
    class MyMathClass
    {
        public static readonly double PI;
        static MyMathClass()
        {
            PI = 3.14;
        }
    }
    class Car:ICloneable,IComparable<Car>
    {
        public readonly int _maxSpeed;
        private int _currentSpeed;
        private string _carName;
        public Car(string carName,int max,string carColor="Red")
        {
            _maxSpeed = max;
            _carName = carName;
            CarColor = carColor;
        }

        public int Speed
        {
            get { return _currentSpeed; }
            set
            {
                _currentSpeed = value;
                if (_currentSpeed>_maxSpeed)
                {
                    _currentSpeed = _maxSpeed;
                }
            }
        }
        public string CarName {
            get { return _carName; }
        }
        public string CarColor { get; set; }
        public  virtual void SpeedUp(int addSpeed)
        {
            _currentSpeed += addSpeed;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        int IComparable<Car>.CompareTo(Car other)
        {
            return this._maxSpeed.CompareTo(other._maxSpeed);
        }
        public static IComparer<Car> SortByCarName
        {
            get { return (IComparer<Car>)new CarNameComparer(); }
        }
        private class CarNameComparer : IComparer<Car>
        {
            int IComparer<Car>.Compare(Car x, Car y)
            {
                return string.Compare(x.CarName, y.CarName);
            }
        }
        //public delegate void CarEventHandler(TextBox testOutput);

        //public event CarEventHandler AboutToBlow;

        public event EventHandler<CarEventArgs> AboutToBlow;
        public static void CarAboutToBlow(object sender,CarEventArgs e)
        {
            TextBox output = e.Output;
            output.AppendText(e.Message);
        }
        public void destroyCar(TextBox tbox)
        {
            //AboutToBlow(tbox);
            CarEventArgs blowArgs = new CarEventArgs();
            blowArgs.Output = tbox;
            blowArgs.Message = "This  car is about to blow !\n";
            AboutToBlow(this, blowArgs);
        }
    }

    class CarEventArgs : EventArgs
    {
        public TextBox Output { get; set; }
        public string Message { get; set; }
        public CarEventArgs()
        {

        }
    }

    class MiniVan : Car
    {
        public MiniVan(string carName, int max) : base(carName, max)
        {
        }

        public  void TestMethod()
        {
            Speed = 10;
        }
        public override void SpeedUp(int addSpeed)
        {
            base.SpeedUp(addSpeed+5);
        }
    }
    class BuickVan:Car
    {
        public BuickVan(string carName,int max):base(carName,max)
        {

        }
        public override void SpeedUp(int addSpeed)
        {
            base.SpeedUp(addSpeed+10);
        }
    }

    public class Garage
    {
        private Car[] _carArray = new Car[4];
        public Garage()
        {
            _carArray[0] = new Car("Rusty", 30);
            _carArray[1] = new Car("Clunker", 55);
            _carArray[2] = new Car("Zippy", 60);
            _carArray[3] = new Car("Fred", 20);
        }

        public IEnumerator GetEnumerator()
        {
            return _carArray.GetEnumerator();
        }

    }

    static class MyExtenstions
    {
        public static int ReverseDigits(this int i)
        {
            char[] digits = i.ToString().ToCharArray();
            Array.Reverse(digits);
            string newDigits = new string(digits);
            return int.Parse(newDigits);
        }
    }

}
